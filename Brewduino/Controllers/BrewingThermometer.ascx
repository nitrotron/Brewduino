<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BrewingThermometer.ascx.cs"
    Inherits="Brewduino.Controllers.BrewingThermometer" %>
<div id="BrewingThermometerMain">
    <asp:Label ID="lblTitle" runat="server" CssClass="BrewingThermometer_Title" Text="Title" />
    <br />
    <div id="BrewingThermometer_Display">
        <asp:Label ID="lblCurrentTemp" runat="server" CssClass="TemperatureDigital" Text="180" />
        <asp:LinkButton ID="btnTempHighAlarm" runat="server" CssClass="TemperatureDigitalSmallTop"
            Text="200" OnClick="btnTempHighAlarm_OnClick" />
        <asp:LinkButton ID="btnTempLowAlarm" runat="server" CssClass="TemperatureDigitalSmallBottom"
            Text="-10" OnClick="btnTempLowAlarm_OnClick" />
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
<%-- <table class="BrewingThermometerMainTable">
    <tr>
        <td style="width: 2%;">
            <td colspan="3" class="BrewingThermometer_Title">
                <asp:Label ID="lblTitle" runat="server" CssClass="BrewingThermometer_Title" />
            </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td colspan="2" class="BrewingThermometer_Temp">
            <asp:Label ID="lblCurrentTemp" runat="server" CssClass="TemperatureDigital" />
        </td>
        <td style="width: 2%;">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td colspan="2">
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            High Alarm
        </td>
        <td>
            <asp:Label ID="lblHighAlarm" runat="server" />
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            Low Alarm
        </td>
        <td>
            <asp:Label ID="lblLowAlarm" runat="server" />
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            Set High Alarm
        </td>
        <td>
            <asp:TextBox ID="tbHighAlarm" runat="server" />
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            Set Low Alarm
        </td>
        <td>
            <asp:TextBox ID="tbLowAlarm" runat="server" />
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnUpdateAlarms" runat="server" OnClick="btnUpdateAlarms_OnClick"
                Text="Update" />
        </td>
    </tr>
</table>--%>
