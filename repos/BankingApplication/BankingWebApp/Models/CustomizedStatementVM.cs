using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingWebApp.Models
{
    public class CustomizedStatementVM
    {
        [Display(Name = "Enter Account Number")]
        [Required(ErrorMessage = "Fill out Account Number")]
        public string AccountNumber { get; set; }

        [Display(Name = "Enter From Date")]
        [Required(ErrorMessage = "Fill From Date")]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [Display(Name = "Enter To Date")]
        [Required(ErrorMessage = "Fill out To Date")]
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }

        [Display(Name = "Enter Account Lower Limit")]
        [Required(ErrorMessage = "Fill out Account Lower Limit")]
        public double LowerLimit { get; set; }

        [Display(Name = "Enter No of Transactions")]
        public int? NoOfTransactions { get; set; }
    }
}
