using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Sms;

namespace Application.Interface
{
    public interface ISmsService
    {
        Task<SmsAdminViewModel> GetSmsAdmin(int id);
        void SmsAdmin(SmsAdminViewModel model);
        Task<SmsCustomerViewModel> GetSmsCustomer(int id);
        void SmsCustomer(SmsCustomerViewModel model);
        Task<SmsGeneralViewModel> GetSmsGeneral(int id);
        void SmsGeneral(SmsGeneralViewModel model);
        Task<SmsRememberViewModel> GetSmsRemember(int id);
        void SmsRemember(SmsRememberViewModel model);
        Task<SmsThankViewModel> GetSmsThank(int id);
        void SmsThank(SmsThankViewModel model);
    }
}
