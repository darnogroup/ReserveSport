using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Account
{
    public class RegisterCollectionViewModel
    {
        [Required(ErrorMessage = "نام مجموعه را وارد کنید")]
        [MaxLength(200, ErrorMessage = "نام مجموعه از حد مجاز بیشتر است")]
        public string CollectionName { set; get; }
        [Required(ErrorMessage = "شماره تلفن مجموعه را وارد کنید")]
        public string CollectionPhoneNumber { set; get; }
        [Required(ErrorMessage = "نشانی مجموعه را وارد کنید")]
        [MaxLength(200, ErrorMessage = "نشانی مجموعه از حد مجاز بیشتر است")]
        public string CollectionAddress { set; get; }

        [Required(ErrorMessage = "استان مجموعه را وارد کنید")]
        public string StateId { set; get; }
        [Required(ErrorMessage = "شهر مجموعه را وارد کنید")]
        public string CityId { set; get; }
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
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string NationalCode { get; set; }
    }
}
