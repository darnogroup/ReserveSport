function ChangePhoto1(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            if ($("#NewPhoto1").hasClass("d-none")) {
                $("#NewPhoto1").removeClass(" d-none");
            }
            $('#NewPhoto1')
                .attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}
function ChangePhoto2(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            if ($("#NewPhoto2").hasClass("d-none")) {
                $("#NewPhoto2").removeClass(" d-none");
            }
            $('#NewPhoto2')
                .attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}
function ChangePhoto3(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            if ($("#NewPhoto3").hasClass("d-none")) {
                $("#NewPhoto3").removeClass(" d-none");
            }
            $('#NewPhoto3')
                .attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}