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



	$("a.Edit").click(function (e) {
		e.preventDefault();
		let ancher = $(this);
		let value = $(ancher.attr("data-target"));

		let newValue = prompt("Enter ny værdi", value.html());
		value.html(newValue);
		$.post("/Home/update", { jPath: ancher.attr("data-jPath"), value: newValue }).done(function (data) {
			console.log(data);
		});
	})
});