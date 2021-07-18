using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.General
{
    public class ComplaintViewModel
    {
        public int Id { set; get; }
        public string ComplaintUserName { set; get; }

        public string ComplaintPhoneNumber { set; get; }
        public string ComplaintMail { set; get; }
        public string ComplaintTitle { set; get; }
        public string ComplaintDescription { set; get; }
    }
}
