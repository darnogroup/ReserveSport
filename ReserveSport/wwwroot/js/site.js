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
    $("#ErrorLogin").click(function() {
        Swal.fire({
            confirmButtonText: 'متوجه شدم',
            icon: 'error',
            title: 'خطا',
            text: 'برای ثبت دیدگاه وارد سایت شوید',
            footer: '<a href="/login">ورود به سایت</a>'
        });
    });
    $("#commentbtn").click(function () {
        var body = $("#commentBody").val();
        var id = $("#id").val();
        if (body) {
            $.ajax({
                url: "/comment", //1
                data: { body: body, id: id }, //2
                type: "Post", //3
                datatype: "Json", //4
                beforeSend: function() {
                    //5
                },
                success: function(result) {
                    Swal.fire({
                     
                        icon: 'success',
                        title: 'دیدگاه شما ثبت شد بعد از تائید منتشر میشود',
                        showConfirmButton: false,
                        timer: 1500
                    });
                },
                error: function() { //7

                }
            });
        } else {
            Swal.fire({
                title: 'دیدگاه نمیتواند خالی باشد', confirmButtonText: 'متوجه شدم',
                showClass: {
                    popup: 'animate__animated animate__fadeInDown'
                },
                hideClass: {
                    popup: 'animate__animated animate__fadeOutUp'
                }
               
            });
        }
    });
});
