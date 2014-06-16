<%@ Page Title="" Language="C#" MasterPageFile="~/Div.Master" AutoEventWireup="true"
    CodeBehind="RimsPanel.aspx.cs" Inherits="Brewduino.Pages.RimsPanel" %>

<%@ Register Src="~/Controllers/BrewingThermometer.ascx" TagPrefix="uc1" TagName="BrewThermometer" %>
<%@ Register Src="~/Controllers/CountDownTimer.ascx" TagPrefix="uc2" TagName="CoundDownTimer" %>
<%@ Register Src="~/Controllers/ToggleButton.ascx" TagPrefix="uc3" TagName="ToggleButton" %>
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
            <div class="switch demo4">
                <input type="checkbox" runat="server" id="btnResetAlarm" onclick="btnResetAlarm_OnClick">
                <label>
                    <i class="icon-attention-alt"></i>
                </label>
            </div>
            <div class="switch demo4">
                <input type="checkbox">
                <label>
                    <i class="icon-fire-1"></i>
                </label>
            </div>
            <div class="switch demo4">
                <input type="checkbox">
                <label>
                  <i class="icon-off"></i>
                </label>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {

            var tmrRefresh = $find('<%= tmrRefreshStatus.ClientID %>');


            $("#btnShowNewTimerPanel").click(function () {
                tmrRefresh._stopTimer();
            });



        });
    </script>
</asp:Content>
