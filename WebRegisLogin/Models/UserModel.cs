using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRegisLogin.Models
{
    public class UserModel
    {
        
        public int UserId{ get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Required")]
        [Display(Name = "First Name")]
        public string FirstName{ get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "Email:")]
        public string Email{ get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password{ get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "Confirm Password:")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Not matching")]
        public string ConfirmPassword{ get; set; }
        public DateTime CreatedOn{ get; set; }

        public string SuccessMessage{ get; set; }

    }
}