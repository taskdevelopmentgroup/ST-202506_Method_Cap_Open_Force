/****************************************************************************
   ST-202506 Method Cap Open Force

   Using Arduino UNO
   with CNC stepper shield
*/


//#define SPEED_SPRAY_US        300 // microsecond delay in step
#define SPEED_CARRIAGE_US       300 // microsecond delay in step  2sec/ft
//#define SPEED_SPRAY_JOG_US    500  // microsecond delay in step
#define SPEED_CARRIAGE_JOG_US   300 // microsecond delay in step

//#define STATE_SPRAY_TIMEOUT_CNT   2500  // max count that a spray state will run untilautomatically moving to next state
#define STATE_CARRIAGE_TIMEOUT_CNT  3800  // max count that a carriage state will run untilautomatically moving to next state

#define ENABLE            8   // Enable
#define CARRIAGE_STEP     2   // X step
#define CARRIAGE_DIR      5   // X dir
//#define SPRAY_STEP        4   // Z step
//#define SPRAY_DIR         7   // Z dir
//#define CARRIAGE_STOP     3   // Y step (brown wire)
#define CARRIAGE_STOP_RT  3   // Y Step (brown wire) 
#define CARRIAGE_STOP_LF  6   // Y Dir (blue wire) 
#define CARRIAGE_JOG_RT   11  // Z-limit switch (white wire) 
#define CARRIAGE_JOG_LF   10  // Y-limit switch (orange wire)
//#define SPRAY_STOP_UP     A0  // CoolEn (blue wire)
//#define SPRAY_STOP_DN     A3  // Abort (brown wire)

//#define SPRAY_JOG_UP      A1  // Hold (white wire)
//#define SPRAY_JOG_DN      A2  // Resume (orange wire)
#define START_SWITCH      9   // X-limit switch (purple wire)

typedef enum {
  DIR_CCW = 0,
  DIR_CW,
  DIR_LF = 0,
  DIR_RT,
  DIR_DN = 0,
  DIR_UP,
  NUM_OF_DIRS
} DIR;      // set direction, HIGH for clockwise, LOW for anticlockwise

typedef enum {
  STATE_OFF = 0,
  STATE_STATUS,
  STATE_WAIT_FOR_START,
  STATE_CARRIAGE_HOME,
  STATE_CARRIAGE_START,
  STATE_CARRIAGE_TO_END_SW,
  STATE_CARRIAGE_RETURN_START,
  STATE_CARRIAGE_TO_HOME_SW,

//  STATE_SPRAY_WAIT_FOR_START,
//  STATE_SPRAY_HOME,
////  STATE_SPRAY_START,
//  STATE_SPRAY_TO_END_DN,
////  STATE_SPRAY_RETURN_START,
//  STATE_SPRAY_TO_HOME_UP,

  STATE_CARRIAGE_JOG_RT_START,
  STATE_CARRIAGE_JOG_RT_CNT,
  STATE_CARRIAGE_JOG_RT_STOP,
  STATE_CARRIAGE_JOG_LF_START,
  STATE_CARRIAGE_JOG_LF_CNT,
  STATE_CARRIAGE_JOG_LF_STOP,
//  STATE_SPRAY_JOG_UP_START,
//  STATE_SPRAY_JOG_UP_CNT,
//  STATE_SPRAY_JOG_UP_STOP,
//  STATE_SPRAY_JOG_DN_START,
//  STATE_SPRAY_JOG_DN_CNT,
//  STATE_SPRAY_JOG_DN_STOP,
  NUM_OF_STATES
} STATE_SYSTEM;
STATE_SYSTEM currentState = STATE_WAIT_FOR_START;

int incomingByte = 0; // for incoming serial data
uint16_t stateCnt = 0;//STATE_SPRAY_TIMEOUT_CNT;
unsigned long lastMillis;

void setup() {
  Serial.begin(115200);
  Serial.println("ST-202506 Method Cap Open Force");
  Serial.println("Send '?' to querry the status");

  Serial.println("Ready....");

  pinMode(ENABLE, OUTPUT);
  pinMode(CARRIAGE_STEP, OUTPUT);
  pinMode(CARRIAGE_DIR, OUTPUT);
//  pinMode(SPRAY_STEP, OUTPUT);
//  pinMode(SPRAY_DIR, OUTPUT);

  pinMode(CARRIAGE_STOP_RT, INPUT_PULLUP);
  pinMode(CARRIAGE_STOP_LF, INPUT_PULLUP);
//  pinMode(SPRAY_STOP_UP, INPUT_PULLUP);
//  pinMode(SPRAY_STOP_DN, INPUT_PULLUP);
  pinMode(START_SWITCH, INPUT_PULLUP);

//  pinMode(SPRAY_JOG_UP, INPUT_PULLUP);
//  pinMode(SPRAY_JOG_DN, INPUT_PULLUP);

  pinMode(CARRIAGE_JOG_RT, INPUT_PULLUP);
  pinMode(CARRIAGE_JOG_LF, INPUT_PULLUP);

  digitalWrite(ENABLE, 1);
}


void loop() {

  switch (currentState)
  {
    case STATE_STATUS:
      digitalWrite(ENABLE, 1);

      while (Serial.available())
      {
        incomingByte = Serial.read();
      }

      Serial.println("\r\nStatus:");
      //Serial.print("\t Spray Up Stop Sensor (blue wire): "); Serial.println(digitalRead(SPRAY_STOP_UP));
     // Serial.print("\t Spray Down Stop Sensor (brown wire): "); Serial.println(digitalRead(SPRAY_STOP_DN));
     // Serial.print("\t Spray Jog Up Button (white wire): "); Serial.println(digitalRead(SPRAY_JOG_UP));
      //Serial.print("\t Spray Jog Down Button (orange wire): "); Serial.println(digitalRead(SPRAY_JOG_DN));
      //Serial.println("");
      Serial.print("\t Carriage Right Stop Sensor (brown wire): "); Serial.println(digitalRead(CARRIAGE_STOP_RT));
      Serial.print("\t Carriage Left Stop Sensor (blue wire): "); Serial.println(digitalRead(CARRIAGE_STOP_LF));
      Serial.print("\t Carriage Jog Right Button (white wire): "); Serial.println(digitalRead(CARRIAGE_JOG_RT));
      Serial.print("\t Carriage Jog Left Button (orange wire): "); Serial.println(digitalRead(CARRIAGE_JOG_LF));

      Serial.print("\t Start Button (purple wire): "); Serial.println(digitalRead(START_SWITCH));
      Serial.print("\t Current State : "); Serial.println(currentState);

      Serial.println(); Serial.println("Send Any key to exit status loop");
      delay(1000);
      while ((Serial.available()) && (--stateCnt > 0))
      {
        incomingByte = Serial.read();
        Serial.println(incomingByte);
        Serial.println(stateCnt);
        currentState = STATE_WAIT_FOR_START;
        Serial.println("Going to wait for start button state");
      }

      break;

    case STATE_WAIT_FOR_START:
      digitalWrite(ENABLE, 1);

      while (Serial.available()) {
        incomingByte = Serial.read();
        Serial.println(incomingByte);

        if (incomingByte == '?')
          currentState = STATE_STATUS;
      }


      if (digitalRead(START_SWITCH) == LOW)
      {
        currentState = STATE_CARRIAGE_START;
        stateCnt = STATE_CARRIAGE_TIMEOUT_CNT;
        Serial.println("Going to Start Carriage");
      }
/*
      if (digitalRead(SPRAY_JOG_UP) == LOW)
      {
        Serial.println("Spray jog up");
        currentState = STATE_SPRAY_JOG_UP_START;
      }

      if (digitalRead(SPRAY_JOG_DN) == LOW)
      {
        Serial.println("Spray jog down");
        currentState = STATE_SPRAY_JOG_DN_START;
      }
*/
      if (digitalRead(CARRIAGE_JOG_RT) == LOW)
      {
        Serial.println("Carriage jog right");
        currentState = STATE_CARRIAGE_JOG_RT_START;
      }

      if (digitalRead(CARRIAGE_JOG_LF) == LOW)
      {
        Serial.println("Carriage jog left");
        currentState = STATE_CARRIAGE_JOG_LF_START;
      }
      break;
/*
    case STATE_SPRAY_START:
      digitalWrite(ENABLE, 0);
      digitalWrite(SPRAY_DIR, DIR_DN);

      digitalWrite(SPRAY_STEP, HIGH);
      delayMicroseconds(SPEED_SPRAY_US);
      digitalWrite(SPRAY_STEP, LOW);
      delayMicroseconds(SPEED_SPRAY_US);

      if ((digitalRead(SPRAY_STOP_UP) == HIGH)  || (--stateCnt == 0))
      {
        if (stateCnt == 0)
          Serial.println("TIMEOUT REACHED - Spray Upper sensor never when HIGH(open)");
        currentState = STATE_SPRAY_TO_END_DN;
        stateCnt = STATE_SPRAY_TIMEOUT_CNT;
        Serial.println("Going to Move Spray to Down Position");

      }
      break;

    case STATE_SPRAY_TO_END_DN:
      digitalWrite(SPRAY_STEP, HIGH);
      delayMicroseconds(SPEED_SPRAY_US);
      digitalWrite(SPRAY_STEP, LOW);
      delayMicroseconds(SPEED_SPRAY_US);

      if ((digitalRead(SPRAY_STOP_DN) == HIGH)  || (--stateCnt == 0))
      {
        Serial.println(stateCnt);
        if (stateCnt == 0)
          Serial.println("TIMEOUT REACHED - Spray Lower sensor never when HIGH(open)");
        currentState = STATE_CARRIAGE_START;
        stateCnt = STATE_CARRIAGE_TIMEOUT_CNT;
        Serial.println("Going to Start Carriage");
      }
      break;
*/
    case STATE_CARRIAGE_START:
      digitalWrite(CARRIAGE_DIR, DIR_RT);

      digitalWrite(CARRIAGE_STEP, HIGH);
      delayMicroseconds(SPEED_CARRIAGE_US);
      digitalWrite(CARRIAGE_STEP, LOW);
      delayMicroseconds(SPEED_CARRIAGE_US);
      lastMillis = millis();

      if ((digitalRead(CARRIAGE_STOP_LF) == HIGH) || (--stateCnt == 0))
      {
        if (stateCnt == 0)
          Serial.println("TIMEOUT REACHED - Carriage Left sensor never went HIGH(open)");
        currentState = STATE_CARRIAGE_TO_END_SW;
        stateCnt = STATE_CARRIAGE_TIMEOUT_CNT;
        Serial.println("Going to Move Carriage to Right Position");
      }
      break;

    case STATE_CARRIAGE_TO_END_SW:
      digitalWrite(CARRIAGE_STEP, HIGH);
      delayMicroseconds(SPEED_CARRIAGE_US);
      digitalWrite(CARRIAGE_STEP, LOW);
      delayMicroseconds(SPEED_CARRIAGE_US);

      if ((digitalRead(CARRIAGE_STOP_RT) == LOW) || (--stateCnt == 0))
      {
        Serial.println(millis()-lastMillis);
        Serial.println(stateCnt);
        if (stateCnt == 0)
          Serial.println("TIMEOUT REACHED - Carriage Right sensor never went LOW(blocked)");
        currentState = STATE_CARRIAGE_RETURN_START;
        stateCnt = STATE_CARRIAGE_TIMEOUT_CNT;
        Serial.println("Going to Start Carriage Return");
      }
      break;
/*
    case STATE_SPRAY_RETURN_START:
      digitalWrite(SPRAY_DIR, DIR_UP);

      digitalWrite(SPRAY_STEP, HIGH);
      delayMicroseconds(SPEED_SPRAY_US);
      digitalWrite(SPRAY_STEP, LOW);
      delayMicroseconds(SPEED_SPRAY_US);

      if ((digitalRead(SPRAY_STOP_DN) == LOW) || (--stateCnt == 0))
      {
        if (stateCnt == 0)
          Serial.println("TIMEOUT REACHED - Spray Down sensor never went LOW(blocked)");
        currentState = STATE_SPRAY_TO_HOME_UP;
        stateCnt = STATE_SPRAY_TIMEOUT_CNT;
        Serial.println("Going to Move Spray to Up Position");
      }
      break;


    case STATE_SPRAY_TO_HOME_UP:
      digitalWrite(SPRAY_STEP, HIGH);
      delayMicroseconds(SPEED_SPRAY_US);
      digitalWrite(SPRAY_STEP, LOW);
      delayMicroseconds(SPEED_SPRAY_US);

      if ((digitalRead(SPRAY_STOP_UP) == LOW) || (--stateCnt == 0))
      {
        if (stateCnt == 0)
          Serial.println("TIMEOUT REACHED - Spray UP sensor never went LOW(blocked)");
        currentState = STATE_CARRIAGE_RETURN_START;
        stateCnt = STATE_CARRIAGE_TIMEOUT_CNT;
        Serial.println("Going to Start Carriage Return");
      }
      break;
*/
    case STATE_CARRIAGE_RETURN_START:
      digitalWrite(CARRIAGE_DIR, DIR_LF);

      digitalWrite(CARRIAGE_STEP, HIGH);
      delayMicroseconds(SPEED_CARRIAGE_US);
      digitalWrite(CARRIAGE_STEP, LOW);
      delayMicroseconds(SPEED_CARRIAGE_US);

      if ((digitalRead(CARRIAGE_STOP_RT) == HIGH) || (--stateCnt == 0))
      {
        if (stateCnt == 0)
          Serial.println("TIMEOUT REACHED - Carriage Right sensor never went HIGH(open)");
        currentState = STATE_CARRIAGE_TO_HOME_SW;
        stateCnt = STATE_CARRIAGE_TIMEOUT_CNT;
        Serial.println("Going to Move Carriage to Left Position");
      }
      break;


    case STATE_CARRIAGE_TO_HOME_SW:
      digitalWrite(CARRIAGE_STEP, HIGH);
      delayMicroseconds(SPEED_CARRIAGE_US);
      digitalWrite(CARRIAGE_STEP, LOW);
      delayMicroseconds(SPEED_CARRIAGE_US);

      if ((digitalRead(CARRIAGE_STOP_LF) == LOW) || (--stateCnt == 0))
      {
        if (stateCnt == 0)
          Serial.println("TIMEOUT REACHED - Carriage Left sensor never went LOW(blocked)");
        currentState = STATE_WAIT_FOR_START;
        stateCnt = STATE_CARRIAGE_TIMEOUT_CNT;
        Serial.println("Going to wait for start button");
      }
      break;
/*
    case STATE_SPRAY_JOG_UP_START:
      if (digitalRead(SPRAY_STOP_UP) == LOW)
        currentState = STATE_WAIT_FOR_START;
      else
      {
        if (digitalRead(SPRAY_JOG_UP) == LOW)
        {
          digitalWrite(ENABLE, 0);
          digitalWrite(SPRAY_DIR, DIR_UP);
          currentState = STATE_SPRAY_JOG_UP_CNT;
        }
        else
          currentState = STATE_WAIT_FOR_START;
      }
      break;

    case STATE_SPRAY_JOG_UP_CNT:
      if (digitalRead(SPRAY_STOP_UP) == LOW)
        currentState = STATE_WAIT_FOR_START;
      else
      {
        if (digitalRead(SPRAY_JOG_UP) == LOW)
        {
          digitalWrite(SPRAY_STEP, HIGH);
          delayMicroseconds(SPEED_SPRAY_JOG_US);
          digitalWrite(SPRAY_STEP, LOW);
          delayMicroseconds(SPEED_SPRAY_JOG_US);
        }
        else
          currentState = STATE_WAIT_FOR_START;
      }
      break;

    case STATE_SPRAY_JOG_DN_START:
      if (digitalRead(SPRAY_STOP_DN) == HIGH)
        currentState = STATE_WAIT_FOR_START;
      else
      {
        if (digitalRead(SPRAY_JOG_DN) == LOW)
        {
          digitalWrite(ENABLE, 0);
          digitalWrite(SPRAY_DIR, DIR_DN);
          currentState = STATE_SPRAY_JOG_DN_CNT;
        }
        else
          currentState = STATE_WAIT_FOR_START;
      }
      break;

    case STATE_SPRAY_JOG_DN_CNT:
      if (digitalRead(SPRAY_STOP_DN) == HIGH)
        currentState = STATE_WAIT_FOR_START;
      else
      {
        if (digitalRead(SPRAY_JOG_DN) == LOW)
        {
          digitalWrite(SPRAY_STEP, HIGH);
          delayMicroseconds(SPEED_SPRAY_JOG_US);
          digitalWrite(SPRAY_STEP, LOW);
          delayMicroseconds(SPEED_SPRAY_JOG_US);
        }
        else
          currentState = STATE_WAIT_FOR_START;
      }
      break;
*/
    case STATE_CARRIAGE_JOG_RT_START:
      if (digitalRead(CARRIAGE_STOP_RT) == LOW)
        currentState = STATE_WAIT_FOR_START;
      else
      {
        if (digitalRead(CARRIAGE_JOG_RT) == LOW)
        {
          digitalWrite(ENABLE, 0);
          digitalWrite(CARRIAGE_DIR, DIR_RT);
          currentState = STATE_CARRIAGE_JOG_RT_CNT;
        }
        else
          currentState = STATE_WAIT_FOR_START;
      }
      break;

    case STATE_CARRIAGE_JOG_RT_CNT:
      if (digitalRead(CARRIAGE_STOP_RT) == LOW)
        currentState = STATE_WAIT_FOR_START;
      else
      {
        if (digitalRead(CARRIAGE_JOG_RT) == LOW)
        {
          digitalWrite(CARRIAGE_STEP, HIGH);
          delayMicroseconds(SPEED_CARRIAGE_JOG_US);
          digitalWrite(CARRIAGE_STEP, LOW);
          delayMicroseconds(SPEED_CARRIAGE_JOG_US);
        }
        else
          currentState = STATE_WAIT_FOR_START;
      }
      break;

    case STATE_CARRIAGE_JOG_LF_START:
      if (digitalRead(CARRIAGE_STOP_LF) == LOW)
        currentState = STATE_WAIT_FOR_START;
      else
      {
        if (digitalRead(CARRIAGE_JOG_LF) == LOW)
        {
          digitalWrite(ENABLE, 0);
          digitalWrite(CARRIAGE_DIR, DIR_LF);
          currentState = STATE_CARRIAGE_JOG_LF_CNT;
        }
        else
          currentState = STATE_WAIT_FOR_START;
      }
      break;

    case STATE_CARRIAGE_JOG_LF_CNT:
      if (digitalRead(CARRIAGE_STOP_LF) == LOW)
        currentState = STATE_WAIT_FOR_START;
      else
      {
        if (digitalRead(CARRIAGE_JOG_LF) == LOW)
        {
          digitalWrite(CARRIAGE_STEP, HIGH);
          delayMicroseconds(SPEED_CARRIAGE_JOG_US);
          digitalWrite(CARRIAGE_STEP, LOW);
          delayMicroseconds(SPEED_CARRIAGE_JOG_US);
        }
        else
          currentState = STATE_WAIT_FOR_START;
      }
      break;
  }
}
