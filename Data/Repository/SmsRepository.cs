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
    public class SmsRepository:ISmsInterface
    {
        private readonly DataBaseContext _context;

        public SmsRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<SmsAdminModel> GetAdminSms(int id)
        {
            return await _context.SmsAdmin.FindAsync(id);
        }

        public async Task<SmsCustomerModel> GetCustomerSms(int id)
        {
            return await _context.SmsCustomer.FindAsync(id);
        }

        public async Task<SmsGeneralModel> GetGeneralSms(int id)
        {
            return await _context.SmsGeneral.FindAsync(id);
        }

        public async Task<SmsThankModel> GetThankSms(int id)
        {
            return await _context.SmsThank.FindAsync(id);
        }

        public async Task<SmsRememberModel> GetRememberSms(int id)
        {
            return await _context.SmsRemember.FindAsync(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public void CreateAdmin(SmsAdminModel model)
        {
            _context.SmsAdmin.Add(model);
            Save();
        }

        public void CreateCustomer(SmsCustomerModel model)
        {
            _context.SmsCustomer.Add(model);Save();
        }

        public void CreateGeneral(SmsGeneralModel model)
        {
            _context.SmsGeneral.Add(model);Save();
        }

        public void CreateThank(SmsThankModel model)
        {
            _context.SmsThank.Add(model);Save();
        }

        public void CreateRemember(SmsRememberModel model)
        {
            _context.SmsRemember.Add(model);Save();
        }

        public void UpdateSmsAdmin(SmsAdminModel model)
        {
            _context.Update(model);Save();
        }

        public void UpdateCustomer(SmsCustomerModel model)
        {
            _context.Update(model); Save();
        }

        public void UpdateGeneral(SmsGeneralModel model)
        {
            _context.Update(model); Save();
        }

        public void UpdateThank(SmsThankModel model)
        {
            _context.Update(model); Save();
        }

        public void UpdateRemember(SmsRememberModel model)
        {
            _context.Update(model); Save();
        }
    }
}
