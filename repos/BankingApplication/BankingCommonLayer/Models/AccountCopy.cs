using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCommonLayer.Models
{
    public class AccountCopy
    {
        public AccountCopy()
        {
            SavingsAccounts = new List<SavingsAccount>();
            CurrentAccounts = new List<CurrentAccount>();
            CorporateAccounts = new List<CorporateAccount>();
        }
        public string AccountNumber { get; set; }
        public string CustomerId { get; set; }
        public double Balance { get; set; }
        public DateTime Doc { get; set; }
        public string Tin { get; set; }
        public string Ifsc { get; set; }
        public bool IsDeleted { get; set; }
        public string AccountType { get; set; }
        public double Amount { get; set; }
        public string description { get; set; }
        public string SourceAccount { get; set; }
        public string DestinationAccount { get; set; }
        public int NoOfTransactions { get; set; }
        public double LowerLimit { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public List<SavingsAccount> SavingsAccounts { get; set; }
        public IEnumerable<CurrentAccount> CurrentAccounts { get; set; }
        public IEnumerable<CorporateAccount> CorporateAccounts { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
