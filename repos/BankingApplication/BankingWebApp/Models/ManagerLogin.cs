using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingWebApp.Models
{
    public class ManagerLogin
    {
        [Display(Name ="Enter Your UserName ")]
        [Required(ErrorMessage = "ManagerId should not be blank!")]
        public string MangerId { get; set; }
        [Display(Name = "Enter Your Password ")]
        [Required(ErrorMessage = "Password should not be blank!")]
        [DataType(DataType.Password)]
        [StringLength(20,ErrorMessage ="Minimum 8 characters requried",MinimumLength = 8)]
        public string Password { get; set; }

    }
}
