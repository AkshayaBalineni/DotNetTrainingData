using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingWebApp.Models
{
    public class NewAccount
    {
        [Display(Name = "Enter Your customerId ")]
        [Required(ErrorMessage = "customerId should not be blank!")]
        public string CustomerId { get; set; }

        [Display(Name = "Enter Your Balance ")]
        [Required(ErrorMessage = "Balance should not be blank!")]
        public double Balance { get; set; }
        [Display(Name = "Select DOC ")]
        [Required(ErrorMessage = "DOC should not be blank!")]
        [DataType(DataType.Date)]
        public DateTime DOC { get; set; }
        [Display(Name = "Enter Tin ")]
        [Required(ErrorMessage = "Tin should not be blank!")]
        public string Tin { get; set; }
        [Display(Name = "Select AccountType ")]
        [Required(ErrorMessage = "AccountType should not be blank!")]
        public string AccountType { get; set; }
        /*[Display(Name = "Enter Your IFSC ")]
        [Required(ErrorMessage = "IFSC should not be blank!")]
        public string IFSC { get; set; }
        [Display(Name = "Enter Your MinimumBalance ")]
        [Required(ErrorMessage = "MinimumBalance should not be blank!")]
        [DataType(DataType.Currency)]
        public double MinimumBalance { get; set; }*/
       
    }
}
