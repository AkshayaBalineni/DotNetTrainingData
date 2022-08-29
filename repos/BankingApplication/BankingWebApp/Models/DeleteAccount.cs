using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingWebApp.Models
{
    public class DeleteAccount
    {
        [Display(Name = "Enter Account Number")]
        [Required(ErrorMessage = "Account number is needed")]
        public string AccountId { get; set; }
    }
}
