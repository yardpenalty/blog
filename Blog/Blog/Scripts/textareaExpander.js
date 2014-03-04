(function($) {

	// jQuery plugin definition
	$.fn.TextAreaExpander = function(minHeight, maxHeight) {

		// initialize
this.each(function() {

	// is a textarea?
	if (this.nodeName.toLowerCase() != "textarea") return;

	// set height restrictions
	var p = this.className.match(/expand(d+)-*(d+)*/i);
	this.expandMin = minHeight || (p ? parseInt('0'+p[1], 10) : 0);
	this.expandMax = maxHeight || (p ? parseInt('0'+p[2], 10) : 99999);

	// initial resize
	ResizeTextarea(this);

	// add events
	if (!this.Initialized) {
		this.Initialized = true;
		$(this).css("padding-top", 0).css("padding-bottom", 0);
		$(this).bind("onload", ResizeTextarea).bind("focus", ResizeTextarea);
	}
});

		return this;
	};

})(jQuery);

// brosswer = depricated ... must find workaround!
//
//var hCheck = !($.browser.msie || $.browser.opera);
// resize a textarea
function ResizeTextarea(e) {

	// event or element?
	e = e.target || e;

	// find content length and box width
	var vlen = e.value.length, ewidth = e.offsetWidth;
	if (vlen != e.valLength || ewidth != e.boxWidth) {
         	
		//if (hCheck && (vlen < e.valLength || ewidth != e.boxWidth)) e.style.height = "0px";
		var h = Math.max(e.expandMin, Math.min(e.scrollHeight, e.expandMax));

		e.style.overflow = (e.scrollHeight > h ? "auto" : "hidden");
		e.style.height = h + "px";

		e.valLength = vlen;
		e.boxWidth = ewidth;
	}

	return true;
};

$(function (){});