$('#myForm').each(function () {   // <- selects every <form> on page
    $(this).validate({        // <- initialize validate() on each form
        error: function (label) {
            $(this).addClass("error");
        },

        rules: {
            name: {
                required: true

            },
            email: {
                required: true,
                email: true               

            },
            phoneNumber: {
                required: true,
                number: true
            },
            message: {
                required: true,
                minlength: 10
            }
        },

        messages: {
            name: {
                required: "Udfyld navn"

            },
            email: {
                required: "Udfyld e-mail",
                email: "Denne e-mail er ikke gyldig."
            },
            phoneNumber: {
                required: "Udfyld telefonnummer",
                number: "Dette er ikke et gyldigt telefonnummer",
                minlength: "Dette er ikke et gyldigt telefonnummer"

            },
            message: {
                required: "Du mangler at skrive en besked!",
                minlength: "Din besked er lige kort nok, skriv lidt mere, tak! "

            }


        }
    });
});


