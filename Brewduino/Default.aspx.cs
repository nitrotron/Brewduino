using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrewduinoCatalogLib;





namespace Brewduino
{
    public partial class _Default : System.Web.UI.Page
    {
        protected ArduinoSerial mySerial = new ArduinoSerial();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //string retString = mySerial.WriteLineWithResponse(ArduinoSerial.ArduinoCommands.GetTemp, "0");
            //retString = mySerial.WriteLineWithResponse(ArduinoSerial.ArduinoCommands.GetTemp, "1");
        }

        protected void btnSetHighAlarm_click(object sender, EventArgs e)
        {

            //string retString = mySerial.WriteLineWithResponse(ArduinoSerial.ArduinoCommands.SetTempAlarmHigh, "1," + tbMashHighAlarm.Text);
            //retString = mySerial.WriteLineWithResponse(ArduinoSerial.ArduinoCommands.ResetAlarm, "");
        }
    }
}
