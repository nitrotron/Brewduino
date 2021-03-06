﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CountDownTimer.ascx.cs"
    Inherits="Brewduino.Controllers.CountDownTimer" %>
    <div><asp:CheckBox ID="chkSoundAlarm" runat="server" Text="Enable Sound Alarm" Visible="false"/></div>
<div id="btnShowNewTimerPanel" class="Clickable">
    <i class="fa fa-fa fa-clock-o"></i>Click for New Timer
</div>
<div style="width: 210px">
</div>
<div id="divCountdown" runat="server">
    <asp:HiddenField ID="hfPresentTimerList" runat="server" />
    <asp:HiddenField ID="hfPresentTimerTitleList" runat="server" />
</div>
<%--<div id="pnlAddTimer" style="display: none; width: 180px;">--%>
<div id="pnlAddTimer">
    <table>
        <tr>
            <td>
            </td>
            <td style="text-align: right;">
                <span id="dvCancelTimer" class="cancelX">X</span>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 20%;"  >
                Minutes:
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="tbNewTime" runat="server"  />
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                Title:
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="tbTimerLabel" runat="server"/>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="text-align: right;">
                <asp:Button ID="btnAddNewTimer" runat="server" Text="Start" OnClick="btnAddNewTimer_Click" />
            </td>
        </tr>
    </table>
</div>
<script src="../Scripts/jquery-1.10.2.js"></script>
<script type="text/javascript" src="../Scripts/jquery.countdown.js"></script>
<script type="text/javascript">
    function BindEvents2() {
        $(document).ready(function () {
            var hfTimerList = $("#<%=hfPresentTimerList.ClientID%>").val();
            var timerList = (hfTimerList).split(",");
            var hfTimerTitleList = $("#<%=hfPresentTimerTitleList.ClientID%>").val();
            var timerTitleList = (hfTimerTitleList).split(",");

            $("#dvCancelTimer").click(function () {
                $("#pnlAddTimer").fadeOut('slow');
                $("#btnShowNewTimerPanel").fadeTo('slow', 1);
            });

            $("#btnShowNewTimerPanel").click(function () {
                $("#btnShowNewTimerPanel").fadeTo('slow', .5);
                $("#pnlAddTimer").fadeIn('slow');

            });

            $("pnlAddTimer").click(function () {
                $("#btnShowNewTimerPanel").show();
            });


            $.each(timerList, function (index, value) {
                if (value != "") {
                    var newTimer = '<div class="clock" id="clock' + index + '" data-countdown="' + value + '" data-title="' + timerTitleList[index] + '"></div>';
                    $("#<%=divCountdown.ClientID%>").append(newTimer);
                }
            });


            $('[data-countdown]').each(function () {
                var $this = $(this), finalDate = $(this).data('countdown');
                $this.countdown(finalDate)
                     .on('update.countdown', function (event) {
                         $this.html(event.strftime('%H:%M:%S ' + $(this).data('title')));
                     })
                     .on('finish.countdown', function (event) {
                         $this.html(event.strftime('%H:%M:%S ' + $(this).data('title')));
                         // $(this).css("color", "#6291d0");
                         //$(this).css("background-color", "#FC7E7E");
                         $(this).fadeTo('slow', .5);
                     })
            });

            //        function callback(event) {
            //            $this = $(this);
            //            switch (event.type) {
            //                case "seconds":
            //                case "minutes":
            //                case "hours":
            //                case "days":
            //                case "weeks":
            //                case "daysLeft":
            //                    $this.find('span#' + event.type).html(event.value);
            //                    if (finished) {
            //                        $this.fadeTo(0, 1);
            //                        finished = false;
            //                    }
            //                    break;
            //                case "finished":
            //                    $this.fadeTo('slow', .5);
            //                    finished = true;
            //                    break;
            //            }
            //        }

        });
    };

    Sys.Application.add_load(BindEvents2);

</script>
<%--<script type="text/javascript">


    function addTimerScript() {

        var newTimeMinutes = $("#<%=tbNewTime.ClientID%>").val();
        confirm(newTimeMinutes);
    }

    $(function () {
        var currentDate = new Date(),
            finished = false,
            availiableExamples = {
                set15daysFromNow: 15 * 24 * 60 * 60 * 1000,
                set5minFromNow: 5 * 60 * 1000,
                set1minFromNow: 1 * 60 * 1000
            };

        function callback(event) {
            $this = $(this);
            switch (event.type) {
                case "seconds":
                case "minutes":
                case "hours":
                case "days":
                case "weeks":
                case "daysLeft":
                    $this.find('span#' + event.type).html(event.value);
                    if (finished) {
                        $this.fadeTo(0, 1);
                        finished = false;
                    }
                    break;
                case "finished":
                    $this.fadeTo('slow', .5);
                    finished = true;
                    break;
            }
        }

        $('div#clock').countdown(availiableExamples.set15daysFromNow + currentDate.valueOf(), callback);

        $('select#exampleDate').change(function () {
            debugger
            try {
                var $this = $(this),
                    value;
                currentDate = new Date();
                debugger
                switch ($this.attr('value')) {
                    case "other":
                        value = prompt('Set the date to countdown:\nThe hh:mm:ss parameters are opitionals', 'YYYY/MM/DD hh:mm:ss');
                        break;
                    case "daysFromNow":
                        value = prompt('How many days from now?', '');
                        value = new Number(value) * 24 * 60 * 60 * 1000 + currentDate.valueOf();
                        break;
                    case "minutesFromNow":
                        value = prompt('How many minutes from now?', '');
                        value = new Number(value) * 60 * 1000 + currentDate.valueOf();
                        break;
                    default:
                        value = availiableExamples[$this.attr('value')] + currentDate.valueOf();
                }
                $('div#clock').countdown(value, callback);
                $this.find('option:first').attr('selected', true);
            } catch (e) { alert(e); }
        });
    });

    $(function () {
        var currentDate = new Date(),
            finished = false;

        var $clock = $('#clock')
          .on('update.countdown', function (event) {
              debugger
              var format = '%H:%M:%S';
              if (event.offset.days > 0) {
                  format = '%-d day%!d ' + format;
              }
              if (event.offset.weeks > 0) {
                  format = '%-w week%!w ' + format;
              }
              $(this).html(event.strftime(format));
          })
          .on('finish.countdown', function (event) {
              $(this).parent()
                .addClass('disabled')
                .html('This offer has expired!');
          });

        $(document).ready(function () {
            $("input[id$='btnAddNewTimer']").click(function () {
                var value = $("#<%=tbNewTime.ClientID%>").val();
                confirm(value);
            });
        });

    });
</script>--%>
