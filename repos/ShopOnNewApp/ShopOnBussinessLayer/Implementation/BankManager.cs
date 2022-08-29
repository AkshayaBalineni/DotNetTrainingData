using ShopOnBussinessLayer.Contracts;
using ShopOnCommonLayer.Models;
using ShopOnDataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnBussinessLayer.Implementation
{
    public class BankManager : IBankManager
    {
        private readonly IBankRepo bankRepo;

        public BankManager(IBankRepo bankRepo)
        {
            this.bankRepo = bankRepo;
        }
        public bool AddBank(Bank bank)
        {
            return bankRepo.AddBank(bank);
        }
        public IEnumerable<Bank> GetBanks()
        {
            return bankRepo.GetBanks();
        }
    }
}
