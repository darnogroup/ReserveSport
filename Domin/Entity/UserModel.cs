using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Enum;

namespace Domin.Entity
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public RoleEnum Role { get; set; }
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
        public string Password { set; get; }
        [Required]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "کد فعال سازی")]
        public string ActiveCode { get; set; }

        public bool IsDelete { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public UserWalletModel Wallet { set; get; }
        public CollectionModel Collection { set; get; }
        public IEnumerable<CommentModel> Comments { set; get; }
        public IEnumerable<TicketModel>Ticket { set; get; }
        public IEnumerable<SubTicketModel>SubTicket { set; get; }
    }
}
