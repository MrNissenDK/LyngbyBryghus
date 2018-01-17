$(function () {
	$("a.cattegoryLink").click(function (e) {
		e.preventDefault();
		let ancher = $(this);
		let Tag = ancher.attr("data-tag");
		window.history.pushState(null, ancher.attr("href"), ancher.attr("href"));
		if (Tag === "*") {
			$("a.gallery_product").css("display", "block");
			$("a.gallery_product").css("position", "relative");
			$("a.gallery_product").animate({
				opacity: 1,
				display: "block"
			}, 300);
		}
		else {
			$("[data-tags*=\"" + Tag + "\"]").css("display", "block");
			$("[data-tags*=\"" + Tag + "\"]").css("position", "relative");
			$("[data-tags*=\"" + Tag + "\"]").animate({
				opacity: 1
			}, 300);
			$("a.gallery_product:not([data-tags*=\"" + Tag + "\"])").css("position", "absolute");
			$("a.gallery_product:not([data-tags*=\"" + Tag + "\"])").animate({
				opacity: 0,
			}, 300, function () {
				$(this).css("display","none");
			});
		}
	});
});






































//MENUEN skifter farve, når det er aktiv  START
// this will get the full URL at the address bar
//var url = window.location.href;

// passes on every element with a class ".link"
//$(".link").each(function () {
    // checks if its the same on the address bar
   // if (url == (this.href)) {
       // $(this).closest(".MT").addClass("active");
   // }
//});
//MENUEN skifter farve, når det er aktiv  SLUT
