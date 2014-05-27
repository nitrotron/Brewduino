using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace BrewduinoCatalogLib
{
    public class ArduinoSelfHostClient : ClientBase<IArduinoSelfHost>, IArduinoSelfHost
    {
        public ArduinoSelfHostClient(Binding binding, EndpointAddress address)
            : base(binding, address)
        {
        }

        public string GetRawStatus()
        {
            return Channel.GetRawStatus();
        }
        public Dictionary<string, decimal> GetStatus()
        {
            return Channel.GetStatus();
        }
        public void SendCommand(int arduinoCommands, string text)
        {
            Channel.SendCommand(arduinoCommands, text);
        }
        public void UpdateStatus()
        {
            Channel.UpdateStatus();
        }

        
    }

}
