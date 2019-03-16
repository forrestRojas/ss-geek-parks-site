// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.addEventListener("load", startup);

function startup() {
    var el = document.getElementById("tempConvertButton");
    if (el) {
        if (el.addEventListener)
            el.addEventListener("click", ConvertTemp, false);
        else if (el.attachEvent)
            el.attachEvent('onclick', ConvertTemp);
    }
}

/* Converts the tempture for fahren to Celcius */ 
function ConvertTemp() {
    const freezingFahren = 32;
    const conversionFactorFahren = 5 / 9;
    const conversionFactorCelcius = 9 / 5;
    const buttonId = "tempConvertButton";

    var temps = document.querySelectorAll(".highTemp, .lowTemp");
    var Tempbutton = document.getElementById(buttonId);
    var TempbuttonValue = Tempbutton.value;
    var isFahren = Boolean("To Celcius" == TempbuttonValue);

    temps.forEach(function (tempNode) {
        let temp = tempNode.textContent;
        if (isFahren) {
            let ctemp = ((temp - freezingFahren) * conversionFactorFahren);
            tempNode.textContent = ctemp.toPrecision(2);
        }
        else {
            let ctemp = ((temp * conversionFactorCelcius) + freezingFahren);
            tempNode.textContent = ctemp.toPrecision(2);
        }
    });

    if (isFahren) {
        Tempbutton.value = "To Fahrenheit";
        Tempbutton.textContent = "To Fahrenheit";
    }
    else {
        Tempbutton.value = "To Celcius";
        Tempbutton.textContent = "To Celcius";
    }
}



/* Shrinks the site header */
$(function ShrinkSiteHeader() {
    var $win = $(window);
    var $body = $("body");
    var $headerImg = $("#site-name");
    var $header = $("#site-header");

    $win.scroll(function () {
        if ($win.scrollTop() <= 300) {
            $body.css("margin-top", ($win.scrollTop() + "px"));
            $header.removeClass("sticky");
        }
        else {
            $header.addClass("sticky");
        }
        if ($win.scrollTop() == 0) {
            $headerImg.removeClass("shrink");
            $body.removeClass("shrink");
        }
        else {
            $headerImg.addClass("shrink");
            $body.addClass("shrink");
        }
    });
});


$(document).ready(function () {
    //call here
    ShrinkSiteHeader();
});