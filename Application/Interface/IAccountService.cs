using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Account;

namespace Application.Interface
{
    public interface IAccountService
    {
       void Register(RegisterViewModel model);
        Task<bool> ExistNumber(string number);
        void Send(string number);
        Task<ClaimViewModel> GetClaim(LoginViewModel model);
    }
}
