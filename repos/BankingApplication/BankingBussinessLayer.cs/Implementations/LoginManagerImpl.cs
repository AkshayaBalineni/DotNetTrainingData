using BankingBussinessLayer.cs.Contracts;
using BankingCommonLayer.Models;
using BankingDataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingBussinessLayer.cs.Implementations
{
    public class LoginManagerImpl : ILoginManager
    {
        private readonly ILoginManagerRepository loginManagerRepository;

        public LoginManagerImpl(ILoginManagerRepository loginManagerRepository)
        {
            this.loginManagerRepository = loginManagerRepository;
        }

        public bool ChangePassword(Manager manager)
        {
            return loginManagerRepository.ChangePassword(manager);
        }

        public bool ValidateManager(Manager manager)
        {
            return loginManagerRepository.ValidateManager(manager);
        }
    }
}
