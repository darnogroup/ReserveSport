using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entity;

namespace Domin.Interface
{
    public interface ISmsInterface
    {
        Task<SmsAdminModel> GetAdminSms(int id);
        Task<SmsCustomerModel> GetCustomerSms(int id);
        Task<SmsGeneralModel> GetGeneralSms(int id);
        Task<SmsThankModel> GetThankSms(int id);
        Task<SmsRememberModel> GetRememberSms(int id);
        void CreateAdmin(SmsAdminModel model);
        void CreateCustomer(SmsCustomerModel model);
        void CreateGeneral(SmsGeneralModel model);
        void CreateThank(SmsThankModel model);
        void CreateRemember(SmsRememberModel model);
        void UpdateSmsAdmin(SmsAdminModel model);
        void UpdateCustomer(SmsCustomerModel model);
        void UpdateGeneral(SmsGeneralModel model);
        void UpdateThank(SmsThankModel model);
        void UpdateRemember(SmsRememberModel model);
    }
}
