using ShopOnCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnBussinessLayer.Contracts
{
    public interface IBankManager
    {
        bool AddBank(Bank bank);

        IEnumerable<Bank> GetBanks();

    }
}
