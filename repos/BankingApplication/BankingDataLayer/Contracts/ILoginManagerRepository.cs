using BankingCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDataLayer.Contracts
{
    public interface ILoginManagerRepository
    {
        bool ValidateManager(Manager manager);
        bool ChangePassword(Manager manger);
    }
}
