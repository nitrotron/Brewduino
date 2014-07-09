<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScratchPad.aspx.cs" Inherits="Brewduino.Pages.ScratchPad" %>

<%@ Register Src="~/Controllers/BrewingThermometer.ascx" TagPrefix="uc1" TagName="BrewThermometer" %>
<%@ Register Src="~/Controllers/CountDownTimer.ascx" TagPrefix="uc2" TagName="CoundDownTimer" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Bootstrap 101 Template</title>
    <!-- Bootstrap -->
    <%--<link href="css/bootstrap.min.css" rel="stylesheet">--%>
    <link href="../Bootstrap/bootstrap-3.2.0-dist/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Fonts/font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../Fonts/fontello-374a6348/css/misc.css" rel="stylesheet" type="text/css" />
   
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <asp:UpdatePanel ID="pnlMain" runat="server">
        <ContentTemplate>
            <asp:Timer ID="tmrRefreshStatus" runat="server" OnTick="tmrRefreshStatus_Tick" Enabled="false" />
            <div class="container-fluid">
                <div class="row">
                
                    <%-- <div id="RimsPanelMain">--%>
                    <%--  <div id="RimsThermometers">--%>
                    <div class="col-sm-6 col-md-3  RimsThermometer">
                        <uc1:BrewThermometer ID="btRims" runat="server" />
                    </div>
                    <div class="col-sm-6 col-md-3 RimsThermometer">
                        <uc1:BrewThermometer ID="btMash" runat="server" />
                    </div>
                    <div class="col-sm-6 col-md-3 RimsThermometer">
                        <uc1:BrewThermometer ID="btKettle" runat="server" />
                    </div>
                    <div class="col-sm-6 col-md-3 CountDownTimer">
                        <uc2:CoundDownTimer ID="cdtTimer" runat="server" />
                        <br />
                    </div>
                </div>
                <%-- </div>--%>
                <%--  <div id="buttonRow">--%>
                <div class="row">
                    <div class="col-sm-6 col-md-3 switch" id="switchReset">
                        <asp:CheckBox ID="btnResetAlarm" runat="server" AutoPostBack="true" OnCheckedChanged="btnResetAlarm_OnClick"
                            Text="<i class='icon-attention-alt'></i>Alarm" />
                    </div>
                    <div class="col-sm-6 col-md-3 switch" id="switchRimsOn">
                        <asp:CheckBox ID="chkRimsOn" runat="server" AutoPostBack="true" Text="<i class='icon-fire-1'></i>Rims"
                            OnCheckedChanged="chkRimsOn_CheckedChanged" />
                    </div>
                    <div class="col-sm-6 col-md-3 switch" id="switchPumpOn">
                        <asp:CheckBox ID="chPumpOn" runat="server" AutoPostBack="true" Text="<i class='icon-off'></i>Pump"
                            OnCheckedChanged="chPumpOn_CheckedChanged" />
                    </div>
                    <div class="col-sm-6 col-md-3 switch" id="switchAuxPower">
                        <asp:CheckBox ID="chAuxPower" runat="server" AutoPostBack="true" Text="<i class='icon-off'></i>Aux"
                            OnCheckedChanged="chAuxPower_CheckedChanged" />
                    </div>
                    <%-- </div>--%>
                    <asp:Label ID="lblSound" runat="server" Text="" />
                    <%--  </div>--%>
                </div>
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
    <asp:Panel ID="pnlDebug" runat="server" Visible="false">
    </asp:Panel>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>--%>
    <script src="../Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <%--<script src="js/bootstrap.min.js"></script>--%>
    <script src="../Bootstrap/bootstrap-3.2.0-dist/js/bootstrap.js" type="text/javascript"></script>
    </form>
</body>
</html>
