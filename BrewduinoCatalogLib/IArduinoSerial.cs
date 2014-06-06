using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrewduinoCatalogLib
{
    public interface IArduinoSerial
    {

        void SendCommand(ArduinoCommands.CommandTypes cmd, string text);
        Dictionary<string, float> SendCommandWithResponse(ArduinoCommands.CommandTypes cmd, string text);

        string SendCommandWithDebugResponse(ArduinoCommands.CommandTypes cmd, string text);
        Dictionary<string, float> GetStatus();
        string GetRawStatus();
        

        //Dictionary<string, float> GetStatus();
        //void UpdateStatus();
        //string GetRawStatus();

    }
}
