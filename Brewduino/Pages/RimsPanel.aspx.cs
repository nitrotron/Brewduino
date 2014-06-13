using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrewduinoCatalogLib;
using System.ServiceModel;

namespace Brewduino.Pages
{
    public partial class RimsPanel : System.Web.UI.Page
    {
        //protected ArduinoSerial mySerial = new ArduinoSerial();
        protected IArduinoSelfHost Arduino;
        protected BrewController BrewControl;
        protected Dictionary<string, float> CurrentStatus;

        protected void Page_Load(object sender, EventArgs e)
        {
            var binding = new BasicHttpBinding();
            //var address = new EndpointAddress("http://localhost:8080/SerialSwitch");
            var address = new EndpointAddress("http://192.168.0.16:8080/SerialSwitch");
            Arduino = new ArduinoSelfHostClient(binding, address);
            Arduino = new ArduinoStub(); //This in there so I can work on the skin.
            BrewControl = new BrewController(Arduino);

            CurrentStatus = BrewControl.GetStatus();
            btRims.Thermometer = BrewController.ThermometersName.RIMS;
            btRims.Name = "RIMS";
            btRims.BrewControl = BrewControl;
            btRims.Status = CurrentStatus;


            btMash.Thermometer = BrewController.ThermometersName.MashTun;
            btMash.Name = "Mash Tun";
            btMash.BrewControl = BrewControl;
            btMash.Status = CurrentStatus;

            btKettle.Thermometer = BrewController.ThermometersName.Kettle;
            btKettle.Name = "Kettle";
            btKettle.BrewControl = BrewControl;
            btKettle.Status = CurrentStatus;

            cdtTimer.BrewControl = BrewControl;
            cdtTimer.Status = CurrentStatus;


            if (CurrentStatus["TempAlarmActive"] > 0 || CurrentStatus["TimerAlarmActive"] > 0)
            {
                lblMainAlarm.Text = "We have an alarm";
               
            }


            //Response.AppendHeader("Refresh", 5 + "; URL=RimsPanel.aspx");
            tmrRefreshStatus.Interval = 5000;
            tmrRefreshStatus.Enabled = true;

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
            if (CurrentStatus["TimerAlarmActive"] > 0)
            {
                cdtTimer.ResetAlarm();
            }
            lblMainAlarm.Text = string.Empty;

            BrewControl.ResetAlarm();

        }

        protected void tmrRefreshStatus_Tick(object sender, EventArgs e)
        {
            // do nothing. This post back should be enough
            CurrentStatus = BrewControl.GetStatus();

            btRims.Status = CurrentStatus;
            btKettle.Status = CurrentStatus;
            btMash.Status = CurrentStatus;

        }

    }
}