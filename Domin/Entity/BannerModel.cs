using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class BannerModel
    {
        [Key]
      public int Id { set; get; }
      [Required(ErrorMessage = "این فیلد الزامی است")]
      public string Image { set; get; }
      public int CollectionId { set; get; }
      [ForeignKey("CollectionId")]
      public CollectionModel Collection { set; get; }
    }
}
