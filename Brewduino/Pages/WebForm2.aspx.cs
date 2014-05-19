using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrewduinoCatalogLib;
using System.IO.Ports;

namespace Brewduino.Pages
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected ArduinoSerial mySerial = new ArduinoSerial();
        protected BrewController BrewControl;
        protected Dictionary<string, decimal> CurrentStatus;

        protected void Page_Load(object sender, EventArgs e)
        {
            BrewControl = new BrewController(mySerial);

            PopulateDropDownLists();

        }

        private void PopulateDropDownLists()
        {
            ddlCommand.Items.Clear();

            ddlThermo.Items.Add(new ListItem("Open", "0"));
            ddlCommand.Items.Add(new ListItem("ReturnStatus", "1"));
            ddlCommand.Items.Add(new ListItem("GetTemps", "2"));
            ddlCommand.Items.Add(new ListItem("GetTemp", "3"));
            ddlCommand.Items.Add(new ListItem("GetSensors", "4"));
            ddlCommand.Items.Add(new ListItem("GetSensor", "5"));
            ddlCommand.Items.Add(new ListItem("GetTempAlarms", "6"));
            ddlCommand.Items.Add(new ListItem("SetTempAlarmHigh", "7"));
            ddlCommand.Items.Add(new ListItem("SetTempAlarmLow", "8"));
            ddlCommand.Items.Add(new ListItem("ClearTempAlarms", "9"));
            ddlCommand.Items.Add(new ListItem("GetTimer", "10"));
            ddlCommand.Items.Add(new ListItem("SetTimer", "11"));
            ddlCommand.Items.Add(new ListItem("ResetAlarm", "12"));
            ddlCommand.Items.Add(new ListItem("GetAlarmStatus", "13"));
            ddlCommand.Items.Add(new ListItem("StartLogging", "14"));
            ddlCommand.Items.Add(new ListItem("StopLogging", "15"));
            ddlCommand.Items.Add(new ListItem("SetPIDSetPoint", "16"));


            ddlThermo.Items.Clear();
            ddlThermo.Items.Add(new ListItem("RIMS", ((int)BrewController.ThermometersName.RIMS).ToString()));
            ddlThermo.Items.Add(new ListItem("Mash", ((int)BrewController.ThermometersName.MashTun).ToString()));
            ddlThermo.Items.Add(new ListItem("Kettle", ((int)BrewController.ThermometersName.Kettle).ToString()));

        }  

        protected void btnPreOpen_OnClick(object sender, EventArgs e)
        {
            SerialPort sp = new SerialPort();
            sp.PortName = "/dev/ttyACM0";
            sp.BaudRate = 9600;
            sp.Parity = Parity.None;
            sp.DataBits = 8;
            sp.StopBits = StopBits.One;
            sp.ReadTimeout = 5000;
            sp.WriteTimeout = 500;

            


            lblTest.Text = SerialPort.GetPortNames()[0] +" Serial ports " + sp.PortName + sp.BaudRate + sp.StopBits + sp.DataBits;
            
        }

        protected void btnTest_OnClick(object sender, EventArgs e)
        {
            
            mySerial.PortName = "/dev/ttyACM0";
            mySerial.BaudRate = 9600;
            mySerial.Parity = Parity.None;
            mySerial.DataBits = 8;
            mySerial.StopBits = StopBits.One;
            mySerial.ReadTimeout = 5000;
            mySerial.WriteTimeout = 500;

            mySerial.Close();
            mySerial.Open();
            
            string whichTHermo = string.Empty;

            if (ddlCommand.SelectedValue == ArduinoCommands.CommandTypes.GetTemp.ToString() ||
                ddlCommand.SelectedValue == ArduinoCommands.CommandTypes.GetSensor.ToString() ||
                ddlCommand.SelectedValue == ArduinoCommands.CommandTypes.SetTempAlarmHigh.ToString() ||
                ddlCommand.SelectedValue == ArduinoCommands.CommandTypes.SetTempAlarmLow.ToString())
                whichTHermo =  ddlThermo.SelectedValue;
            
                
            ArduinoCommands.CommandTypes command = (ArduinoCommands.CommandTypes)Convert.ToInt32(ddlCommand.SelectedValue);

            lblTest.Text = "We just opened";

            if (ddlCommand.SelectedValue != "0")
            lblTest.Text = mySerial.SendCommandWithDebugResponse(command,whichTHermo);



            mySerial.Close();
        }

        
    }
}