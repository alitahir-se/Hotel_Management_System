$(document).ready(function () {

    $(".dropdown-button").dropdown();
    $('.modal').modal();


    $('.carousel.carousel-slider').carousel();
    setInterval(function () {
        $('.carousel').carousel('next');
    }, 5000);

   

});

function ShowPopup() {
    $("#btnShowPopup").click();
}

function Sign() {


    window.location.assign = "../signup/signup.aspx"

}