using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel.Sms;
using Domin.Entity;
using Domin.Interface;

namespace Application.Service
{
    public class SmsService : ISmsService
    {
        private readonly ISmsInterface _sms;

        public SmsService(ISmsInterface sms)
        {
            _sms = sms;
        }
        public async Task<SmsAdminViewModel> GetSmsAdmin(int id)
        {
            SmsAdminViewModel admin=new SmsAdminViewModel();
            var model = await _sms.GetAdminSms(id);
            if (model == null)
            {
                SmsAdminModel sms=new SmsAdminModel();
                _sms.CreateAdmin(sms);
                
            }
            else
            {
                admin.CodeText = model.CodeText;
                admin.DayText = model.DayText;
                admin.EndText = model.EndText;
                admin.NameText = model.NameText;
                admin.PriceText = model.PriceText;
                admin.SiteLink = model.SiteLink;
                admin.SiteText = model.SiteText;
                admin.SportText = model.SportText;
                admin.StartText = model.StartText;
            }

            return admin;
        }

        public void SmsAdmin(SmsAdminViewModel model)
        {
            var admin = _sms.GetAdminSms(1).Result;
            admin.CodeText = model.CodeText;
            admin.DayText = model.DayText;
            admin.EndText = model.EndText;
            admin.NameText = model.NameText;
            admin.PriceText = model.PriceText;
            admin.SiteLink = model.SiteLink;
            admin.SiteText = model.SiteText;
            admin.SportText = model.SportText;
            admin.StartText = model.StartText;
            _sms.UpdateSmsAdmin(admin);
        }

        public async Task<SmsCustomerViewModel> GetSmsCustomer(int id)
        {
            SmsCustomerViewModel customer = new SmsCustomerViewModel();
            var model = await _sms.GetCustomerSms(id);
            if (model == null)
            {
                SmsCustomerModel sms = new SmsCustomerModel();
                _sms.CreateCustomer(sms);

            }
            else
            {
                customer.CollectionText = model.CollectionText;
                customer.DayText = model.DayText;
                customer.EndText = model.EndText;
                customer.NameText = model.NameText;
                customer.PriceText = model.PriceText;
                customer.SiteLink = model.SiteLink;
                customer.SiteText = model.SiteText;
                customer.AddressText = model.AddressText;
                customer.StartText = model.StartText;
            }

            return customer;
        }

        public void SmsCustomer(SmsCustomerViewModel model)
        {
            var customer = _sms.GetCustomerSms(1).Result;
            customer.CollectionText = model.CollectionText;
            customer.DayText = model.DayText;
            customer.EndText = model.EndText;
            customer.NameText = model.NameText;
            customer.PriceText = model.PriceText;
            customer.SiteLink = model.SiteLink;
            customer.SiteText = model.SiteText;
            customer.AddressText = model.AddressText;
            customer.StartText = model.StartText;
            _sms.UpdateCustomer(customer);
        }

        public async Task<SmsGeneralViewModel> GetSmsGeneral(int id)
        {
            SmsGeneralViewModel general = new SmsGeneralViewModel();
            var model = await _sms.GetGeneralSms(id);
            if (model == null)
            {
                SmsGeneralModel sms = new SmsGeneralModel();
                _sms.CreateGeneral(sms);

            }
            else
            {
                general.ActiveCollection = model.ActiveCollection;
                general.ActiveText = model.ActiveText;
                general.AnswerText = model.AnswerText;
                general.TemporaryText = model.TemporaryText;
            }

            return general;
        }

        public void SmsGeneral(SmsGeneralViewModel model)
        {
            var general = _sms.GetGeneralSms(1).Result;
            general.ActiveCollection = model.ActiveCollection;
            general.ActiveText = model.ActiveText;
            general.AnswerText = model.AnswerText;
            general.TemporaryText = model.TemporaryText;
            _sms.UpdateGeneral(general);
        }

        public async Task<SmsRememberViewModel> GetSmsRemember(int id)
        {
            SmsRememberViewModel remember = new SmsRememberViewModel();
            var model = await _sms.GetRememberSms(id);
            if (model == null)
            {
                SmsRememberModel sms = new SmsRememberModel();
                _sms.CreateRemember(sms);

            }
            else
            {
                remember.CollectionText = model.CollectionText;
                remember.DayText = model.DayText;
                remember.SiteText = model.SiteText;
                remember.SiteLink = model.SiteLink;
                remember.StartText = model.StartText;
                remember.Description = model.Description;
                remember.NameText = model.NameText;
            }

            return remember;
        }

        public void SmsRemember(SmsRememberViewModel model)
        {
            var remember = _sms.GetRememberSms(1).Result;
            remember.CollectionText = model.CollectionText;
            remember.DayText = model.DayText;
            remember.SiteText = model.SiteText;
            remember.SiteLink = model.SiteLink;
            remember.StartText = model.StartText;
            remember.Description = model.Description;
            remember.NameText = model.NameText;
            _sms.CreateRemember(remember);
        }

        public async Task<SmsThankViewModel> GetSmsThank(int id)
        {
            SmsThankViewModel thank = new SmsThankViewModel();
            var model = await _sms.GetThankSms(id);
            if (model == null)
            {
                SmsThankModel sms = new SmsThankModel();
                _sms.CreateThank(sms);
            }
            else
            {
                thank.SiteLink = model.SiteLink;
                thank.DescriptionText = model.DescriptionText;
                thank.NameText = model.NameText;
                thank.ThankText = model.ThankText;
            }

            return thank;
        }

        public void SmsThank(SmsThankViewModel model)
        {
            var thank =  _sms.GetThankSms(1).Result;
            thank.SiteLink = model.SiteLink;
            thank.DescriptionText = model.DescriptionText;
            thank.NameText = model.NameText;
            thank.ThankText = model.ThankText;
            _sms.CreateThank(thank);
        }
    }
}
