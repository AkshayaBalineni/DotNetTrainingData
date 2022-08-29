using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingWebApp.Models
{
    public class UpdateAccount
    {
        [Display(Name = "Enter AccountNumber")]
        [Required(ErrorMessage = "AccountNumber can't be blank!")]
        [MaxLength(20)]
        public string AccountNumber { get; set; }
        [Display(Name = "Enter Balance")]
        [Required(ErrorMessage = "Balance can't be blank!")]
        public double Balance { get; set; }
        [Display(Name = "Enter AccountType")]
        [Required(ErrorMessage = "AccountType can't be blank!")]
        public string AccountType { get; set; }
    }
}
