using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class SportModel
    {
        [Key]
        public int SportId { set; get; }
        [Required(ErrorMessage = "نام رشته ورزشی را وارد کنید")]
        [MaxLength(200, ErrorMessage = "طول نام رشته ورزشی از حد مجاز بیشتر است")]
        public string SportName { set; get; }
        public string SportDescription { set; get; }
        public bool IsDelete { set; get; } = false;
        public ICollection<SportCollectionModel>SportCollection { set; get; }
    }
}
