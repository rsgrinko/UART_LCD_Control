#include <LiquidCrystal.h>
#include <SoftwareSerial.h>
LiquidCrystal lcd(12, 11, 5, 4, 3, 2);
SoftwareSerial SerialHW(10, 9); // RX, TX

void setup() {
  SerialHW.begin(9600);
  lcd.begin(16, 2);
  lcd.print(">  IoT SYSTEM  <");
  lcd.setCursor(0, 1);  
  lcd.print("!    NO LINK   !");
}
void loop() 
{
  if(SerialHW.available() > 0)
  {
    delay(100);
    char cout[]="                ";
    bool line_flag = true;
    byte tmp_symbol;
    for (int i=0;SerialHW.available();i++){
      if(line_flag) {
      tmp_symbol = SerialHW.read();
      
        if(tmp_symbol == '0'){
            lcd.setCursor(0,0);
          } else {
            lcd.setCursor(0,1);
          }
          line_flag = false;
        } else {
          cout[i-1] = SerialHW.read();
        }
      
    }
    print_char_array(cout);
  }
}
void print_char_array(char *char_array)
{
  byte i=0;
  while(char_array[i]!='\0') {
    lcd.write(char_array[i++]);
  }
}
