using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingWebApp.Models
{
    public class WithDrawVM
    {
        [Display(Name ="Enter your AccountNumber")]
        [Required(ErrorMessage ="Account Number is Required!")]
        public string AccountNumber { get; set; }
        [Display(Name = "Enter your Amount")]
        [Required(ErrorMessage = "Amount is Required!")]
        public double Amount { get; set; }
        [Display(Name = "Enter your Descrption")]
        [Required(ErrorMessage = "Descrption is Required!")]
        public string  Descrption { get; set; }
    }
}
