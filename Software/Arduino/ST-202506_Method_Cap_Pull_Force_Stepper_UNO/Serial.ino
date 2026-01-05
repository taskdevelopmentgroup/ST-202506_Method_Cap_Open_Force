
/*
  SerialEvent occurs whenever a new data comes in the
  hardware serial RX.  This routine is run between each
  time loop() runs, so using delay inside loop can delay
  response.  Multiple bytes of data may be available.
*/

void serialEvent() {


  /* valid serial commands
         'k' = start the cycle
         'x' = reply with the postion of the 10K pot - 0mm to 90mm
         'f' = step extend
         'r' = step  retract
         'c' = drive to cycle postion
         'h' = drive to cycle home position
         '>' = drive to fully extended 0mm
         '<' = drive to fully retracted 90mm
         '{' = quick step extend
         '}' = quick step retract
         's' = set relays to stop state
         'o' = take analog reading and set as poistion for full extended location 0mm
         'O' = take analog reading and set as poistion for full retracted location 90mm
         'C' = take analog reading and set as position for cycle location (squeeze)
         'H' = take analog reading and set as poistion for cycle home location (Home)
         'nD' = set to show the  debug messaging , n = 0 OFF, else ON
         'n_' = set to direct drive to target location , n = 0 OFF, else ON
         'nn=' = set the driect drive to target location +/- range
         'nnnny = cycle count nnnnn = number of cycles 1 to 9999
         'nnnnt = retracted cycle home hold time, nn = 0 to 9999 sec
         'nnnnm = extended cycle hold time, nn =  0to 9999 sec
         'nnnb = cycle retracted (home) position, nnn =  0 to 90
         'nnne = cycle extended (squeeze) postion, nnn =  0 to 90
         'nnn+ = goto extended distance from home, nnn = 0 to 90
         'nnn- = goto retected distance from home, nnn = 0 to 90
         'nnnd' = set rate of movement for extended, nnn = 001 to 009
         'nnnna' = set the unit serial number, nnnn = 0000 to 9999
  */


  while (Serial.available())
  {
    // get the new byte:
    char inChar = (char)Serial.read();
    //    Serial.print(inChar);  //echo debug

    if (inChar == 'k')   // start a cycle
    {
      if (currentState == STATE_WAIT_FOR_START)
      {
        Serial.println("Carriage Cycle Start (from serial cmd 'k' )");
        cntActiveCycles = 0;
        currentState = STATE_CARRIAGE_START;
        stateCnt = STATE_CARRIAGE_TIMEOUT_CNT;
        Serial.println("Test Starting - Going to Start Carriage Cycle");
      }
      inputString = "";
    }

    else if (inChar == 'y')    // get the number of cycles to complete 1 - 9999
    {
      if (currentState == STATE_WAIT_FOR_START)
      {
        unsigned long val = inputString.toInt();
        if (val < 1)
        {
          Serial.println("ERROR - Number too small < 1; setting to 1");
          numOfCycles = 1;
        }
        else if (val > MAX_NUM_OF_CYCLES)
        {
          Serial.println("ERROR - Number too large > 9999; setting to 9999");
          numOfCycles = MAX_NUM_OF_CYCLES;
        }
        else
        {
          numOfCycles = val;
        }

        flgFlashValChange = true;
      }
      inputString = "";
    }

    else if (inChar == '>')
    {
      if (currentState == STATE_WAIT_FOR_START)
      {
        Serial.println("Carriage jog down (from serial cmd '>' )");
        currentState = STATE_CARRIAGE_SERIAL_JOG_DN_START;
      }
      inputString = "";
    }

    else if (inChar == '<')
    {
      if (currentState == STATE_WAIT_FOR_START)
      {
        Serial.println("Carriage jog up (from serial cmd '<' )");
        currentState = STATE_CARRIAGE_SERIAL_JOG_UP_START;
      }
      inputString = "";
    }

    else if (inChar == 's')
    {
      Serial.println("Test Stopped - Stop Test Cycle (from serial cmd 's' )");
      cntActiveCycles = numOfCycles;
    }

    else if (inChar == '\r')
    {
      inputString = "";
    }
    else if (inChar == '\n')
    {
      inputString = "";
    }
    else if ((inChar >= '0') & (inChar <= '9') )
    {
      // add it to the inputString:
      inputString += inChar;
    }
    else if (inChar == '?')  // querry for stats
    {
      // needs to driven by state
      if (currentState == STATE_WAIT_FOR_START)
      {
        currentState = STATE_STATUS;
        Serial.println(" test");
      }
      inputString = "";
    }
    else
    {
      inputString = "";  // keep the buffer clear
    }
  }
}
