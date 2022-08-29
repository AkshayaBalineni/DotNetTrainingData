using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoBankingCommonLayer
{
    public class Customer
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Password { get; set; }
        public string encryptedPassword { get; set; }
        public bool isAuthenticated { get; set; }
        public string RetypePassword { get; set; }
        public long AccountNumber { get; set; }
        public double IntialAmount { get; set; }
    }
}
