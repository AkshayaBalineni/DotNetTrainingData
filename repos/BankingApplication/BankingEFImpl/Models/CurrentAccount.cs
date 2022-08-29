using System;
using System.Collections.Generic;

#nullable disable

namespace BankingEFImpl.Models
{
    public partial class CurrentAccount
    {
        public string CurrentAccountNo { get; set; }
        public int? AccountNumber { get; set; }
        public double WithdrawlLimit { get; set; }
        public double MinimumBalance { get; set; }

        public virtual Account AccountNumberNavigation { get; set; }
    }
}
