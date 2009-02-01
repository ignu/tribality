// for visual studio intellisense:
/// <reference path="jquery.js" />
$.fn.background = function(color){
    return $(this).css("background-color", color);
}

$.fn.highlight = function(otherColor) { 
    var delay = 50;
    var interval = 5;
    
    if (!otherColor)
	    otherColor = 180;
    
    var item = $(this);
    
    if(otherColor > 255) {
        item.background("#FFFFFF");
	}
    else {
	    item.background("rgb(255, " + otherColor + ","+ otherColor + ")");
	    otherColor += interval;
	    setTimeout(function() {item.highlight(otherColor);}, delay);
    }
    return $(this);
}
