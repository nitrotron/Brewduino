﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Div.Master" AutoEventWireup="true"
    CodeBehind="RimsPanel.aspx.cs" Inherits="Brewduino.Pages.RimsPanel" %>

<%@ Register Src="~/Controllers/BrewingThermometer.ascx" TagPrefix="uc1" TagName="BrewThermometer" %>
<%@ Register Src="~/Controllers/CountDownTimer.ascx" TagPrefix="uc2" TagName="CoundDownTimer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <asp:Timer ID="tmrRefreshStatus" runat="server" OnTick="tmrRefreshStatus_Tick" Enabled="false" />
    <div id="RimsPanelMain">
        <%--<div id="RimsAlarm">
            <asp:Button ID="btnResetAlarm" runat="server" OnClick="btnResetAlarm_OnClick" Text="Reset Alarms" />
            <asp:Label ID="lblMainAlarm" runat="server" />
        </div>--%>
        <div id="RimsThermometers">
            <div class="RimsThermometer">
                <uc1:BrewThermometer ID="btRims" runat="server" />
            </div>
            <div class="RimsThermometer">
                <uc1:BrewThermometer ID="btMash" runat="server" />
            </div>
            <div class="RimsThermometer">
                <uc1:BrewThermometer ID="btKettle" runat="server" />
            </div>
            <div class="CountDownTimer">
                <uc2:CoundDownTimer ID="cdtTimer" runat="server" />
                <br />
            </div>
        </div>
        <%--<div id="Div1">
            <asp:Button ID="Button1" runat="server" OnClick="btnResetAlarm_OnClick" Text="Reset Alarms" />
            <asp:Label ID="Label1" runat="server" />
        </div>--%>
        <div id="buttonRow">
            <div class="switch" id="switchReset">
                <asp:CheckBox ID="btnResetAlarm" runat="server" AutoPostBack="true" OnCheckedChanged="btnResetAlarm_OnClick" Text="<i class='icon-attention-alt'></i>Alarm" />
            </div>
            <div class="switch" id="switchRimsOn">
                <asp:CheckBox ID="chkRimsOn" runat="server" AutoPostBack="true" Text="<i class='icon-fire-1'></i>Rims" OnCheckedChanged="chkRimsOn_CheckedChanged" />
            </div>
            <div class="switch" id="switchPumpOn">
                <asp:CheckBox ID="chPumpOn" runat="server" AutoPostBack="true" Text="<i class='icon-off'></i>Pump" OnCheckedChanged="chPumpOn_CheckedChanged" />
        </div>
            <div class="switch" id="switchAuxPower">
                <asp:CheckBox ID="chAuxPower" runat="server" AutoPostBack="true" Text="<i class='icon-off'></i>Aux" OnCheckedChanged="chAuxPower_CheckedChanged" />
            </div>
        </div>
        <asp:Label ID="lblSound" runat="server" Text="" />
       <%-- <div id="RimsGauge"></div>--%>
    </div>
      <script type='text/javascript' src='https://www.google.com/jsapi'></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var tmrRefresh = $find('<%= tmrRefreshStatus.ClientID %>');


            $("#btnShowNewTimerPanel").click(function () {
                tmrRefresh._stopTimer();
            });

        });

        google.load('visualization', '1', { packages: ['gauge'] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var data = google.visualization.arrayToDataTable([
              ['Label', 'Value'],
              ['DemoRims', 68]
            ]);

            var options = {
                width: 800, height: 240,
                redFrom: 90, redTo: 100,
                yellowFrom: 75, yellowTo: 90,
                minorTicks: 5,
                max: 212
            };

            var chart = new google.visualization.Gauge(document.getElementById('RimsGauge'));
            chart.draw(data, options);
        }
    </script>
</asp:Content>
