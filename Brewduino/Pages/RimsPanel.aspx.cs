using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrewduinoCatalogLib;
using System.ServiceModel;
using System.Media;
using System.ComponentModel;

namespace Brewduino.Pages
{
    public partial class RimsPanel : System.Web.UI.Page
    {
        //protected ArduinoSerial mySerial = new ArduinoSerial();
        protected IArduinoSelfHost Arduino;
        protected BrewController BrewControl;
        protected Dictionary<string, string> CurrentStatus;

        protected void Page_Load(object sender, EventArgs e)
        {
            var binding = new BasicHttpBinding();
            var address = new EndpointAddress("http://localhost:8080/SerialSwitch");
            //var address = new EndpointAddress("http://192.168.0.16:8080/SerialSwitch");
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

            bool tempAlarmActive = false;
            bool.TryParse(CurrentStatus["TempAlarmActive"], out tempAlarmActive);
            bool timerAlarmActive = false;
            bool.TryParse( CurrentStatus["TimerAlarmActive"], out timerAlarmActive);
            
            if (tempAlarmActive || timerAlarmActive)
            {
                //lblMainAlarm.Text = "We have an alarm";
                btnResetAlarm.Checked = true;
                soundAlarm();
            }
            RefreshButtons();


            //Response.AppendHeader("Refresh", 5 + "; URL=RimsPanel.aspx");
            tmrRefreshStatus.Interval = 150000000;
            tmrRefreshStatus.Enabled = true;

        }

        private void RefreshButtons()
        {
            chkRimsOn.Checked = (CurrentStatus["RimsEnable"] == "1") ? true : false;
            chAuxPower.Checked = (CurrentStatus["AuxOn"] == "1") ? true: false;
            chPumpOn.Checked = (CurrentStatus["PumpOn"] == "1") ? true : false;
        }


        protected void btnResetAlarm_OnClick(object sender, EventArgs e)
        {
            bool tempAlarmActive = false;
            bool.TryParse(CurrentStatus["TempAlarmActive"], out tempAlarmActive);
            
            if (tempAlarmActive)
            {
                int whichThermoAlarm = 9999;
                int.TryParse(CurrentStatus["WhichThermoAlarm"], out whichThermoAlarm);
                if (whichThermoAlarm == (int)BrewController.ThermometersName.RIMS)
                {
                    btRims.ResetAlarm();
                }
                else if (whichThermoAlarm == (int)BrewController.ThermometersName.MashTun)
                {
                    btMash.ResetAlarm();
                }
                else if (whichThermoAlarm == (int)BrewController.ThermometersName.Kettle)
                {
                    btKettle.ResetAlarm();
                }
            }
            //if (CurrentStatus["TimerAlarmActive"] > 0)
            {
                cdtTimer.ResetAlarm();
            }
            //lblMainAlarm.Text = string.Empty;

            BrewControl.ResetAlarm();
            btnResetAlarm.Checked = false;

        }

        protected void tmrRefreshStatus_Tick(object sender, EventArgs e)
        {
            // do nothing. This post back should be enough
            CurrentStatus = BrewControl.GetStatus();

            btRims.Status = CurrentStatus;
            btKettle.Status = CurrentStatus;
            btMash.Status = CurrentStatus;

        }

        protected void chkRimsOn_CheckedChanged(object sender, EventArgs e)
        {
            BrewControl.TurnOnRims((chkRimsOn.Checked == true) ? 1 : 0);
        }

        protected void chPumpOn_CheckedChanged(object sender, EventArgs e)
        {
            BrewControl.TurnOnPumps((chPumpOn.Checked == true) ? 1 : 0);
        }

        protected void chAuxPower_CheckedChanged(object sender, EventArgs e)
        {
            BrewControl.TurnOnPumps((chPumpOn.Checked == true) ? 1 : 0);
        }


        private void soundAlarm()
        {

            SoundPlayer wavPlayer = new SoundPlayer();
            wavPlayer.SoundLocation = "C:/Users/jessica/Documents/GitHub/Brewduino/Brewduino/Sounds/ALARM.WAV";
            wavPlayer.LoadCompleted += new AsyncCompletedEventHandler(wavPlayer_LoadCompleted);
            wavPlayer.LoadAsync();

        }

        private void wavPlayer_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ((System.Media.SoundPlayer)sender).Play();
        }
    }
}