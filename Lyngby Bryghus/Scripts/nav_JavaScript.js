$(window).scroll(function () {
    if ($(this).scrollTop() > 50)  /*height in pixels when the navbar becomes non opaque*/ {
        $('.opaque-navbar').addClass('opaque');
    } else {
        $('.opaque-navbar').removeClass('opaque');
    }
});



var urlname = window.location.href;

// passes on every element with a class ".link"
$(".link").each(function () {
    // checks if its the same on the address bar
    if (urlname == (this.href)) {
        $(this).closest(".link").toggleClass("hovered");
    }
});


$(".btn-edit").mouseover(function () {
    $(this).closest("div.textbox").addClass("deco");


});

$(".btn-edit").mouseout(function () {
    $(this).closest("div.textbox").removeClass("deco");
});
