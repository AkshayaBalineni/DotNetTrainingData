using System;
using System.Collections.Generic;

#nullable disable

namespace BankingEFImpl.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int? AccountNumber { get; set; }
        public double TransactionAmount { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string DestinationAccountNo { get; set; }
        public string TransactionDescription { get; set; }
        public string SourceAccount { get; set; }

        public virtual Account AccountNumberNavigation { get; set; }
    }
}
