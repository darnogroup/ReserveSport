using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Collection
{
    public class EditCollectionViewModel
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
        [Required(ErrorMessage = "مدیر مجموعه را وارد کنید")]
        public string UserId { get; set; }
        public IFormFile License{ set; get; }
        public List<int> Sports { set; get; }
        public string LicensePath { set; get; }
        public int CollectionId { set; get; }
        public int UserOld { set; get; }
    }
}
