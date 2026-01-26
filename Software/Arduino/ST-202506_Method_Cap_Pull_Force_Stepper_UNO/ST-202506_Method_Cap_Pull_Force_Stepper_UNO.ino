
/****************************************************************************
   ST-202506 Method Cap Open Force

   Using Arduino UNO
   with CNC stepper shield
*/


#define SPEED_CARRIAGE_US       400 // microsecond delay in step  2sec/ft
#define SPEED_CARRIAGE_JOG_US   400 // microsecond delay in step

#define SERIAL_CMD_JOG_CNT      200;  // how far to jog when serial command is recvd
#define STATE_CARRIAGE_TIMEOUT_CNT  3000  // max count that a carriage state will run untilautomatically moving to next state

#define ENABLE            8   // Enable
#define CARRIAGE_STEP     2   // X step
#define CARRIAGE_DIR      5   // X dir
#define CARRIAGE_STOP_UP  3   // Y Step (brown wire) 
#define CARRIAGE_STOP_DN  6   // Y Dir (blue wire) 
#define CARRIAGE_JOG_UP   11  // Z-limit switch (white wire) 
#define CARRIAGE_JOG_DN   10  // Y-limit switch (orange wire)

#define START_SWITCH      9   // X-limit switch (purple wire)

typedef enum {
  DIR_CCW = 0,
  DIR_CW,
  DIR_LF = 0,
  DIR_RT,
  DIR_UP = 0,
  DIR_DN,
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

  STATE_CARRIAGE_PB_JOG_UP_START,
  STATE_CARRIAGE_PB_JOG_UP_CNT,
  STATE_CARRIAGE_PB_JOG_UP_STOP,
  STATE_CARRIAGE_PB_JOG_DN_START,
  STATE_CARRIAGE_PB_JOG_DN_CNT,
  STATE_CARRIAGE_PB_JOG_DN_STOP,

  STATE_CARRIAGE_SERIAL_JOG_UP_START,
  STATE_CARRIAGE_SERIAL_JOG_UP_CNT,
  STATE_CARRIAGE_SERIAL_JOG_UP_STOP,
  STATE_CARRIAGE_SERIAL_JOG_DN_START,
  STATE_CARRIAGE_SERIAL_JOG_DN_CNT,
  STATE_CARRIAGE_SERIAL_JOG_DN_STOP,

  NUM_OF_STATES
} STATE_SYSTEM;
STATE_SYSTEM currentState = STATE_STATUS;//STATE_WAIT_FOR_START;

int incomingByte = 0; // for incoming serial data
uint16_t stateCnt = 0;//STATE_SPRAY_TIMEOUT_CNT;
unsigned long lastMillis;


/////////////////////////////////////////////////////////////////////////////////////////////////
#define ON  1
#define OFF 0
#define DIRECTION_EXTEND 3
#define DIRECTION_RETRACT 2
#define DIRECTION_STOP 0

#define CNT_LOCKUP_TIMEOUT 10 // time out to prevent code lock when destination cannot be reached. 
#define CNT_FOR_TEST_EXTEND_STATE 1   // number of state machine cycles to use for test extend duration
#define CNT_FOR_TEST_RETRACT_STATE 1  // number of state machine cycles to use for test retract duration

#define MAX_NUM_OF_CYCLES        9999
#define MAX_SEC_CYCLE_HOLD       9999
#define MAX_SEC_CYCLE_HOME_HOLD  9999

#define CNT_TIMEOUT 1000


String inputString = "";         // a string to hold incoming data
boolean flgFlashValChange = false;  // whether the flash values have changed
boolean flgUpdateDisplay = false;
boolean flgUpdateDisplayDistance = false;
boolean flgFindTargetLocation = false;
boolean flgFoundTargetLocation = false;
boolean flgWaitRunningNotificationChange = false;
boolean flgWaitRunningNotificationStatus = false;
boolean flgWaitHoldingSqueezeNotificationChange = false;
boolean flgWaitHoldingSqueezeNotificationStatus = false;
boolean flgWaitHoldingHomeNotificationChange = false;
boolean flgWaitHoldingHomeNotificationStatus = false;
boolean flgCycleCountChange = false;
boolean flgCycleRunningChange = false;
boolean flgCycleRunningStatus = false;
boolean flgTimeOutErrorChange = false;
boolean flgTimeOutErrorStatus = false;
boolean flgLimitErrorChange = false;
boolean flgLimitErrorStatus = false;
boolean flgTestFlashing = true;
boolean flgUpdateui500ms = false;
boolean flgWaitHoldCountChange = false;

//unsigned int driveDirection = DIRECTION_STOP;
int cntActiveState;
unsigned int cntActiveCycles;
unsigned int cntConnection = 0;

int cycleHomeHoldTime_sec = 3;  //default
int cycleHoldTime_sec = 2; //default
uint16_t numOfCycles = 5;  // default
uint16_t cycleHomeA2D = 94;  // default
uint16_t cycleA2D = 58;// default
uint16_t fullRetractedA2D = 129; // default  // A2D reading where 90mmis at retracted position
uint16_t fullExtendedA2D = 22; // default  // A2D reading where 0mm is at extended position
int cycleOffsetGoal = 5;
int rateOfMovement = 9;  // 1 - 9 where 1 is slowest and 9 is full on
boolean flgShowDebugMessages = true;
boolean flgDirectDriveToTarget = false;
unsigned int directDriveRange = 2;  // +/- A2D range to find loaction target in
unsigned int unitSerialNumber = 0;

int rateOfMovementCnt = 0;

char strUnitSerialNumber[10] = "SN:0000";
int cycleMappedFromHome;  // cycle A2D value mapped to  mm from home location
int cycleMappedFull;  // cycle A2D value mapped to full mm
int cycleHomeMappedFull;  //home A2D value mapped to full mm
//int ActiveState = DRIVE_OFF_STATE;
//unsigned long cntNoLockup = CNT_LOCKUP_TIMEOUT;
uint32_t lastCheck = 0;
//uint32_t ui_lastCheck = 0;
//uint32_t ui_lastErrorCheck = 0;

//byte Rcnt = 0;
//char BTInChar[10];
uint16_t sensorValue = 0;        // value read from the pot
int locationValue  = 0;
uint16_t targetSensorValue = 0xFFFF;
uint16_t sensorValueLast = 0;    // save the last reading from the pot
uint16_t outputValue = 0;        // value output to the PWM (analog out)
int lastValue = 0;
int lastValueCnt = 0;// CNT_TIMEOUT;

bool flgUpperDetected = false;
bool flgLowerDetected = false;
bool flgPumpOn = false;
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void setup() {
  Serial.begin(115200);
  Serial.println("ST-202506 Method Cap Open Force");
  Serial.println("Send '?' to querry the status");

  Serial.println("Ready....");

  pinMode(ENABLE, OUTPUT);
  pinMode(CARRIAGE_STEP, OUTPUT);
  pinMode(CARRIAGE_DIR, OUTPUT);

  pinMode(CARRIAGE_STOP_UP, INPUT_PULLUP);
  pinMode(CARRIAGE_STOP_DN, INPUT_PULLUP);
  pinMode(START_SWITCH, INPUT_PULLUP);

  pinMode(CARRIAGE_JOG_UP, INPUT_PULLUP);
  pinMode(CARRIAGE_JOG_DN, INPUT_PULLUP);

  digitalWrite(ENABLE, 1);
}


void loop() {

  switch (currentState)
  {
    case STATE_STATUS:
      digitalWrite(ENABLE, 1);

      Serial.println("\r\nStatus:");
      Serial.print("\t Carriage Down Stop Sensor (brown wire): "); Serial.println(digitalRead(CARRIAGE_STOP_DN));
      Serial.print("\t Carriage Up Stop Sensor (blue wire): "); Serial.println(digitalRead(CARRIAGE_STOP_UP));
      Serial.print("\t Carriage Jog Down Button (white wire): "); Serial.println(digitalRead(CARRIAGE_JOG_DN));
      Serial.print("\t Carriage Jog Up Button (orange wire): "); Serial.println(digitalRead(CARRIAGE_JOG_UP));

      Serial.print("\t Start Button (purple wire): "); Serial.println(digitalRead(START_SWITCH));
      Serial.print("\t Current State : "); Serial.println(currentState);

      // status for Visual Studio intreface
      Serial.print("?,");
      Serial.print(numOfCycles, DEC); Serial.print(",");
      Serial.println("?");

      // remove theses three commecnts to make status show until key is entered 
      //Serial.println(); Serial.println("Send Any key to exit status loop");
      //delay(1000);
      //while ((Serial.available()) && (--stateCnt > 0))
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
     
      serialEvent();

      if (digitalRead(START_SWITCH) == LOW)
      {
        currentState = STATE_CARRIAGE_START;
        stateCnt = STATE_CARRIAGE_TIMEOUT_CNT;
        cntActiveCycles = 0;
        Serial.println("Test Starting - Going to Start Carriage Cycle");
      }

      if (digitalRead(CARRIAGE_JOG_DN) == LOW)
      {
        Serial.println("Carriage jog down (from pb switch)");
        currentState = STATE_CARRIAGE_PB_JOG_DN_START;
      }

      if (digitalRead(CARRIAGE_JOG_UP) == LOW)
      {
        Serial.println("Carriage jog up (from pb switch)");
        currentState = STATE_CARRIAGE_PB_JOG_UP_START;
      }
      break;

    case STATE_CARRIAGE_START:
      digitalWrite(ENABLE, 0);
      digitalWrite(CARRIAGE_DIR, DIR_UP);

      digitalWrite(CARRIAGE_STEP, HIGH);
      delayMicroseconds(SPEED_CARRIAGE_US);
      digitalWrite(CARRIAGE_STEP, LOW);
      delayMicroseconds(SPEED_CARRIAGE_US);
      lastMillis = millis();

      if ((digitalRead(CARRIAGE_STOP_UP) == HIGH) || (--stateCnt == 0))
      {
        if (stateCnt == 0)
          Serial.println("TIMEOUT REACHED - Carriage Up sensor never went HIGH (open)");
        currentState = STATE_CARRIAGE_TO_END_SW;
        stateCnt = STATE_CARRIAGE_TIMEOUT_CNT;
        Serial.println("CLR");
        Serial.println("Going to Move Carriage to Up Position");
      }
      break;

    case STATE_CARRIAGE_TO_END_SW:
      digitalWrite(CARRIAGE_STEP, HIGH);
      delayMicroseconds(SPEED_CARRIAGE_US);
      digitalWrite(CARRIAGE_STEP, LOW);
      delayMicroseconds(SPEED_CARRIAGE_US);

      if ((digitalRead(CARRIAGE_STOP_UP) == LOW) || (--stateCnt == 0))
      {
        Serial.println(millis() - lastMillis);
        Serial.println(stateCnt);
        if (stateCnt == 0)
          Serial.println("TIMEOUT REACHED - Carriage Up sensor never went LOW (blocked)");
        currentState = STATE_CARRIAGE_RETURN_START;
        stateCnt = STATE_CARRIAGE_TIMEOUT_CNT;
        Serial.println("Going to Start Carriage Return");
      }
      break;

    case STATE_CARRIAGE_RETURN_START:
      digitalWrite(CARRIAGE_DIR, DIR_DN);

      digitalWrite(CARRIAGE_STEP, HIGH);
      delayMicroseconds(SPEED_CARRIAGE_US);
      digitalWrite(CARRIAGE_STEP, LOW);
      delayMicroseconds(SPEED_CARRIAGE_US);

      if ((digitalRead(CARRIAGE_STOP_DN) == HIGH) || (--stateCnt == 0))
      {
        if (stateCnt == 0)
          Serial.println("TIMEOUT REACHED - Carriage Down sensor never went HIGH (open)");
        currentState = STATE_CARRIAGE_TO_HOME_SW;
        stateCnt = STATE_CARRIAGE_TIMEOUT_CNT;
        Serial.println("Going to Move Carriage to Down Position");
      }
      break;


    case STATE_CARRIAGE_TO_HOME_SW:
      digitalWrite(CARRIAGE_STEP, HIGH);
      delayMicroseconds(SPEED_CARRIAGE_US);
      digitalWrite(CARRIAGE_STEP, LOW);
      delayMicroseconds(SPEED_CARRIAGE_US);

      if ((digitalRead(CARRIAGE_STOP_DN) == LOW) || (--stateCnt == 0))
      {
        if (stateCnt == 0)
          Serial.println("TIMEOUT REACHED - Carriage Down sensor never went LOW (blocked)");

        Serial.println("?PT");
        Serial.print("Test ");  Serial.print(cntActiveCycles+1 , DEC); Serial.print("/"); Serial.println(numOfCycles);
        if (++cntActiveCycles < numOfCycles )  //keep going
        {
          currentState = STATE_CARRIAGE_START;
          stateCnt = STATE_CARRIAGE_TIMEOUT_CNT;
          Serial.print("Cycles Left:"); Serial.println(numOfCycles-cntActiveCycles, DEC);
          Serial.println("Going to Start Carriage Cycle");
        }
        else // test cycle complete
        {       
          currentState = STATE_WAIT_FOR_START;
          stateCnt = STATE_CARRIAGE_TIMEOUT_CNT;
          Serial.println("Complete !");
          Serial.println("Going to wait for start button");
        }
      }
      break;

    // jog control from PD switch
    /////////////////////////////////////////////////////////////////////////////////
    case STATE_CARRIAGE_PB_JOG_UP_START:
      if (digitalRead(CARRIAGE_STOP_UP) == LOW)
        currentState = STATE_WAIT_FOR_START;
      else
      {
        if (digitalRead(CARRIAGE_JOG_UP) == LOW)
        {
          digitalWrite(ENABLE, 0);
          digitalWrite(CARRIAGE_DIR, DIR_UP);
          currentState = STATE_CARRIAGE_PB_JOG_UP_CNT;
        }
        else
          currentState = STATE_WAIT_FOR_START;
      }
      break;

    case STATE_CARRIAGE_PB_JOG_UP_CNT:
      if (digitalRead(CARRIAGE_STOP_UP) == LOW)
        currentState = STATE_WAIT_FOR_START;
      else
      {
        if (digitalRead(CARRIAGE_JOG_UP) == LOW)
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

    case STATE_CARRIAGE_PB_JOG_DN_START:
      if (digitalRead(CARRIAGE_STOP_DN) == LOW)
        currentState = STATE_WAIT_FOR_START;
      else
      {
        if (digitalRead(CARRIAGE_JOG_DN) == LOW)
        {
          digitalWrite(ENABLE, 0);
          digitalWrite(CARRIAGE_DIR, DIR_DN);
          currentState = STATE_CARRIAGE_PB_JOG_DN_CNT;
        }
        else
          currentState = STATE_WAIT_FOR_START;
      }
      break;

    case STATE_CARRIAGE_PB_JOG_DN_CNT:
      if (digitalRead(CARRIAGE_STOP_DN) == LOW)
        currentState = STATE_WAIT_FOR_START;
      else
      {
        if (digitalRead(CARRIAGE_JOG_DN) == LOW)
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

    // jog control from serial command
    /////////////////////////////////////////////////////////////////////////////////
    case STATE_CARRIAGE_SERIAL_JOG_UP_START:
      if (digitalRead(CARRIAGE_STOP_UP) == LOW)
        currentState = STATE_WAIT_FOR_START;
      else
      {
        digitalWrite(ENABLE, 0);
        digitalWrite(CARRIAGE_DIR, DIR_UP);

        digitalWrite(CARRIAGE_STEP, HIGH);
        delayMicroseconds(SPEED_CARRIAGE_JOG_US);
        digitalWrite(CARRIAGE_STEP, LOW);
        delayMicroseconds(SPEED_CARRIAGE_JOG_US);
        lastMillis = millis();

        stateCnt = SERIAL_CMD_JOG_CNT;

        if ((digitalRead(CARRIAGE_STOP_UP) == HIGH) || (--stateCnt == 0))
        {
          if (stateCnt == 0)
            Serial.println("TIMEOUT REACHED - Carriage Up sensor never went HIGH (open)");
          currentState = STATE_CARRIAGE_SERIAL_JOG_UP_CNT;

          Serial.println("Going to Jog Carriage to Up Position");
        }
      }
      break;

    case STATE_CARRIAGE_SERIAL_JOG_UP_CNT:
      if (digitalRead(CARRIAGE_STOP_UP) == LOW)
        currentState = STATE_WAIT_FOR_START;
      else
      {
        digitalWrite(CARRIAGE_STEP, HIGH);
        delayMicroseconds(SPEED_CARRIAGE_US);
        digitalWrite(CARRIAGE_STEP, LOW);
        delayMicroseconds(SPEED_CARRIAGE_US);
      }

      if ((digitalRead(CARRIAGE_STOP_UP) == LOW) || (--stateCnt == 0))
      {
        Serial.println(millis() - lastMillis);
        Serial.println(stateCnt);
        if (stateCnt == 0)
          Serial.println("TIMEOUT REACHED - Carriage Up sensor never went LOW (blocked)");

        currentState = STATE_WAIT_FOR_START;
        stateCnt = STATE_CARRIAGE_TIMEOUT_CNT;
        Serial.println("Going to wait for start button");
      }
      break;

    case STATE_CARRIAGE_SERIAL_JOG_DN_START:
      if (digitalRead(CARRIAGE_STOP_DN) == LOW)
        currentState = STATE_WAIT_FOR_START;
      else
      {
        digitalWrite(ENABLE, 0);
        digitalWrite(CARRIAGE_DIR, DIR_DN);

        digitalWrite(CARRIAGE_STEP, HIGH);
        delayMicroseconds(SPEED_CARRIAGE_JOG_US);
        digitalWrite(CARRIAGE_STEP, LOW);
        delayMicroseconds(SPEED_CARRIAGE_JOG_US);
        lastMillis = millis();

        stateCnt = SERIAL_CMD_JOG_CNT;

        if ((digitalRead(CARRIAGE_STOP_DN) == HIGH) || (--stateCnt == 0))
        {
          if (stateCnt == 0)
            Serial.println("TIMEOUT REACHED - Carriage Down sensor never went HIGH (open)");
          currentState = STATE_CARRIAGE_SERIAL_JOG_DN_CNT;

          Serial.println("Going to Jog Carriage to Down Position");
        }
      }

    case STATE_CARRIAGE_SERIAL_JOG_DN_CNT:
      if (digitalRead(CARRIAGE_STOP_DN) == LOW)
        currentState = STATE_WAIT_FOR_START;
      else
      {
        digitalWrite(CARRIAGE_STEP, HIGH);
        delayMicroseconds(SPEED_CARRIAGE_US);
        digitalWrite(CARRIAGE_STEP, LOW);
        delayMicroseconds(SPEED_CARRIAGE_US);
      }

      if ((digitalRead(CARRIAGE_STOP_DN) == LOW) || (--stateCnt == 0))
      {
        Serial.println(millis() - lastMillis);
        Serial.println(stateCnt);
        if (stateCnt == 0)
          Serial.println("TIMEOUT REACHED - Carriage Down sensor never went LOW (blocked)");

        currentState = STATE_WAIT_FOR_START;
        stateCnt = STATE_CARRIAGE_TIMEOUT_CNT;
        Serial.println("Going to wait for start button");
      }
      break;


    default:
      currentState = STATE_WAIT_FOR_START;
  }
}
