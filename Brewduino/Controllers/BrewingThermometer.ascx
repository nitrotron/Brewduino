<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BrewingThermometer.ascx.cs"
    Inherits="Brewduino.Controllers.BrewingThermometer" %>
<table>
    <tr>
        <td colspan="2">
            <asp:Label ID="lblTitle" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Current Temperature
        </td>
        <td>
            <asp:Label ID="lblCurrentTemp" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            High Alarm
        </td>
        <td>
            <asp:Label ID="lblHighAlarm" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Low Alarm
        </td>
        <td>
            <asp:Label ID="lblLowAlarm" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Set High Alarm
        </td>
        <td>
            <asp:TextBox ID="tbHighAlarm" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Set Low Alarm
        </td>
        <td>
            <asp:TextBox ID="tbLowAlarm" runat="server" />
        </td>
    </tr>
    <tr><td colspan="2"><asp:Button ID="btnUpdateAlarms" runat="server" OnClick="btnUpdateAlarms_OnClick" /></td></tr>
</table>
