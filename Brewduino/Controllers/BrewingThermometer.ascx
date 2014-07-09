<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BrewingThermometer.ascx.cs"
    Inherits="Brewduino.Controllers.BrewingThermometer" %>
<div id="BrewingThermometerMain">
    <asp:Label ID="lblTitle" runat="server" CssClass="BrewingThermometer_Title" Text="Title" />
    <br />
    <%--<div class="container">--%>
    <div class="row">
        <%-- <div id="BrewingThermometer_Display">--%>
        <div class="col-md-6" style="background-color: Fuchsia">
            <asp:LinkButton ID="lblCurrentTemp" runat="server" CssClass="TemperatureDigital"
                Text="180" OnClick="btnCurrentTemp_OnClick" />
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-12">
                    <asp:LinkButton ID="btnTempHighAlarm" runat="server" CssClass="TemperatureDigitalSmallTop"
                        Text="200" OnClick="btnTempHighAlarm_OnClick" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:LinkButton ID="btnTempLowAlarm" runat="server" CssClass="TemperatureDigitalSmallBottom"
                        Text="-10" OnClick="btnTempLowAlarm_OnClick" />
                </div>
            </div>
            
            <asp:Panel ID="pnlSetAlarm" CssClass="PanelOverlay" runat="server" Visible="false">
                <asp:Label ID="lblAlarmTitle" runat="server" />
                <br />
                <asp:TextBox ID="tbAlarm" runat="server" />
                <asp:Button ID="btnUpdateAlarms" runat="server" OnClick="btnUpdateAlarms_OnClick"
                    Text="Update" />
                <asp:HiddenField ID="hfWhichAlarm" runat="server" />
            </asp:Panel>
            <%--</div>--%>
        </div>
        <%--</div>--%>
    </div>
</div>
