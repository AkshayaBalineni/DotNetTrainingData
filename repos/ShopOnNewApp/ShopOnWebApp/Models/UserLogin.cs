using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnWebApp.Models
{
    public class UserLogin
    {
        [Display(Name ="Enter your EmailId ")]
        [Required(ErrorMessage = "EmailID is Required!")]
        public string LoginId { get; set; }

        [Display(Name ="Enter your Password")]
        [Required(ErrorMessage ="Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RemeberMe { get; set; }
    }
}
