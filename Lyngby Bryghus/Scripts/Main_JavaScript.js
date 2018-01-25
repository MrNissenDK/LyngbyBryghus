
let searchValue = "";
var lastScreenX = null;
$(function () {
	if (localStorage.getItem("AdminBox") != null) {
		$("#AdminBox").css("right", localStorage.getItem("AdminBox"));
		$("#AdminBox").css("display","");
	}
	document.addEventListener("touchmove", function (e) {
		let sx = e.changedTouches[0].screenX;
		if (sx >= window.innerWidth*0.95 && sx <= window.innerWidth) {
			var drag = 0;
			if (lastScreenX)
				drag = e.changedTouches[0].screenX -lastScreenX;
			lastScreenX = e.changedTouches[0].screenX;

			if (drag < 0) {
				localStorage.setItem("AdminBox", "-10px");
				$("#AdminBox").css("right", "-10px");
			} else if (drag > 0) {
				localStorage.setItem("AdminBox", "-145px");
				$("#AdminBox").css("right", "-145px");
			}
		} else {
			lastScreenX = null;
		}
	},false);
	document.addEventListener("mousemove", function (e) {
		console.log(e);
		if (e.buttons == 1 && e.screenX >= window.innerWidth * 0.95 && e.screenX <= window.innerWidth) {
			var drag = 0;
			if (lastScreenX)
				drag = e.screenX - lastScreenX;
			lastScreenX = e.screenX;

			if (drag < 0) {
				localStorage.setItem("AdminBox", "-10px");
				$("#AdminBox").css("right", "-10px");
			} else if (drag > 0) {
				localStorage.setItem("AdminBox", "-145px");
				$("#AdminBox").css("right", "-145px");
			}
		} else {
			lastScreenX = null;
		}
	}, false);




	$("a.cattegoryLink").click(function (e) {
		e.preventDefault();
		let ancher = $(this);
		let Tag = ancher.attr("data-tag");
		window.history.pushState(null, ancher.attr("href"), ancher.attr("href"));
		if (Tag === "*") {
			$("div.gallery_product").slideUp(300);
			setTimeout(function () {
				$("div.gallery_product").slideDown(300);
			}, 400);
		}
		else {
			$("div.gallery_product").slideUp(300);
			setTimeout(function () {
				$("[data-tags*=\"" + Tag + "\"]").slideDown(300);
			},400);
		}
	});

	let dom = new DOMParser();
	tinymce.init({
		selector: '#Editor textarea',
		forced_root_block: false,
		height: 467,
		force_br_newlines: true,
		force_p_newlines: false,
		border: 0,
		width: 498,
		init_instance_callback: function (editor) {
			editor.on('KeyDown', function (e) {
				if(tinymce.activeEditor.selection.dom.doc.body.outerHTML.indexOf(searchValue) == -1)
					tinymce.activeEditor.execCommand('mceSetContent', true, searchValue);
			});
		},
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

		let index = value[0].outerHTML.indexOf(value[0].innerHTML);
		searchValue = value[0].outerHTML.substring(0, index);

		tinymce.activeEditor.execCommand('mceSetContent', true, value[0].outerHTML);

		setTimeout(function () { Editor.show();}, 1);
	});
	$("#Editor > form > button.close-button").click(function (e) {
		let Editor = $("#Editor");
		Editor.hide();
	});
});