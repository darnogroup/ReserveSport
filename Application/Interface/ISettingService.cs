using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.General;
using Application.ViewModel.Setting;

namespace Application.Interface
{
    public interface ISettingService
    {
        Task<SettingViewModel> GetSetting(int id);
        void Setting(SettingViewModel model);
        void Insert(AboutViewModel model);
        Task<AboutViewModel> GetAbout();
        void InsertContact(ContactViewModel model);
        Tuple<List<ContactsViewModel>, int, int> GetContact(string search, int page);
        void Add(AddComplaintViewModel model);
        Tuple<List<ComplaintViewModel>, int, int> GetComplaints(string search, int page);
    }
}
