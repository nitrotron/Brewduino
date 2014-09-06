using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrewduinoCatalogLib
{
    public class ArduinoStub : IArduinoSelfHost
    {


        public string GetRawStatus()
        {
            throw new NotImplementedException();
        }


        public Dictionary<string, string> GetStatus()
        {
            Dictionary<string, string> returnDict = new Dictionary<string, string>();

            returnDict["Thermometer0"] = "150.2";
            returnDict["Thermometer1"] = "82.9";
            returnDict["Thermometer2"]= "202.3";
            returnDict["Thermometer3"] = "189.3";

            returnDict["TempAlarmActive"] = "1";
            returnDict["TimerAlarmActive"] = "0";

            returnDict["ThermometerHighAlarm0"] = "209.0";
            returnDict["ThermometerHighAlarm1"] = "80.0";
            returnDict["ThermometerHighAlarm2"] = "210.0";
            returnDict["ThermometerHighAlarm3"] = "155.0";
            returnDict["ThermometerLowAlarm0"] = "15.0";
            returnDict["ThermometerLowAlarm1"] = "22.0";
            returnDict["ThermometerLowAlarm2"] = "30.0";
            returnDict["ThermometerLowAlarm3"] = "55.0";
            returnDict["WhichThermoAlarm"] = BrewController.ThermometersName.Kettle.ToString();
            returnDict["TimersNotAllocated"] = "3";
            returnDict["TotalTimers"] = "12";
            returnDict["RimsEnable"] = "0";
            returnDict["AuxOn"] = "1";
            returnDict["PumpOn"] = "0";

            DateTime serverTime = DateTime.Now.AddSeconds(5);

            returnDict["ServerTime"] = serverTime.ToShortTimeString();
            returnDict["Timer0"] = "23:59:23";
            returnDict["Kp"] = "1";
            returnDict["Ki"] = "2";
            returnDict["Kd"] = "3";
            returnDict["SetPoint"] = "5";
            returnDict["WindowSize"] = "6";



            return returnDict;
        }

        public void SendCommand(int arduinoCommands, string text)
        {
            // do nothing
        }

        public void UpdateStatus()
        {
            // do nothing
        }
    }
}
