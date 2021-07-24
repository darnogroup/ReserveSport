using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domin.Entity;
using Domin.Enum;
using Domin.Interface;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class UserRepository:IUserInterface
    {
        private readonly DataBaseContext _context;

        public UserRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<UserWalletModel> GetWalletUserById(int id)
        {
            return await _context.UserWallet.Where(w => w.UserId == id).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<UserModel>> GetTrashUsers()
        {
            return await _context.User.Where(w=>w.IsDelete==true).IgnoreQueryFilters().ToListAsync();
        }

        public async Task<UserModel> GetDeletedUserById(int id)
        {
            return await _context.User.Where(w => w.IsDelete == true).IgnoreQueryFilters()
                .SingleOrDefaultAsync(s => s.UserId == id);
        }

        public async Task<UserModel> GetPassword(string number)
        {
            return await _context.User.Where(w => w.IsActive == true && w.PhoneNumber == number).SingleOrDefaultAsync();
        }

        public void Create(UserModel model)
        {
            _context.User.Add(model);Save();
        }

        public void Update(UserModel model)
        {
            _context.Update(model);Save();
        }

        public void Delete(UserModel model)
        {
            _context.User.Remove(model);Save();
        }

        public void CreateWallet(UserWalletModel model)
        {
            _context.UserWallet.Add(model);Save();
        }

        public void UpdateWallet(UserWalletModel model)
        {
            _context.Update(model);Save();
        }

        public void DeleteWallet(UserWalletModel model)
        {
            _context.UserWallet.Remove(model);Save();
        }

        public async Task<bool> CheckPhoneNumber(string number)
        {
            return await _context.User.AnyAsync(a => a.PhoneNumber == number);
        }

        public async Task<UserModel> GetUserLoginInfo(string number, string password)
        {
            return await _context.User
                .Where(w =>w.IsActive==true&& w.PhoneNumber == number && w.Password == password).SingleOrDefaultAsync();
        }

        public async Task<RoleEnum> GetRole(int id)
        {
            return await _context.User.Where(w => w.UserId == id).Select(s => s.Role).SingleOrDefaultAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
