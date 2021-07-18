using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entity;

namespace Domin.Interface
{
    public interface ISettingInterface
    {
        Task<SettingModel> GetSetting(int id);
        void Create(SettingModel model);
        void Update(SettingModel model);
        Task<IEnumerable<ComplaintModel>> GetAllComplaint();
        void CreateComplaint(ComplaintModel model);
        void RemoveComplaint(int id);
        Task<AboutModel> GetAbout(int id);
        Task<bool> ExistAbout(int id);
        void Insert(AboutModel model);
        void Edit(AboutModel model);
        void InsertContact(ContactModel model);
        Task<IEnumerable<ContactModel>> GetContact();
    }
}
