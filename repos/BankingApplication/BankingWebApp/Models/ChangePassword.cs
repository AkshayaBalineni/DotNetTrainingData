using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingWebApp.Models
{
    public class ChangePassword
    {
        [Display(Name = "Enter Manager Id")]
        [Required(ErrorMessage = "Manager Id can't be blank")]
        public string ManagerId { get; set; }

        [Display(Name = "Enter OldPassword ")]
        [Required(ErrorMessage = "OldPassword can't be blank")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "Enter New Password")]
        [Required(ErrorMessage = "New Password can't be blank")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Minimum 8 characters are required", MinimumLength = 8)]
        public string NewPassword { get; set; }

        [Display(Name = "Enter Confirm Password")]
        [Required(ErrorMessage = "Confirm Password can't be blank")]
        [Compare("NewPassword", ErrorMessage = "Password and Confirm Password does not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
