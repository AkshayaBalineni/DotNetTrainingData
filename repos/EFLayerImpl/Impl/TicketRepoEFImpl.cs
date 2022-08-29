using CommonLayer;
using DataLayer.Contracts;
using EFLayerImpl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLayerImpl.Impl
{
    public class TicketRepoEFImpl : ITicketRepo
    {
        private readonly db_TicketLoggingContext context;
        public TicketRepoEFImpl(db_TicketLoggingContext context)
        {
            this.context = context;
        }

        public int AddTicket(CommonLayer.Ticket ticket)
        {
            var dbTicket = new Models.Ticket()
            {
                LoggedBy = ticket.EmployeeId,
                RaisedDate = ticket.RaisedDate,
                Severity = ticket.Severity,
                TicketStatus = "open",
                TicketDescription = ticket.TicketDesc, 
            };
                this.context.Tickets.Add(dbTicket);
            
                context.SaveChanges();

            return dbTicket.TicketId;
         }

        public IEnumerable<CommonLayer.Ticket> ViewTickets()
        {
            var ticketsDb = this.context.Tickets.Where(x => x.TicketStatus.Equals("open")).ToList();
            if(ticketsDb.Count == 0)
            {
                return null;
            }
            var tickets = from t in ticketsDb
                          select new CommonLayer.Ticket()
                          {
                              TicketId = t.TicketId,
                              /*EmployeeId = t.LoggedBy,
                              Severity = t.Severity*/
                          };
            return tickets;
        }
        public int UpdateTicket(CommonLayer.Ticket Updatedticket)
        {
            var tickectDb = this.context.Tickets.FirstOrDefault(x => x.TicketId == Updatedticket.TicketId);
            var employeedb = this.context.Employees.FirstOrDefault(x => x.Eid.Equals(Updatedticket.ResolvedBy));
            if (employeedb != null)
            {
                if (employeedb.Dept.ToLower().Equals("devops"))
                {
                    tickectDb.TicketStatus = "closed";
                    tickectDb.ResolvedBy = Updatedticket.ResolvedBy;
                    tickectDb.Resolution = Updatedticket.Resolution;
                    tickectDb.ResolvedDate = DateTime.UtcNow;

                    context.SaveChanges();
                    return Updatedticket.TicketId;
                }

            }
            return 0;
        }
    }
}
