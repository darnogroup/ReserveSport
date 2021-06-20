using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domin.Entity;
using Domin.Interface;

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

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
