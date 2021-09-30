using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.Threading;


namespace testWinForms
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string r1 = "OFF";
        string r2 = "OFF";

        SerialPort port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);

        private void Form1_Load_1(object sender, EventArgs e)
        {
            string[] ports;
            ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
            string s = Environment.CurrentDirectory;
            pictureBox1.ImageLocation = s + "\\lcd.jpeg";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] ports;
            ports = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(ports);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (port.IsOpen == false)
            {
                port.PortName = comboBox1.Text.ToString();
                port.Open();
                label1.Text = "Используется " + port.PortName;
                port.BaudRate = 9600;
                port.WriteTimeout = 500;
                port.ReadTimeout = 500;
                EnableForm();
            }
        }

        public void EnableForm()
        {
            button5.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Thread.Sleep(150); 
            port.Write("0" + textBox1.Text);
            Thread.Sleep(150);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread.Sleep(150);
            port.Write("1" + textBox2.Text);
            Thread.Sleep(150);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string result;
           
            switch (comboBox2.SelectedIndex)
            {
                default:
                    result = DateTime.Now.ToString("HH:mm:ss");
                break;

                case 0:
                    result = DateTime.Now.ToString("HH:mm:ss");
                break;

                case 1:
                    PerformanceCounter cpuCounter;
                    PerformanceCounter ramCounter;

                   // cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                    ramCounter = new PerformanceCounter("Memory", "Available MBytes");

                    result = "  " + ramCounter.NextValue() + "MB";
                break;

                case 2:
                    Random rnd = new Random();
                    result = Convert.ToString(rnd.Next());
                break;

            }

            port.Write("1" + r1 + " " + r2 + " " + result);
            Thread.Sleep(150);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Thread.Sleep(150);

            port.Write("0Running LCD TEST");
            Thread.Sleep(150);
            port.Write("1                ");
            Thread.Sleep(150);

            port.Write("1                ");
            Thread.Sleep(150);

            port.Write("1#               ");
            Thread.Sleep(150);

            port.Write("1##              ");
            Thread.Sleep(150);

            port.Write("1###             ");
            Thread.Sleep(150);

            port.Write("1####            ");
            Thread.Sleep(150);

            port.Write("1#####           ");
            Thread.Sleep(150);

            port.Write("1#####           ");
            Thread.Sleep(150);

            port.Write("1######          ");
            Thread.Sleep(150);

            port.Write("1#######         ");
            Thread.Sleep(150);

            port.Write("1########        ");
            Thread.Sleep(150);

            port.Write("1#########       ");
            Thread.Sleep(150);

            port.Write("1##########      ");
            Thread.Sleep(150);

            port.Write("1###########     ");
            Thread.Sleep(150);

            port.Write("1############    ");
            Thread.Sleep(150);

            port.Write("1#############   ");
            Thread.Sleep(150);

            port.Write("1##############  ");
            Thread.Sleep(150);

            port.Write("1############### ");
            Thread.Sleep(150);

            port.Write("1################");
            Thread.Sleep(500);

            port.Write("0>   LCD TEST   <");
            Thread.Sleep(150);
            port.Write("1>TEST COMPLETED<");
            Thread.Sleep(1000);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                r1 = "ON ";
            } else
            {
                r1 = "OFF";
            }
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                r2 = "ON ";
            }
            else
            {
                r2 = "OFF";
            }
        }

        private void checkBox3_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
