using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.General
{
    public class ContactsViewModel
    {
        public int Id { set; get; }
        public string ContactName { set; get; }

        public string ContactNumber { set; get; }

        public string ContactBody { set; get; }
    }
}
