using System;
using System.Collections.Generic;

#nullable disable

namespace BankingEFImpl.Models
{
    public partial class CorporateAccount
    {
        public string CorporateAccountNo { get; set; }
        public int? AccountNumber { get; set; }
        public double WithdrawlLimit { get; set; }
        public double MinimumBalance { get; set; }

        public virtual Account AccountNumberNavigation { get; set; }
    }
}
