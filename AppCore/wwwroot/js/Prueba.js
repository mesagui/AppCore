
   // alert("Hola mundoo");
    //onclick = alert('hola mundo!');


$('button').on('click',function () {
    $("h1").css("color","red");
});

$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44341/Tema/TablaDatos/',
        type: 'get'
    }).done(function (response) {
        $("div#tabla").html(response);
    });
});





