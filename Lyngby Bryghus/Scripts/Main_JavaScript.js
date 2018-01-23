$(function () {
	$("a.cattegoryLink").click(function (e) {
		e.preventDefault();
		let ancher = $(this);
		let Tag = ancher.attr("data-tag");
		window.history.pushState(null, ancher.attr("href"), ancher.attr("href"));
		if (Tag === "*") {
			$("a.gallery_product").slideUp(300);
			setTimeout(function () {
				$("a.gallery_product").slideDown(300);
			}, 400);
		}
		else {
			$("a.gallery_product").slideUp(300);
			setTimeout(function () {
				$("[data-tags*=\"" + Tag + "\"]").slideDown(300);
			},400);
		}
	});
	tinymce.init({
		selector: '#Editor textarea',
		forced_root_block: "",
		height: 467,
		border: 0,
		width: 498,
		verify_html: false,
		plugins: [
			"advlist autolink lists link image charmap print preview anchor",
			"searchreplace visualblocks code fullscreen",
			"insertdatetime media table paste imagetools wordcount"
		],
		toolbar: "insertfile undo redo | bold italic | alignleft aligncenter alignright alignjustify | outdent indent | link image",
		// imagetools_cors_hosts: ['www.tinymce.com', 'codepen.io'],
		content_css: [
			'/bootstrap-3.3.7-dist/css/bootstrap.min.css',
			'/bootstrap-3.3.7-dist/css/bootstrap-theme.min.css',
			'/CascadingStyleSheet/font-awesome-4.7.0/css/font-awesome.css'
		]
	});

	let value;
	$("a.Edit").click(function (e) {
		e.preventDefault();
		let Editor = $("#Editor");
		let ancher = $(this);
		let title = ancher.attr("data-Title");
		let jPath = ancher.attr("data-jPath");
		value = $(ancher.attr("data-target"));
		Editor.find("form input[name=jPath]").val(jPath);
		Editor.find("form .Title").text(title);

		tinymce.remove();
		tinymce.init({
			selector: '#Editor textarea',
			forced_root_block: value.prop("tagName"),
			forced_root_block_attrs: { class: value.attr("class") },
			height: 467,
			border: 0,
			width: 498,
			verify_html: false,
			plugins: [
				"advlist autolink lists link image charmap print preview anchor",
				"searchreplace visualblocks code fullscreen",
				"insertdatetime media table paste imagetools wordcount"
			],
			toolbar: "insertfile undo redo | bold italic | alignleft aligncenter alignright alignjustify | outdent indent | link image",
			// imagetools_cors_hosts: ['www.tinymce.com', 'codepen.io'],
			content_css: [
				'/bootstrap-3.3.7-dist/css/bootstrap.min.css',
				'/bootstrap-3.3.7-dist/css/bootstrap-theme.min.css',
				'/CascadingStyleSheet/font-awesome-4.7.0/css/font-awesome.css'
			]
		});

		tinymce.activeEditor.execCommand('mceSetContent', true, value[0].outerHTML);

		setTimeout(function () { Editor.show();}, 1);
	});
	$("#Editor > form > button.close-button").click(function (e) {
		let Editor = $("#Editor");
		Editor.hide();
	});
});