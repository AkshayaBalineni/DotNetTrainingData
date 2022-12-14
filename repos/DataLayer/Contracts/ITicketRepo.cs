using CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Contracts
{
    public interface ITicketRepo
    {
        IEnumerable<Ticket> ViewTickets();
        int AddTicket(Ticket ticket);
        int UpdateTicket(CommonLayer.Ticket Updatedticket);
    }
}
