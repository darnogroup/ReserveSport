using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Other;
using Application.ViewModel.General;
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
        public async Task<SettingViewModel> GetFirstSetting()
        {
            SettingViewModel setting = new SettingViewModel();
            var model = await _setting.GetFirstSetting();
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
        public void Insert(AboutViewModel model)
        {
            var check = _setting.ExistAbout(model.AboutId).Result;
            if (check)
            {
                var result = _setting.GetAbout(1).Result;
                result.AboutBody = model.AboutBody;
                result.AboutSlogan = model.AboutSlogan;
                if (model.AboutImage != null)
                {
                    var checkImage = model.AboutImage.IsImage();
                    if (checkImage)
                    {
                        if (result.AboutImage != null && result.AboutImage != "noImage.jpg")
                        {
                            Image.RemoveImage(result.AboutImage);
                        }
                        result.AboutImage = Image.SaveImage(model.AboutImage);
                    }
                    else
                    {
                        result.AboutImage = "noImage.jpg";
                    }
                }

             
                _setting.Edit(result);

            }
            else
            {

                AboutModel about = new AboutModel();
                about.AboutBody = model.AboutBody;
                if (model.AboutImage != null)
                {
                    var checkImage = model.AboutImage.IsImage();
                    if (checkImage)
                    {
                        about.AboutImage = Image.SaveImage(model.AboutImage);
                    }
                }
                else
                {
                    about.AboutImage = "noImage.jpg";
                }
                about.AboutSlogan = model.AboutSlogan;
                _setting.Insert(about);
            }
        }

        public async Task<AboutViewModel> GetAbout()
        {
            AboutViewModel about = new AboutViewModel();
            var model = await _setting.GetAbout(1);
            if (model != null)
            {
                about.ImagePath = model.AboutImage;
                about.AboutBody = model.AboutBody;
                about.AboutSlogan = model.AboutSlogan;
                about.AboutId = model.AboutId;
            }
            else
            {
                about.ImagePath = "DefultPic.png";
                about.AboutBody = "محتوا وارد نشده";
                about.AboutSlogan = "محتوا وارد نشده";
                about.AboutId = 1;
            }

            return about;
        }

        public void InsertContact(ContactViewModel model)
        {
            ContactModel contact = new ContactModel();
            contact.ContactName = model.ContactName;
            contact.ContactNumber = model.ContactNumber;
            contact.ContactBody = model.ContactBody;
            _setting.InsertContact(contact);
        }

        public Tuple<List<ContactsViewModel>, int, int> GetContact(string search, int page)
        {
            var list = _setting.GetContact().Result;
            List<ContactsViewModel> models = new List<ContactsViewModel>();
            var contacts = list.Where(w => w.ContactName.Contains(search)).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(contacts.Count, 10);
            int skip = (page - 1) * 10;
            var articleList = contacts.Skip(skip).Take(10).ToList();
            foreach (var item in articleList)
            {
                models.Add(new ContactsViewModel()
                {
                    ContactNumber = item.ContactNumber,
                    ContactBody = item.ContactBody,
                    ContactName = item.ContactName
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }
        public void Add(AddComplaintViewModel model)
        {
            ComplaintModel complaint = new ComplaintModel();
            complaint.ComplaintPhoneNumber = model.ComplaintPhoneNumber;
            complaint.ComplaintMail = model.ComplaintMail;
            complaint.ComplaintTitle = model.ComplaintTitle;
            complaint.ComplaintDescription = model.ComplaintDescription;
            complaint.ComplaintUserName = model.ComplaintUserName;
            _setting.CreateComplaint(complaint);
        }

        public Tuple<List<ComplaintViewModel>, int, int> GetComplaints(string search, int page)
        {
            var list = _setting.GetAllComplaint().Result;
            List<ComplaintViewModel> models = new List<ComplaintViewModel>();
            var complaints = list.Where(w => w.ComplaintUserName.Contains(search)).ToList();
            int pageNumber = page;
            int pageCount = Page.PageCount(complaints.Count, 10);
            int skip = (page - 1) * 10;
            var articleList = complaints.Skip(skip).Take(10).ToList();
            foreach (var item in articleList)
            {
                models.Add(new ComplaintViewModel()
                {
                    ComplaintPhoneNumber = item.ComplaintPhoneNumber,
                    ComplaintDescription = item.ComplaintDescription,
                    ComplaintMail = item.ComplaintMail,
                    ComplaintTitle = item.ComplaintTitle,
                    ComplaintUserName = item.ComplaintUserName,
                    Id = item.ComplaintId
                });
            }
            return Tuple.Create(models, pageCount, pageNumber);
        }
    }

}
