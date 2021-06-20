using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Setting;

namespace Application.Interface
{
    public interface ISettingService
    {
        Task<SettingViewModel> GetSetting(int id);
        void Setting(SettingViewModel model);
    }
}
