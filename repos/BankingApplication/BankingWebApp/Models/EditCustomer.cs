using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingWebApp.Models
{
    public class EditCustomer
    {
        [Display(Name = "Enter CustomerId")]
        [Required(ErrorMessage = "CustomerId can't be blank!")]
        public string CustomerId { get; set; }
        [Display(Name = "Enter FirstName")]
        [Required(ErrorMessage = "FistName can't be blank!")]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Display(Name = "Enter LastName")]
        [Required(ErrorMessage = "LastName can't be blank!")]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Display(Name = "Select Gender")]
        [Required(ErrorMessage = "Gender can't be blank!")]
        public string Gender { get; set; }
        [Display(Name = "Select date of birth")]
        [Required(ErrorMessage = "date of birth can't be blank!")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Display(Name = "Enter the EmailId")]
        [Required(ErrorMessage = "EmailId of birth can't be blank!")]
        [MaxLength(40)]
        [EmailAddress]
        [RegularExpression(@"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$", ErrorMessage = "Email Adress is not valid")]
        public string EmailId { get; set; }
        [Display(Name = "Enter the MobileNumber")]
        [Required(ErrorMessage = "MobileNumber of birth can't be blank!")]
        [StringLength(10, MinimumLength = 10)]
        public string MobileNumber { get; set; }
        [Display(Name = "Enter the City")]
        [Required(ErrorMessage = "City  can't be blank!")]
        [MaxLength(20)]
        public string City { get; set; }
        [Display(Name = "Enter the State")]
        [Required(ErrorMessage = "State  can't be blank!")]
        [MaxLength(20)]
        public string State { get; set; }
        [Display(Name = "Enter the Pincode")]
        [Required(ErrorMessage = "Pincode  can't be blank!")]
        [StringLength(6, MinimumLength = 6)]
        public string Pincode { get; set; }
    }
}
