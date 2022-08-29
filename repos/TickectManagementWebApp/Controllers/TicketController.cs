using BussinessLayer.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickectManagementWebApp.Models;

namespace TickectManagementWebApp.Controllers
{
    public class TicketController : Controller
    {
        
        private readonly ITicketManager ticketManager;

        //userManager => manage user(Register)
        //singIn manager=> login/logout
        public TicketController(ITicketManager ticketManager)
        {
            this.ticketManager = ticketManager;
        }
        [HttpGet]
        public IActionResult LogTicket()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult LogTicket(LogTicket Emp)
        {

            if (ModelState.IsValid)
            {
                int returnId = ticketManager.AddTicket(new CommonLayer.Ticket()
                {
                    
                    EmployeeId = Emp.EmployeeId,
                    RaisedDate = Emp.TicketDate,
                    TicketDesc = Emp.TicketDescription,
                    Severity = Emp.Severity,
                    employee = new CommonLayer.Employee()
                    {
                        EmployeeId = Emp.EmployeeId,
                        Dept =Emp.EmployeeDept,
                    }
                });
                TempData["ticketId"] = returnId;
                return RedirectToAction("Success", "Home");
            }
            return View(Emp);
        }
        [HttpGet]
        public IActionResult CloseTicket()
        {
            ViewBag.Tickects = ticketManager.ViewTickets();
            return View();
        }
        [HttpPost]
        public IActionResult CloseTicket(CloseTicket ticket)
        {
            if (ticket.TicketId != 0)
            {
                if (ModelState.IsValid)
                {
                    int closedTicketId = ticketManager.UpdateTicket(new CommonLayer.Ticket()
                    {
                        TicketId = ticket.TicketId,
                        ResolvedBy = ticket.ReslovedBy,
                        Resolution = ticket.Resolution
                    });
                    TempData["ClosedId"] = closedTicketId;
                    return RedirectToAction("ClosingTicket", "Home");
                }
            }
            ViewBag.Tickects = ticketManager.ViewTickets();
            return View(ticket);
        }
    }
}
