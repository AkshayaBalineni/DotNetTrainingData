using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TickectManagementWebApp.Models
{
    public class CloseTicket
    {
        [Display(Name = "Select your Ticket-Id ")]
        [Required(ErrorMessage = "This is Required!")]
        public int TicketId { get; set; }

        [Display(Name = "Enter your Employee id ")]
        [Required(ErrorMessage = "This is Required!")]
        public string ReslovedBy { get; set; }

        [Display(Name = "Enter Resolution ")]
        [Required(ErrorMessage = "This is Required!")]
        public string Resolution { get; set; }
    }
}
