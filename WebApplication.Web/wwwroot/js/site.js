// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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

var el = document.getElementById("tempConvertButton");
if (el.addEventListener)
    el.addEventListener("click", ConvertTemp, false);
else if (el.attachEvent)
    el.attachEvent('onclick', ConvertTemp);

/* Shrinks the site header */
$(function ShrinkSiteHeader() {
    var $win = $(window);

    $win.scroll(function () {
        if ($win.scrollTop() == 0)
            $("#site-name").removeClass("shrink");
        else {
            $("#site-name").addClass("shrink");
        }
    });
});


$(document).ready(function () {
    //call here
    ShrinkSiteHeader();
});