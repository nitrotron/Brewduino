﻿<%@ Page Title="Brewduino" Language="C#" MasterPageFile="~/Div.Master" AutoEventWireup="true"
    CodeBehind="RimsPanel.aspx.cs" Inherits="Brewduino.Pages.RimsPanel" %>

<%@ Register Src="~/Controllers/BrewingThermometer.ascx" TagPrefix="uc1" TagName="BrewThermometer" %>
<%@ Register Src="~/Controllers/CountDownTimer.ascx" TagPrefix="uc2" TagName="CoundDownTimer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <asp:UpdatePanel ID="pnlMain" runat="server">
        <ContentTemplate>
            <asp:Timer ID="tmrRefreshStatus" runat="server" OnTick="tmrRefreshStatus_Tick" Enabled="false" />
            <div id="RimsPanelMain">
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
                    <div class="RimsThermometer">
                        <uc1:BrewThermometer ID="btHLT" runat="server" />
                    </div>
                    <div class="CountDownTimer">
                        <uc2:CoundDownTimer ID="cdtTimer" runat="server" />
                        <br />
                    </div>
                </div>
                <div id="buttonRow">
                    <div class="SwitchWrapper">
                        <div class="switch" id="switchReset">
                            <asp:CheckBox ID="btnResetAlarm" runat="server" AutoPostBack="true" OnCheckedChanged="btnResetAlarm_OnClick"
                                Text="<i class='icon-attention-alt'></i>Alarm" />
                        </div>
                    </div>
                    <div class="SwitchWrapper">
                        <div class="switch" id="switchRimsOn">
                            <asp:CheckBox ID="chkRimsOn" runat="server" AutoPostBack="true" Text="<i class='icon-fire-1'></i>RIMS"
                                OnCheckedChanged="chkRimsOn_CheckedChanged" />
                        </div>
                    </div>
                    <div class="SwitchWrapper">
                        <div class="switch" id="switchPumpOn">
                            <asp:CheckBox ID="chPumpOn" runat="server" AutoPostBack="true" Text="<i class='icon-off'></i>Pump"
                                OnCheckedChanged="chPumpOn_CheckedChanged" />
                        </div>
                    </div>
                    <div class="SwitchWrapper">
                        <div class="switch" id="switchAuxPower">
                            <asp:CheckBox ID="chAuxPower" runat="server" AutoPostBack="true" Text="<i class='icon-off'></i>Aux"
                                OnCheckedChanged="chAuxPower_CheckedChanged" />
                        </div>
                    </div>
                    <span class="Stretch" />
                </div>
                <asp:Label ID="lblSound" runat="server" Text="" />
                <asp:Label ID="lblLastUpdate" runat="server" />
                <br />
                <asp:LinkButton ID="lbEnableDebug" runat="server" OnClick="lbEnableDebug_OnClick"
                    Text="Show BruinoData" />
                <%-- <div id="RimsGauge"></div>--%>
                <asp:Panel ID="pnlDebug" runat="server" Visible="false">
                    <asp:DataList ID="dlDebug" runat="server" DataKeyField="Key">
                        <ItemTemplate>
                            <asp:Label ID="lblKey" runat="server" Text='<%# Eval("Key") %>' />
                            =
                            <asp:Label ID="lblValue" runat="server" Text='<%# Eval("Value") %>' />
                        </ItemTemplate>
                        <AlternatingItemStyle BackColor="#cccccc" />
                    </asp:DataList>
                </asp:Panel>
            </div>
            <script type='text/javascript' src='https://www.google.com/jsapi'></script>
            <script type="text/javascript">
                function BindEvents() {
                    $(document).ready(function () {

                        var tmrRefresh = $find('<%= tmrRefreshStatus.ClientID %>');


                        $("#btnShowNewTimerPanel").click(function () {
                            tmrRefresh._stopTimer();
                        });

                    });
                };

            </script>
            <script type="text/javascript">
                Sys.Application.add_load(BindEvents);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
