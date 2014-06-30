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
        int MAXATTEMPTS = 30;
        public ArduinoSelfHostClient(Binding binding, EndpointAddress address)
            : base(binding, address)
        {
        }

        public string GetRawStatus()
        {
            string rString = null;
            bool successfulTX = false;
            int attemptCount = 0;
            while (!successfulTX)
            {
                try
                {
                    rString = Channel.GetRawStatus();
                    successfulTX = true;
                }
                catch (Exception e)
                {
                    attemptCount++;
                    if (attemptCount > MAXATTEMPTS)
                    {
                        throw e;
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            }
            return rString;
        }
        public Dictionary<string, string> GetStatus()
        {
            Dictionary<string, string> rDictionary = null;
            bool successfulTX = false;
            int attemptCount = 0;
            while (!successfulTX)
            {
                try
                {
                    rDictionary = Channel.GetStatus();
                    successfulTX = true;
                }
                catch (Exception e)
                {
                    attemptCount++;
                    if (attemptCount > MAXATTEMPTS)
                    {
                        throw e;
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            }
            return rDictionary;
        }
        public void SendCommand(int arduinoCommands, string text)
        {
            bool successfulTX = false;
            int attemptCount = 0;
            while (!successfulTX)
            {
                try
                {
                    Channel.SendCommand(arduinoCommands, text);
                    successfulTX = true;
                }
                catch (Exception e)
                {
                    attemptCount++;
                    if (attemptCount > MAXATTEMPTS)
                    {
                        throw e;
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            }

        }
        public void UpdateStatus()
        {
            bool successfulTX = false;
            int attemptCount = 0;
            while (!successfulTX)
            {
                try
                {
                    Channel.UpdateStatus();
                    successfulTX = true;
                }
                catch (Exception e)
                {
                    attemptCount++;
                    if (attemptCount > MAXATTEMPTS)
                    {
                        throw e;
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            }

        }
    }

}
