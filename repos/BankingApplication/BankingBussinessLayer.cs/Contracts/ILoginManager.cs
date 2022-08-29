using BankingCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingBussinessLayer.cs.Contracts
{
    public interface ILoginManager
    {
        bool ValidateManager(Manager manager);
        bool ChangePassword(Manager manager);
    }
}
