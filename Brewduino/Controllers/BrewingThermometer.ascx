<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BrewingThermometer.ascx.cs"
    Inherits="Brewduino.Controllers.BrewingThermometer" %>
<table class="BrewingThermometerMainTable">
    <tr>
        <td style="width: 2%;">
        <td colspan="3" class="BrewingThermometer_Title">
            <asp:Label ID="lblTitle" runat="server" CssClass="BrewingThermometer_Title" />
        </td>
    </tr>
    <tr>
        <td>&nbsp;
        </td>
        <td colspan="2" class="BrewingThermometer_Temp">
            <asp:Label ID="lblCurrentTemp" runat="server" CssClass="TemperatureDigital" />
        </td>
        <td style="width: 2%;">&nbsp;
        </td>
    </tr>
    <tr>
        <td></td>
        <td colspan="2"></td>
        <td></td>
    </tr>
    <tr>
        <td>&nbsp;
        </td>
        <td>High Alarm
        </td>
        <td>
            <asp:Label ID="lblHighAlarm" runat="server" />
        </td>
        <td>&nbsp;
        </td>
    </tr>
    
    <tr>
        <td>&nbsp;
        </td>
        <td>Low Alarm
        </td>
        <td>
            <asp:Label ID="lblLowAlarm" runat="server" />
        </td>
        <td>&nbsp;
        </td>
    </tr>
    <tr>
        <td>&nbsp;
        </td>
        <td>Set High Alarm
        </td>
        <td>
            <asp:TextBox ID="tbHighAlarm" runat="server" />
        </td>
        <td>&nbsp;
        </td>
    </tr>
    <tr>
        <td>&nbsp;
        </td>
        <td>Set Low Alarm
        </td>
        <td>
            <asp:TextBox ID="tbLowAlarm" runat="server" />
        </td>
        <td>&nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnUpdateAlarms" runat="server" OnClick="btnUpdateAlarms_OnClick" Text="Update" /></td>
    </tr>
</table>
