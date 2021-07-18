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
    public class SettingRepository:ISettingInterface
    {
        private readonly DataBaseContext _context;

        public SettingRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<SettingModel> GetSetting(int id)
        {
            return await _context.Setting.FindAsync(id);
        }

        public void Create(SettingModel model)
        {
            _context.Setting.Add(model);Save();
        }

        public void Update(SettingModel model)
        {
            _context.Update(model);Save();
        }

        public async Task<IEnumerable<ComplaintModel>> GetAllComplaint()
        {
            return await _context.ComplaintModels.ToListAsync();

        }

        public void CreateComplaint(ComplaintModel model)
        {
            _context.ComplaintModels.Add(model);
            Save();
        }
    

        public void RemoveComplaint(int id)
        {
            var model = _context.ComplaintModels.Find(id);
            _context.ComplaintModels.Remove(model);Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task<AboutModel> GetAbout(int id)
        {
            return await _context.AboutModels.SingleOrDefaultAsync(s => s.AboutId == id);
        }

        public async Task<bool> ExistAbout(int id)
        {
            return await _context.AboutModels.AnyAsync(a => a.AboutId == id);
        }

        public void Insert(AboutModel model)
        {
            _context.AboutModels.Add(model); Save();
        }

        public void Edit(AboutModel model)
        {
            _context.Update(model); Save();
        }

        public void InsertContact(ContactModel model)
        {
            _context.ContactModels.Add(model); Save();
        }

        public async Task<IEnumerable<ContactModel>> GetContact()
        {
            return await _context.ContactModels.ToListAsync();
        }
    }
}
