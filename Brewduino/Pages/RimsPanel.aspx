<%@ Page Title="" Language="C#" MasterPageFile="~/Div.Master" AutoEventWireup="true"
    CodeBehind="RimsPanel.aspx.cs" Inherits="Brewduino.Pages.RimsPanel" %>

<%@ Register Src="~/Controllers/BrewingThermometer.ascx" TagPrefix="uc1" TagName="BrewThermometer" %>
<%@ Register Src="~/Controllers/CountDownTimer.ascx" TagPrefix="uc2" TagName="CoundDownTimer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Timer ID="tmrRefreshStatus" runat="server" OnTick="tmrRefreshStatus_Tick" Enabled="false" />
    <div id="RimsPanelMain">
        <div id="RimsAlarm">
            <asp:Label ID="lblMainAlarm" runat="server" />
            <asp:Button ID="btnResetAlarm" runat="server" OnClick="btnResetAlarm_OnClick" Text="Reset Alarms" />
        </div>
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
    </div>
    <%--<table class="WebPageMainTable">
        <tr>
            <td colspan="3">
                <asp:Label ID="lblMainAlarm" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnResetAlarm" runat="server" OnClick="btnResetAlarm_OnClick" Text="Reset Alarms" />
            </td>
        </tr>
        <tr>
            <td>
                <uc1:BrewThermometer ID="btRims" runat="server" />
            </td>
            <td>
                <uc1:BrewThermometer ID="btMash" runat="server" />
            </td>
            <td>
                <uc1:BrewThermometer ID="btKettle" runat="server" />
            </td>
        </tr>
    </table>--%>
</asp:Content>
