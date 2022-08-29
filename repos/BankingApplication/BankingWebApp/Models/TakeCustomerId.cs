using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingWebApp.Models
{
    public class TakeCustomerId
    {
        [Display(Name = "Select CustomerId")]
        [Required(ErrorMessage = "CustomerId is needed to delete")]
        public string CustomerId { get; set; }
    }
}
