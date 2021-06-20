using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
   public class CityModel
    {
        [Key]
        public int CityId { set; get; }
        [Required(ErrorMessage = "نام شهر الزامی است")]
        [MaxLength(100, ErrorMessage = "طول نام شهر از حد مجاز بیشتر است")]
        public string CityName { set; get; }
        public bool IsDelete { set; get; } = false;
        public int StateId { set; get; }
        [ForeignKey("StateId")]
        public StateModel State { set; get; }
        public List<CollectionModel> Collection { set; get; }
    }
}
