using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingWebApp.Models
{
    public class FundTransfer
    {
        [Display(Name = "Enter Payers Account Number ")]
        [Required(ErrorMessage = "Payers Account Number can't be blank")]
        [DataType(DataType.Text)]
        public string PayersAccountNo { get; set; }

        [Display(Name = "Enter Payees Account Number ")]
        [Required(ErrorMessage = "Payees Account Number can't be blank")]
        [DataType(DataType.Text)]
        public string PayeesAccountNo { get; set; }

        [Display(Name = "Enter Amount")]
        [Required(ErrorMessage = "Amount can't be blank")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }
    }
}
