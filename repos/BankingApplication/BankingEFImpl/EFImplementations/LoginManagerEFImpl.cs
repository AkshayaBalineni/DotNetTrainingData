using BankingCommonLayer.Models;
using BankingDataLayer.Contracts;
using BankingEFImpl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingEFImpl.EFImplementations
{
    public class LoginManagerEFImpl : ILoginManagerRepository
    {
        private readonly db_bankingContext context;

        public LoginManagerEFImpl(db_bankingContext context)
        {
            this.context = context;
        }

        public bool ChangePassword(BankingCommonLayer.Models.Manager manger)
        {
            var managerDb = this.context.Managers.FirstOrDefault(x => x.ManagerId == manger.ManagerId);
            if (managerDb == null)
            {
                return false;
            }
            managerDb.ManagerPassword = manger.ManagerPassword;
            this.context.SaveChanges();
            return true;
        }

        public bool ValidateManager(BankingCommonLayer.Models.Manager manager)
        {
            bool isValid = false;
            var managerDb = this.context.Managers.FirstOrDefault(m => m.ManagerId.Equals(manager.ManagerId));
            if(managerDb != null)
            {
                if(managerDb.ManagerPassword.Equals(manager.ManagerPassword))
                {
                    isValid = true;
                }
            }
            return isValid;
        }
    }
}
