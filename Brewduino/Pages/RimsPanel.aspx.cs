using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrewduinoCatalogLib;

namespace Brewduino.Pages
{
    public partial class RimsPanel : System.Web.UI.Page
    {
        protected ArduinoSerial mySerial = new ArduinoSerial();
        protected BrewController BrewControl;
        protected Dictionary<string, decimal> CurrentStatus;

        protected void Page_Load(object sender, EventArgs e)
        {
            BrewControl = new BrewController(mySerial);
            mySerial.ClosePort();
            mySerial.OpenPort();

            CurrentStatus = BrewControl.GetStatus();
            btRims.BrewControl = BrewControl;
            btRims.Status = CurrentStatus;
            btRims.Thermometer = BrewController.ThermometersName.RIMS;
            btRims.Name = "RIMS";
            btMash.BrewControl = BrewControl;
            btMash.Status = CurrentStatus;
            btMash.Thermometer = BrewController.ThermometersName.MashTun;
            btMash.Name = "Mash Tun";
            btKettle.BrewControl = BrewControl;
            btKettle.Status = CurrentStatus;
            btKettle.Thermometer = BrewController.ThermometersName.Kettle;
            btKettle.Name = "Kettle";

            if (CurrentStatus["TempAlarmActive"] > 0)
                lblMainAlarm.Text = "We have an alarm";

            Response.AppendHeader("Refresh", 10 + "; URL=RimsPanel.aspx");

        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            mySerial.ClosePort();
        }

        protected void btnResetAlarm_OnClick(object sender, EventArgs e)
        {
            if (CurrentStatus["TempAlarmActive"] > 0)
            {
                if (CurrentStatus["WhichThermoAlarm"] == (int)BrewController.ThermometersName.RIMS)
                {
                    btRims.ResetAlarm();
                }
                else if (CurrentStatus["WhichThermoAlarm"] == (int)BrewController.ThermometersName.MashTun)
                {
                    btMash.ResetAlarm();
                }
                else if (CurrentStatus["WhichThermoAlarm"] == (int)BrewController.ThermometersName.Kettle)
                {
                    btKettle.ResetAlarm();
                }
            }

            BrewControl.ResetAlarm();

        }
    }
}