(function () {
    window.addEventListener("load", function () {
        setTimeout(function () {
            var logo = document.getElementsByClassName('link'); //For Changing The Link On The Logo Image
            logo[0].href = "#";
            logo[0].target = "_blank";
            logo[0].children[0].alt = "The ESBS REST API Documentation";
            logo[0].children[0].src = "https://crmdr.org/assets/media/logos/ecrin-logo.jpg"; //For Changing The Logo Image
        });
    });
})();