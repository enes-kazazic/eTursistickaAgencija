// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var connection = new signalR.HubConnectionBuilder().withUrl("/myhub").build();

connection.on("ReceiveMessage", function ( message) {
    if (message && message.toLowerCase() == "new") {
        var count = parseInt($("#notification").html()) || 0;
        count++;
        $("#notification").show();
        $("#notification").html(count);
    }
});


connection.start().then(function () {
    console.info("started SignalR hub....");
}).catch(function (err) {
    return console.error(err.toString());
});

$("#notification").click(function (e) {
    e.stopPropagation();
    var count = 0;
    count = parseInt($('#notification').html()) || 0;
    $('#notification', this).html('0');
    resetCountKorisnik();
});