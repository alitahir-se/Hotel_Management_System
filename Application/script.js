$(document).ready(function () {

    $(".dropdown-button").dropdown();
    $('select').material_select();
    $('.modal').modal();

    $('.datepicker').pickadate({
        selectMonths: true,
        selectYears: 100

    });



});

function showPassword() {
    var x = document.getElementById("passwordApp");
    var s = document.getElementById("description");
    if (jobType.value == "") {

        x.style.display = "none";
        s.style.display = "none";
    }
    else if (jobType.value == "1") {
        x.style.display = "block";
        s.style.display = "none";
    } else if (jobType.value == "2") {
        x.style.display = "block";
        s.style.display = "none";
    } else if (jobType.value == "3") {
        x.style.display = "none";
        s.style.display = "block";
    }

}