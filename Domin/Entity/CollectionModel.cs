using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class CollectionModel
    {
        [Key]
        public int CollectionId { set; get; }
        [Required(ErrorMessage = "نام مجموعه را وارد کنید")]
        [MaxLength(200, ErrorMessage = "نام مجموعه از حد مجاز بیشتر است")]
        public string CollectionName { set; get; }
        [Required(ErrorMessage = "شماره تلفن مجموعه را وارد کنید")]
        public string CollectionPhoneNumber { set; get; }
        [Required(ErrorMessage = "نشانی مجموعه را وارد کنید")]
        [MaxLength(200, ErrorMessage = "نشانی مجموعه از حد مجاز بیشتر است")]
        public string CollectionAddress { set; get; }
        [Required(ErrorMessage = "مجوز مجموعه را وارد کنید")]
        public string LicensePath { set; get; }
        
        [Required(ErrorMessage = "استان مجموعه را وارد کنید")]
        public int StateId { set; get; }
        [ForeignKey("StateId")]
        public StateModel State { set; get; }
        [Required(ErrorMessage = "شهر مجموعه را وارد کنید")]
        public int CityId { set; get; }
        [ForeignKey("CityId")]
        public CityModel City { set; get; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserModel User { set; get; }
        public string Image { set; get; }
        public bool Active { set; get; } 
        public bool IsDelete { set; get; } = false;
        public ICollection<SportCollectionModel> SportCollection { set; get; }
        public IEnumerable<ReserveModel>Reserves { set; get; }
        public FinancialModel Financial { set; get; }
        public IEnumerable<BannerModel>Banner { set; get; }

    }
}
