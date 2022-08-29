using System;
using System.Collections.Generic;

#nullable disable

namespace BankingEFImpl.Models
{
    public partial class Manager
    {
        public Manager()
        {
            Customers = new HashSet<Customer>();
        }

        public string ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string ManagerPassword { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
