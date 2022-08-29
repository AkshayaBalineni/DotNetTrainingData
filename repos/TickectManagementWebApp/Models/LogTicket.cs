using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TickectManagementWebApp.Models
{
    public class LogTicket
    {
        
        [Display(Name = "Enter your Employee id ")]
        [Required(ErrorMessage = "This is Required!")]
        public string EmployeeId { get; set; }

        [Display(Name = "Enter your Dept ")]
        [Required(ErrorMessage = "This is Required!")]
        public string EmployeeDept { get; set; }

        [Display(Name = "Enter TicketDate ")]
        [Required(ErrorMessage = "This is Required!")]
        public DateTime TicketDate { get; set; }

        [Display(Name = "Enter Severity ")]
        [Required(ErrorMessage = "This is Required!")]
        public string Severity { get; set; }

        [Display(Name = "Enter Ticket Discription ")]
        [Required(ErrorMessage = "This is Required!")]
        public string TicketDescription { get; set; }


    }
}
