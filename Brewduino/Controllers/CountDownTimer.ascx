<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CountDownTimer.ascx.cs"
    Inherits="Brewduino.Controllers.CountDownTimer" %>
<div id="getting-started">
</div>
<script src="../Scripts/jquery-1.10.2.js"></script>
<script type="text/javascript" src="../Scripts/jquery.countdown.js"></script>
<script type="text/javascript">
    $('#getting-started').countdown('2015/01/01', function (event) {
        $(this).html(event.strftime('%w weeks %d days %H:%M:%S'));
    });
</script>
