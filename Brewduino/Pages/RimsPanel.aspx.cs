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
        protected Dictionary<string, decimal> CurrentStatus;

        protected void Page_Load(object sender, EventArgs e)
        {
             var binding = new BasicHttpBinding();
            //var address = new EndpointAddress("http://localhost:8080/SerialSwitch");
            var address = new EndpointAddress("http://192.168.0.16:8080/SerialSwitch");
            Arduino = new ArduinoSelfHostClient(binding, address);
            Arduino = new ArduinoStub(); //This in there so I can work on the skin.
            BrewControl = new BrewController(Arduino);
           
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

            //btRims1.BrewControl = BrewControl;
            //btRims1.Status = CurrentStatus;
            //btRims1.Thermometer = BrewController.ThermometersName.RIMS;
            //btRims1.Name = "RIMS";
            //btMash1.BrewControl = BrewControl;
            //btMash1.Status = CurrentStatus;
            //btMash1.Thermometer = BrewController.ThermometersName.MashTun;
            //btMash1.Name = "Mash Tun";
            //btKettle1.BrewControl = BrewControl;
            //btKettle1.Status = CurrentStatus;
            //btKettle1.Thermometer = BrewController.ThermometersName.Kettle;
            //btKettle1.Name = "Kettle";

            

            if (CurrentStatus["TempAlarmActive"] > 0)
                lblMainAlarm.Text = "We have an alarm";

            Response.AppendHeader("Refresh", 60 + "; URL=RimsPanel.aspx");

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