function ShowProducts(Tag) {
    if (Tag === "*") {
        $("a.gallery_product").show();
    }
    else {
        $("a.gallery_product").hide();
        $("[data-tags*=\"" + Tag + "\"]").show();
    }
    
}






































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
