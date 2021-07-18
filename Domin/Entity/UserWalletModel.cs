using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class UserWalletModel
    {
        [Key]
        public int WalletId { set; get; }
        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string WalletInventory { set; get; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserModel User { set; get; }
    }
}