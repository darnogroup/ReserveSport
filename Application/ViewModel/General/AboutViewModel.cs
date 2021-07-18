using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.General
{
    public class AboutViewModel
    {
        public int AboutId { set; get; }
        public string ImagePath { set; get; }
        public IFormFile AboutImage { set; get; }
        public string AboutBody { set; get; }
        public string AboutSlogan { set; get; }
    }
}
