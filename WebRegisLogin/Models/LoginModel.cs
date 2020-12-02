using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRegisLogin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Required")]
        public string Email{ get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}