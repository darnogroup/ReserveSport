using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
   public class SportCollectionModel
    {
        [Required]
        public int CollectionId { get; set; }
        [Required]
        public int SportId { set; get; }
        /***********************************/
        [ForeignKey("SportId")]
        public SportModel Sport { set; get; }
        [ForeignKey("CollectionId")]
        public CollectionModel Collection { set; get; }
    }
}
