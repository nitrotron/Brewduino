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


        public Dictionary<string, decimal> GetStatus()
        {
            Dictionary<string, decimal> returnDict = new Dictionary<string, decimal>();

            returnDict["Thermometer0"] = 150;
            returnDict["Thermometer1"] = 150;
            returnDict["Thermometer2"] = 150;

            returnDict["TempAlarmActive"] = 0;

            returnDict["ThermometerHighAlarm0"] = 275;
            returnDict["ThermometerHighAlarm1"] = 275;
            returnDict["ThermometerHighAlarm2"] = 275;
            returnDict["ThermometerLowAlarm0"] = -10;
            returnDict["ThermometerLowAlarm1"] = -10;
            returnDict["ThermometerLowAlarm2"] = -10;

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
