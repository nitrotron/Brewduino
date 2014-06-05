using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        protected Dictionary<string, decimal> _Status;
        public Dictionary<string, decimal> Status
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
            decimal minutes;
            decimal.TryParse(tbNewTime.Text, out minutes);
            countDownTo = countDownTo.AddSeconds((double)(minutes * 60));

            BrewControl.SetTimer(minutes);

            if (hfPresentTimerList.Value.Length == 0)
                hfPresentTimerList.Value = countDownTo.ToString("G", DateTimeFormatInfo.InvariantInfo);
            else
            {
                hfPresentTimerList.Value += "," + countDownTo.ToString("G", DateTimeFormatInfo.InvariantInfo);
            }

            //Div countdown = Page.FindControl("divCountdown") as Div;
            

            Status["TimersNotAllocated"] -= 1;
            UpdateReadings();

        }
    }
}