using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Collection
{
    public class FinancialViewModel
    {
        public int FinancialId { set; get; }
        public string FinancialPrice { set; get; }
        public string FinancialSheba { set; get; }
        public string FinancialNumber { set; get; }
        public string FinancialCard { set; get; }
        public string Debtor { set; get; }
        public int CollectionId { set; get; }
    }
}
