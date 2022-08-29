using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime HireDate { get; set; }
        public string Dept { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
