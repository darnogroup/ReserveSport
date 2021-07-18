using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class ContactModel
    {
        [Key]
        public int ContactId { set; get; }
        [Required(ErrorMessage = "نام و نام خانوادگی الزامی است")]
        [MaxLength(150, ErrorMessage = "طول نام و نام خانوادگی از حد مجاز بیشتر است")]
        public string ContactName { set; get; }
        [Required(ErrorMessage = "شماره تماس الزامی است")]
        public string ContactNumber { set; get; }
        [Required(ErrorMessage = " متن پیام الزامی است")]
        [MaxLength(150, ErrorMessage = "طول متن پیام از حد مجاز بیشتر است")]
        public string ContactBody { set; get; }
    }
}
