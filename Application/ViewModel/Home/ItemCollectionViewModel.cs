using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Home
{
    public class ItemCollectionViewModel
    {
        public int CollectionId { set; get; }
        public string Image { set; get; }
        public string CollectionName { set; get; }
        public string CollectionState { set; get; }
        public string CollectionCity { set; get; }
        public string CollectionNumber { set; get; }
    }
}
