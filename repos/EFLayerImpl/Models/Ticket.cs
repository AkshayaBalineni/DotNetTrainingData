using System;
using System.Collections.Generic;

#nullable disable

namespace EFLayerImpl.Models
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public string LoggedBy { get; set; }
        public DateTime? RaisedDate { get; set; }
        public string Severity { get; set; }
        public string TicketDescription { get; set; }
        public string ResolvedBy { get; set; }
        public string Resolution { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public string TicketStatus { get; set; }

        public virtual Employee LoggedByNavigation { get; set; }
    }
}
