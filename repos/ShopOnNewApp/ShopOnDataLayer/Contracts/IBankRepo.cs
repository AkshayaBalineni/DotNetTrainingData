using ShopOnCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnDataLayer.Contracts
{
    public interface IBankRepo
    {
        bool AddBank(Bank bank);
        IEnumerable<Bank> GetBanks();
    }
}
