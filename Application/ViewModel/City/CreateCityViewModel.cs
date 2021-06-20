﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.City
{
    public class CreateCityViewModel
    {
       
        [Required(ErrorMessage = "نام شهر الزامی است")]
        [MaxLength(100, ErrorMessage = "طول نام شهر از حد مجاز بیشتر است")]
        public string CityName { set; get; }
        public int StateId { set; get; }
      
    }
}
