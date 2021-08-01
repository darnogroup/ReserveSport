// initialize scrollspy
$('body').scrollspy({
    target: '.dotted-scrollspy'
});

function Send() {
 
    var number = $("#number").val();
   
    $.get("/sms/" + number);
    Swal.fire({
        icon: 'success',
        title: 'رمز یکبار مصرف برای شما ارسال شد',
        showConfirmButton: false,
        timer: 1500
    });
}
