﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Debugaspx.aspx.cs" Inherits="Brewduino.Pages.Debugaspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet">
	<script src="../Scripts/jquery-1.10.2.js"></script>
	<script src="../Scripts/jquery-ui-1.10.4.custom.js"></script>
	<script>
	    $(function () {

	        $("#accordion").accordion();



	        var availableTags = [
			"ActionScript",
			"AppleScript",
			"Asp",
			"BASIC",
			"C",
			"C++",
			"Clojure",
			"COBOL",
			"ColdFusion",
			"Erlang",
			"Fortran",
			"Groovy",
			"Haskell",
			"Java",
			"JavaScript",
			"Lisp",
			"Perl",
			"PHP",
			"Python",
			"Ruby",
			"Scala",
			"Scheme"
		];
	        $("#autocomplete").autocomplete({
	            source: availableTags
	        });



	        $("#button").button();
	        $("#radioset").buttonset();



	        $("#tabs").tabs();



	        $("#dialog").dialog({
	            autoOpen: false,
	            width: 400,
	            buttons: [
				{
				    text: "Ok",
				    click: function () {
				        $(this).dialog("close");
				    }
				},
				{
				    text: "Cancel",
				    click: function () {
				        $(this).dialog("close");
				    }
				}
			]
	        });

	        // Link to open the dialog
	        $("#dialog-link").click(function (event) {
	            $("#dialog").dialog("open");
	            event.preventDefault();
	        });



	        $("#datepicker").datepicker({
	            inline: true
	        });



	        $("#slider").slider({
	            range: true,
	            values: [17, 67]
	        });



	        $("#progressbar").progressbar({
	            value: 20
	        });


	        // Hover states on the static widgets
	        $("#dialog-link, #icons li").hover(
			function () {
			    $(this).addClass("ui-state-hover");
			},
			function () {
			    $(this).removeClass("ui-state-hover");
			}
		);
	    });
	</script>
	<style>
	body{
		font: 62.5% "Trebuchet MS", sans-serif;
		margin: 50px;
	}
	.demoHeaders {
		margin-top: 2em;
	}
	#dialog-link {
		padding: .4em 1em .4em 20px;
		text-decoration: none;
		position: relative;
	}
	#dialog-link span.ui-icon {
		margin: 0 5px 0 0;
		position: absolute;
		left: .2em;
		top: 50%;
		margin-top: -8px;
	}
	#icons {
		margin: 0;
		padding: 0;
	}
	#icons li {
		margin: 2px;
		position: relative;
		padding: 4px 0;
		cursor: pointer;
		float: left;
		list-style: none;
	}
	#icons span.ui-icon {
		float: left;
		margin: 0 4px;
	}
	.fakewindowcontain .ui-widget-overlay {
		position: absolute;
	}
	</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- Slider -->
<h2 class="demoHeaders">Slider</h2>
<div id="slider"></div>

    </div>
    </form>
</body>
</html>
