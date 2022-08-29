using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCommonLayer.Models
{
   public class Manager
    {
        public Manager()
        {
            Customers = new List<Customer>();
        }
        public string ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string ManagerPassword { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
  
    }
}
