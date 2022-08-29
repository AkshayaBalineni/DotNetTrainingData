using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
   public class Ticket
    {
        public int TicketId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime RaisedDate { get; set; }
        public string Severity { get; set; }
        public string TicketDesc { get; set; }
        public string ResolvedBy { get; set; }
        public string Resolution { get; set; }
        public DateTime ResolvedDate { get; set; }
        public string Ticketstatus { get; set; }
        public Employee employee { get; set; }
    }
}
