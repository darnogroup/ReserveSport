using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel.Setting;
using Domin.Entity;
using Domin.Interface;

namespace Application.Service
{
    public class SettingService:ISettingService
    {
        private readonly ISettingInterface _setting;

        public SettingService(ISettingInterface setting)
        {
            _setting = setting;
        }
        public async Task<SettingViewModel> GetSetting(int id)
        {
            SettingViewModel setting = new SettingViewModel();
            var model = await _setting.GetSetting(1);
            if (model == null)
            {
                SettingModel option = new SettingModel();
              _setting.Create(option);

            }
            else
            {
                setting.About = model.About;
                setting.Instagram = model.Instagram;
                setting.Namad = model.Namad;
                setting.SmsApiCode = model.SmsApiCode;
                setting.SmsNumberSender = model.SmsNumberSender;
                setting.Telegram = model.Telegram;
                setting.WhatsApp = model.WhatsApp;
                setting.YouTube = model.YouTube;
                setting.ZarinPal = model.ZarinPal;
                setting.Salary = model.Salary;
            }

            return setting;
        }

        public void Setting(SettingViewModel model)
        {
            var setting =  _setting.GetSetting(1).Result;
            setting.About = model.About;
            setting.Salary = model.Salary;
            setting.Instagram = model.Instagram;
            setting.Namad = model.Namad;
            setting.SmsApiCode = model.SmsApiCode;
            setting.SmsNumberSender = model.SmsNumberSender;
            setting.Telegram = model.Telegram;
            setting.WhatsApp = model.WhatsApp;
            setting.YouTube = model.YouTube;
            setting.ZarinPal = model.ZarinPal;
            _setting.Update(setting);
        }
    }
}
