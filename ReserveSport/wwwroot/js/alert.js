function DeleteState(id) {
    Swal.fire({
        title: 'آیا استان پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/State/Delete/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' استان به لیست حذفیات اضافه شد',
                'success'
            );
        }
    });
}
function BackState(id) {
    Swal.fire({
        title: 'آیا استان بازگردانی شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله بازگردانی شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/State/Back/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' استان به لیست اصلی اضافه شد',
                'success'
            );
        }
    });
}
function RemoveState(id) {
    Swal.fire({
        title: 'آیا استان کلا پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/State/Remove/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' استان به پاک شد',
                'success'
            );
        }
    });
}
//************************************//
function DeleteCity(id) {
    Swal.fire({
        title: 'آیا شهر پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/City/Delete/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' شهر به لیست حذفیات اضافه شد',
                'success'
            );
        }
    });
}
function BackCity(id) {
    Swal.fire({
        title: 'آیا شهر بازگردانی شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله بازگردانی شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/City/Back/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' شهر به لیست اصلی اضافه شد',
                'success'
            );
        }
    });
}
function RemoveCity(id) {
    Swal.fire({
        title: 'آیا شهر کلا پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/City/Remove/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' شهر به پاک شد',
                'success'
            );
        }
    });
}
//************************************//
function DeleteSport(id) {
    Swal.fire({
        title: 'آیا رشته پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/Sport/Remove/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' رشته به لیست حذفیات اضافه شد',
                'success'
            );
        }
    });
}
function BackSport(id) {
    Swal.fire({
        title: 'آیا رشته بازگردانی شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله بازگردانی شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/Sport/Back/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' رشته به لیست اصلی اضافه شد',
                'success'
            );
        }
    });
}
function RemoveSport(id) {
    Swal.fire({
        title: 'آیا رشته پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/Sport/Delete/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' رشته پاک شد',
                'success'
            );
        }
    });
}
//************************************//
function DeleteUser(id) {
    Swal.fire({
        title: 'آیا کاربر پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/User/Delete/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' کاربر پاک شد',
                'success'
            );
        }
    });
}
function BackUser(id) {
    Swal.fire({
        title: 'آیا کاربر بازگردانی شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله بازگردانی شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/User/Back/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' کاربر به لیست اصلی اضافه شد',
                'success'
            );
        }
    });
}
function RemoveUser(id) {
    Swal.fire({
        title: 'آیا کاربر پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/User/Remove/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' کاربر به لیست حذفیات شد',
                'success'
            );
        }
    });
}
/* Change Image */
function ChangeImage(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            if ($("#NewImg").hasClass("d-none")) {
                $("#NewImg").removeClass(" d-none");
            }
            $('#NewImg')
                .attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}

/* Change Image */
function ChangePhoto(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            if ($("#NewPhoto").hasClass("d-none")) {
                $("#NewPhoto").removeClass(" d-none");
            }
            $('#NewPhoto')
                .attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}
$(document).ready(function () {
    $("#State").change(function () {
        var groupId = $("#State").val();
        $.getJSON("/Admin/collection/CityList/" + groupId,
            function (res) {
                var item = "";
                $.each(res,
                    function (i, sub) {
                        item += '<option value="' + sub.value + '">' + sub.text + '</option>';
                    });
                $("#City").html(item);

            });
    });
  
});
//************************************//
function DeleteReserve(id) {
    Swal.fire({
        title: 'آیا سانس پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/Reserve/Delete/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' سانس پاک شد',
                'success'
            );
        }
    });
}
function RemoveCollection(id) {
    Swal.fire({
        title: 'آیا مجموعه پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/Collection/Remove/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' مجموعه پاک شد',
                'success'
            );
        }
    });
}
function BackCollection(id) {
    Swal.fire({
        title: 'آیا مجموعه بازگردانی شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله بازگردانی شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/Collection/Back/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                '  مجموعه بازگردانی شد',
                'success'
            );
        }
    });
}
function DeleteCollection(id) {
    Swal.fire({
        title: 'آیا مجموعه پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/Collection/Delete/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' مجموعه پاک شد',
                'success'
            );
        }
    });
}
function RemoveImage(id) {
    Swal.fire({
        title: 'آیا تصویر پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/Collection/RemoveImage/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' تصویر پاک شد',
                'success'
            );
        }
    });
}
function DeleteArticle(id) {
    Swal.fire({
        title: 'آیا مقاله پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/Article/Delete/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' مقاله پاک شد',
                'success'
            );
        }
    });
}
function RemoveArticle(id) {
    Swal.fire({
        title: 'آیا مقاله پاک شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله پاک شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/Article/Remove/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' مقاله به لیست حذفیات شد',
                'success'
            );
        }
    });
}
function BackArticle(id) {
    Swal.fire({
        title: 'آیا مقاله بازگردانی شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله بازگردانی شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/Article/Back/" + id);
            $("#item_" + id).hide('slow');
            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' مقاله بازگردانی شد',
                'success'
            );
        }
    });
}
function Close(id) {
    Swal.fire({
        title: 'آیا تیکت بسته شود؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله بسته شود',
        cancelButtonText: 'انصراف'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/Ticket/Close/" + id);
            location.reload();

            Swal.fire(
                'عملیات موفقیت آمیز بود',
                ' تیکت بسته شد',
                'success'
            );
        }
    });
}
