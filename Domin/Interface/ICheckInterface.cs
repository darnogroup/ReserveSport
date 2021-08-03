using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entity;

namespace Domin.Interface
{
    public interface ICheckInterface
    {
        Task<IEnumerable<CheckoutModel>> GetCheckOuts();
        Task<IEnumerable<CheckoutModel>> GetCollectionCheckOuts(int id);
        Task<CheckoutModel> GetCheck(int id);
        void Create(CheckoutModel model);
        void Update(CheckoutModel model);
        Task<FinancialModel> GetFinancial(int id);
    }
}
