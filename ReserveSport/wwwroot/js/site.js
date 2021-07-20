// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("#inputState").change(function () {
        var id = $("#inputState").val();
        $.getJSON("/QuickReserve/CityList/" + id,
            function (res) {
                var item = "";
                $.each(res,
                    function (i, sub) {
                        item += '<option value="' + sub.value + '">' + sub.text + '</option>';
                    });
                $("#inputCity").html(item);

            });
    });
  
});
