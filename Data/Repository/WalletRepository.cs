using Data.Context;
using Domin.Entity;
using Domin.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class WalletRepository:IWalletRepository
    {
        private readonly DataBaseContext _context;

        public WalletRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<UserWalletModel> GetWalletByUserId(int userId)
        {
            return await _context.UserWallet.SingleOrDefaultAsync(n=> n.UserId == userId);
        }
        public void UpdateWallet(UserWalletModel model)
        {
            _context.Update(model);
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}