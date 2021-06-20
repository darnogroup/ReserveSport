// initialize scrollspy
$('body').scrollspy({
    target: '.dotted-scrollspy'
});

function Send() {
    var number = document.getElementById("number").value;
    $.get("/sms/" + number);
    Swal.fire({
        icon: 'success',
        title: 'رمز یکبار مصرف برای شما ارسال شد',
        showConfirmButton: false,
        timer: 1500
    });
}