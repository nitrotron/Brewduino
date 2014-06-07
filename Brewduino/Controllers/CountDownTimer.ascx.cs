using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrewduinoCatalogLib;

namespace Brewduino.Controllers
{
    public partial class CountDownTimer : System.Web.UI.UserControl
    {
        protected BrewController _BrewControl;
        public BrewController BrewControl
        {
            get { return _BrewControl; }
            set { _BrewControl = value; }
        }
        protected Dictionary<string, float> _Status;
        public Dictionary<string, float> Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                UpdateReadings();
            }
        }

        private void UpdateReadings()
        {
            if (Status["TimersNotAllocated"] > 0)
            {
                btnAddNewTimer.Enabled = true;
            }
            else
            {
                btnAddNewTimer.Enabled = false;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddNewTimer_Click(object sender, EventArgs e)
        {
            DateTime countDownTo = DateTime.Now;
            float minutes;
            float.TryParse(tbNewTime.Text, out minutes);
            countDownTo = countDownTo.AddSeconds((double)(minutes * 60));

            BrewControl.SetTimer(minutes);

            if (hfPresentTimerList.Value.Length == 0)
            {
                hfPresentTimerList.Value = countDownTo.ToString("G", DateTimeFormatInfo.InvariantInfo);
                hfPresentTimerTitleList.Value = tbTimerLabel.Text;
            }
            else
            {
                hfPresentTimerList.Value += "," + countDownTo.ToString("G", DateTimeFormatInfo.InvariantInfo);
                hfPresentTimerTitleList.Value += "," + tbTimerLabel.Text;
            }

            //Div countdown = Page.FindControl("divCountdown") as Div;
            

            Status["TimersNotAllocated"] -= 1;
            UpdateReadings();

        }

        public void ResetAlarm()
        {
            string[] timerStrArray = hfPresentTimerList.Value.Split(',');
            StringBuilder updateHF = new StringBuilder();

            int timerCount = 0;
            foreach (string item in timerStrArray)
            {
                DateTime itemDateTime;
                DateTime.TryParse(item, out itemDateTime);
                if (itemDateTime > DateTime.Now)
                {
                    if (timerCount > 0)
                        updateHF.Append("," + item);
                    else
                        updateHF.Append(item);
                    timerCount++;
                }
            }
            hfPresentTimerList.Value = updateHF.ToString();

        }
    }
}