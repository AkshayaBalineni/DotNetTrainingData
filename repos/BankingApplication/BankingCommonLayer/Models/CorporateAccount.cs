using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCommonLayer.Models
{
    public class CorporateAccount : Account
    {
        public string CorporateAccountNo { get; set; }
        public int? AccountNumber { get; set; }
        public double WithdrawlLimit { get; set; }
        public double MinimumBalance { get; set; }

        public virtual Account Account { get; set; }
    }
}
