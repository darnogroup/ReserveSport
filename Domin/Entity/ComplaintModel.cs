using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class ComplaintModel
    {
        [Key]
        public int ComplaintId { set; get; }
        [Required(ErrorMessage = "نام و نام خانوادگی الزامی است")]
        [MaxLength(150, ErrorMessage = "طول نام و نام خانوادگی از حد مجاز بیشتر است")]
        public string ComplaintUserName { set; get; }
        [Required(ErrorMessage = "شماره تماس الزامی است")]
        public string ComplaintPhoneNumber { set; get; }
        public string ComplaintMail { set; get; }
        [Required(ErrorMessage = "عنوان شکایت الزامی است")]
        [MaxLength(200, ErrorMessage = "طول عنوان شکایت از حد مجاز بیشتر است")]
        public string ComplaintTitle { set; get; }
        [Required(ErrorMessage = "متن شکایت الزامی است")]
        [MaxLength(800, ErrorMessage = "طول متن از حد مجاز بیشتر است")]
        public string ComplaintDescription { set; get; }
    }
}
