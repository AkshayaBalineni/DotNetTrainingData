using System;
using System.Collections.Generic;

#nullable disable

namespace EFLayerImpl.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Tickets = new HashSet<Ticket>();
        }

        public string Eid { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? HireDate { get; set; }
        public string Dept { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
