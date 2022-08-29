using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCommonLayer.Models
{
    public class Account
    {
        public Account()
        {
            SavingsAccounts = new List<SavingsAccount>();
            CurrentAccounts = new List<CurrentAccount>();
            CorporateAccounts = new List<CorporateAccount>();
        }
        public int AccountNumber { get; set; }
        public string CustomerId { get; set; }
        public double Balance { get; set; }
        public DateTime Doc { get; set; }
        public string Tin { get; set; }
        public string Ifsc { get; set; }
        public bool IsDeleted { get; set; }
        public string AccountType { get; set; }
        public List<SavingsAccount> SavingsAccounts { get; set; }
        public IEnumerable<CurrentAccount> CurrentAccounts { get; set; }
        public IEnumerable<CorporateAccount> CorporateAccounts { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }

    }
}
