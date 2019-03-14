/* Shrinks the site header */
$(function shrinkSiteHeader() {
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
    shrinkSiteHeader();
});