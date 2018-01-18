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



	let value;
	$("a.Edit").click(function (e) {
		e.preventDefault();
		let Editor = $("#Editor");
		Editor.show();
		let ancher = $(this);
		let title = ancher.attr("data-Title");
		let jPath = ancher.attr("data-jPath");
		value = $(ancher.attr("data-target"));

		Editor.find("form input[name=jPath]").val(jPath);
		Editor.find("form .Title").val(title);
		Editor.find("form textarea").val(value.html());

		//let newValue = prompt("Enter ny værdi", value.html());
		//value.html(newValue);
		//$.post("/Home/update", { jPath: ancher.attr("data-jPath"), value: newValue }).done(function (data) {
		//	console.log(data);
		//});
	});

	/*document.forms.Editor.addEventListener("submit", function (e) {
		let Editor = $("#Editor");
		console.log($(this).serialize());
		Editor.hide();
		value.html(this.value.value);
		$.post("/Home/update", { jPath: escape(this.jPath.value), value: escape(this.value.value) }).done(function (data) {
			console.log(data);
		});
	});*/
});