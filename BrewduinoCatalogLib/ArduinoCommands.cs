using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrewduinoCatalogLib
{
    public class ArduinoCommands
    {
       
        public enum CommandTypes
        {

            ReturnUnknownCmd, //0
            ReturnStatus, // 1
            GetTemps,//2
            GetTemp,//3
            GetSensors,//4
            GetSensor,//5
            GetTempAlarms,//6
            SetTempAlarmHigh,//7
            SetTempAlarmLow,//8
            ClearTempAlarms,//9
            GetTimer,//10
            SetTimer,//11
            ResetAlarm,//12  
            GetAlarmStatus, //13
            StartLogging,//14
            StopLogging,//15
            SetPIDSetPoint//16

        };
    }
}
