using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCommonLayer.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int? AccountNo { get; set; }
        public double TransactionAmount { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string DestinationAccountNo { get; set; }
        public string TransactionDescription { get; set; }
        public string SourceAccountNo { get; set; }
        public virtual Account SourceAccount { get; set; }
    }
}
