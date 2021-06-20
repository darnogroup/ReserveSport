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
    }
}
