<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BrewingThermometer.ascx.cs"
    Inherits="Brewduino.Controllers.BrewingThermometer" %>
<div id="BrewingThermometerMain">
    <asp:Label ID="lblTitle" runat="server" CssClass="BrewingThermometer_Title" Text="Title" />
    <br />
    <div id="BrewingThermometer_Display">
        <asp:LinkButton ID="lblCurrentTemp" runat="server" CssClass="TemperatureDigital" Text="180"  OnClick="btnCurrentTemp_OnClick"/>
        <asp:LinkButton ID="btnTempHighAlarm" runat="server" CssClass="TemperatureDigitalSmallTop"
            Text="200" OnClick="btnTempHighAlarm_OnClick" />
        <asp:LinkButton ID="btnTempLowAlarm" runat="server" CssClass="TemperatureDigitalSmallBottom"
            Text="-10" OnClick="btnTempLowAlarm_OnClick" />
            <asp:Panel ID="pnlRimsControls" runat="server" Visible="false">
            <div id="rimsControlLabels" style="width: 50%">
            setpoint:
            </div>
            <div id="rimsControlTextBoxs" style="width:50%>
            <asp:TextBox ID="tbSetpoint" runat="server" />
            </asp:Panel>
        <asp:Panel ID="pnlSetAlarm" class="PanelOverlay" runat="server" Visible="false">
            <asp:Label ID="lblAlarmTitle" runat="server"/>
            <br />
            <asp:TextBox ID="tbAlarm" runat="server" />
            <asp:Button ID="btnUpdateAlarms" runat="server" OnClick="btnUpdateAlarms_OnClick"
                Text="Update" />
            <asp:HiddenField ID="hfWhichAlarm" runat="server" />
        </asp:Panel>
    </div>
</div>