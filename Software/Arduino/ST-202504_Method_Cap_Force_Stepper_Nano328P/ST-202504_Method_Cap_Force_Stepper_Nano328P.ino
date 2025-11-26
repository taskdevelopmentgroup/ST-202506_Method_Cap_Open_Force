/*
  ST-202504_Method_Cap_Force_Stepper_Nano328P

  Arduino Nano328P

  Development board CNC
*/

#define EN      8  //11 //PB0 //D8
#define STEP1   2  //PD2 //D2
#define DIR1    5  //PD5 //D5

#define STEP2   3  //PD3 //D3
#define DIR2    6  //PD6 //D6

#define STEP3   4 //D4
#define DIR3    7 //D7

#define SW1     10 //D10
#define SW2     9 //D9

String inputString = "";         // a String to hold incoming data
bool flgStringComplete = false;  // whether the string is complete
bool flgMoveMotor = false;
int activeDirection = 0, oldSW1, oldSW2, newSW1;


void isrSW1()
{
  digitalWrite(LED_BUILTIN, HIGH);   // turn the LED on (HIGH is the voltage level)

  if (digitalRead(SW1) != oldSW1)
  {
    if (digitalRead(SW1) == 0)
    {
      activeDirection = !activeDirection;
      //Serial.println("\tSW1 on");
    }
    oldSW1 = digitalRead(SW1);
  }
}

void isrSW2()
{

  digitalWrite(LED_BUILTIN, LOW);    // turn the LED off by making the voltage LOW

  if (digitalRead(SW2) != oldSW2)
  {
    if (digitalRead(SW2) == 0)
    {
      activeDirection = !activeDirection;
      //    Serial.println(activeDirection);
      //    Serial.println("\t\tSW2 on");
    }
    oldSW2 = digitalRead(SW2);
  }
}

// the setup function runs once when you press reset or power the board
void setup() {
  // initialize digital pin LED_BUILTIN as an output.
  pinMode(LED_BUILTIN, OUTPUT);
  pinMode(EN, OUTPUT);
  pinMode(STEP1, OUTPUT);
  pinMode(DIR1, OUTPUT);
  pinMode(STEP2, OUTPUT);
  pinMode(DIR2, OUTPUT);
  pinMode(STEP3, OUTPUT);
  pinMode(DIR3, OUTPUT);

  pinMode(SW1, INPUT_PULLUP);
  pinMode(SW2, INPUT_PULLUP);

  // attachInterrupt(digitalPinToInterrupt(SW1), isrSW1, CHANGE);
  //  attachInterrupt(digitalPinToInterrupt(SW2), isrSW2, CHANGE);

  // attachInterrupt(SW1, isrSW1, CHANGE);
  // attachInterrupt(SW2, isrSW2, CHANGE);

  oldSW1 = digitalRead(SW1);
  newSW1 = digitalRead(SW1);
  oldSW2 = digitalRead(SW2);

  Serial.begin(115200);
  // reserve 200 bytes for the inputString:
  inputString.reserve(200);
  Serial.println("Ready...");
}

// the loop function runs over and over again forever
void loop()
{
  //  digitalWrite(LED_BUILTIN, HIGH);   // turn the LED on (HIGH is the voltage level)
  //  delay(100);                       // wait for a second
  //  digitalWrite(LED_BUILTIN, LOW);    // turn the LED off by making the voltage LOW
  //  delay(100);                       // wait for a second

  //  digitalWrite(EN, HIGH);   // turn the LED on (HIGH is the voltage level)
  //  delay(1);                       // wait for a second
  //  digitalWrite(EN, LOW);    // turn the LED off by making the voltage LOW
  //  delay(1);
  //  digitalWrite(EN, HIGH);   // turn the LED on (HIGH is the voltage level)
  //  delay(1);                       // wait for a second
  //  digitalWrite(EN, LOW);    // turn the LED off by making the voltage LOW
  //  delay(1);

  if (flgMoveMotor)
  {
    move_stepper(1, activeDirection);
    flgMoveMotor = false;
  }

  if (digitalRead(SW1) != oldSW1)
  {
    if (digitalRead(SW1) == 0)
    {
      activeDirection = !activeDirection;
    }
    oldSW1 = digitalRead(SW1);
  }

  if (digitalRead(SW2) != oldSW2)
  {
    if (digitalRead(SW2) == 0)
    {
      activeDirection = !activeDirection;
    }
    oldSW2 = digitalRead(SW2);
  }

  // print the string when a newline arrives:
  if (flgStringComplete) {
    Serial.println(inputString);

    if (inputString == "1") {
      activeDirection = !activeDirection;
    }

    if (inputString == "g") {
      flgMoveMotor = true;
    }

    if (inputString == "s") {
      flgMoveMotor = false;
    }

    // clear the string:
    inputString = "";
    flgStringComplete = false;
  }

}

void move_stepper(int stepper, int direction)
{
  int i;
  digitalWrite(EN, 0);
  if (stepper == 1)
  {
    //Serial.println("motor1  ");
    digitalWrite(DIR1, direction);
    digitalWrite(STEP1, 0);
    for (i = 0; i < 10000; i++)
      //   while ((digitalRead(SW1) == oldSW1) && (digitalRead(SW2) == oldSW2))
    {
      delayMicroseconds(13);
      if (digitalRead(SW1) != oldSW1)
        break;
      digitalWrite(STEP1, 1);

      delayMicroseconds(13);
      if (digitalRead(SW2) != oldSW2)
        break;
      digitalWrite(STEP1, 0);
    }
  }

  if (stepper == 2)
  {
    Serial.println("motor2  ");
    digitalWrite(DIR2, direction);
    digitalWrite(STEP2, 0);
    for (int i = 0; i < 500; i++)
    {
      delay(1);
      digitalWrite(STEP2, 1);
      delay(1);
      digitalWrite(STEP2, 0);
    }
  }

  if (stepper == 3)
  {
    Serial.println("motor3  ");
    digitalWrite(DIR3, direction);
    digitalWrite(STEP3, 0);
    for (int i = 0; i < 500; i++)
    {
      delay(1);
      digitalWrite(STEP3, 1);
      delay(1);
      digitalWrite(STEP3, 0);
    }
  }
  digitalWrite(EN, 1);
}


/*
  SerialEvent occurs whenever a new data comes in the hardware serial RX. This
  routine is run between each time loop() runs, so using delay inside loop can
  delay response. Multiple bytes of data may be available.
*/
void serialEvent() {
  while (Serial.available())
  {
    // get the new byte:
    char inChar = (char)Serial.read();
    if (inChar == '\n') {
      // if the incoming character is a newline, set a flag so the main loop can
      // do something about it:
      flgStringComplete = true;
    } else {
      // add it to the inputString:
      inputString += inChar;
    }
  }
}
