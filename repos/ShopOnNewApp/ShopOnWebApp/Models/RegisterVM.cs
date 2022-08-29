using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnWebApp.Models
{
    public class RegisterVM
    {
        [Display(Name ="Enter EmailId")]
        [Required(ErrorMessage ="EmailId cannot be Blank!")]
        [EmailAddress]
        public string LoginId { get; set; }

        [Display(Name = "Enter Password")]
        [Required(ErrorMessage = "Password cannot be Blank!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Enter Confirm Password")]
        [Required(ErrorMessage = "Confirm Password cannot be Blank!")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Confirm password and password doesnot match!")]
        public string ConfirmPassword { get; set; }
    }
}
