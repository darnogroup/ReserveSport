using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domin.Entity;
using Domin.Interface;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class CheckRepository:ICheckInterface
    {
        private readonly DataBaseContext _context;

        public CheckRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CheckoutModel>> GetCheckOuts()
        {
            return await _context.Checkout.Include(i => i.Collection).ToListAsync();
        }

        public async Task<IEnumerable<CheckoutModel>> GetCollectionCheckOuts(int id)
        {
            return await _context.Checkout.Where(w => w.CollectionId == id).ToListAsync();
        }

        public async Task<CheckoutModel> GetCheck(int id)
        {
            return await _context.Checkout.FindAsync(id);
        }

        public void Create(CheckoutModel model)
        {
            _context.Checkout.Add(model);Save();
        }

        public void Update(CheckoutModel model)
        {
            _context.Update(model);Save();
        }

        public async Task<FinancialModel> GetFinancial(int id)
        {
            return await _context.Financial.Include(i=>i.Collection)
                .SingleOrDefaultAsync(s=>s.FinancialId==id);
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
