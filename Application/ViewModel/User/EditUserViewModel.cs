using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Enum;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.User
{
    public class EditUserViewModel
    {
        public int UserId { set; get; }
        [Required]
        public EnumRole Role { get; set; }
        public EnumRole OldRole { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = ("{0} نمیتواند بیشتر از {1} باشد"))]
        public string UserName { get; set; }
        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^0[0-9]{10}$", ErrorMessage = "شماره موبایل وارد شده معتبر نمیباشد")]
        public string PhoneNumber { get; set; }

        [Display(Name = "کد ملی")]
        [MaxLength(200, ErrorMessage = ("{0} نمیتواند بیشتر از {1} باشد"))]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "کد ملی وارد شده معتبر نمیباشد")]
        public string NationalCode { get; set; }
        [Display(Name = "تصویر کاربر")]
        public string UserImage { get; set; }
        public IFormFile UserImageFile { set; get; }
        public bool IsActive { get; set; } = false;
        public string OldPhoneNumber { set; get; }
    }
}
