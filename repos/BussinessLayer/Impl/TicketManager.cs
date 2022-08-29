using BussinessLayer.Contracts;
using CommonLayer;
using DataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Impl
{
    public class TicketManager : ITicketManager
    {
        private readonly ITicketRepo tickectRepo = null;

        public TicketManager(ITicketRepo ticketRepo)
        {
            this.tickectRepo = ticketRepo;
        }

        public int AddTicket(Ticket ticket)
        {
            return tickectRepo.AddTicket(ticket);
        }

        public int UpdateTicket(Ticket Updatedticket)
        {
            return tickectRepo.UpdateTicket(Updatedticket);
        }

        public IEnumerable<Ticket> ViewTickets()
        {
            return tickectRepo.ViewTickets();
        }
    }
}
