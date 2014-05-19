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
            SerialPort sp = new SerialPort();
            sp.PortName = "/dev/ttyACM0";
            sp.BaudRate = 9600;
            sp.Parity = Parity.None;
            sp.DataBits = 8;
            sp.StopBits = StopBits.One;
            sp.ReadTimeout = 5000;
            sp.WriteTimeout = 500;

            sp.Close();
            sp.Open();


            lblTest.Text = "We just opened";

            sp.Close();
        }
    }
}