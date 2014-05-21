using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrewduinoCatalogLib
{
    public interface IArduinoSerial
    {

        void SendCommand(ArduinoCommands.CommandTypes cmd, string text);
        Dictionary<string, decimal> SendCommandWithResponse(ArduinoCommands.CommandTypes cmd, string text);
<<<<<<< HEAD
        string SendCommandWithDebugResponse(ArduinoCommands.CommandTypes cmd, string text);
        Dictionary<string, decimal> GetStatus();
        string GetRawStatus();
        
=======
        Dictionary<string, decimal> GetStatus();
        void UpdateStatus();
        string GetRawStatus();
>>>>>>> 35fed74a1e9f606bb394696a53466b789f05b4eb
    }
}
