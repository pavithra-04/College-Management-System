using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_01.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "EmailId  is required")]
        [Display(Name = "Email * ")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password * ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}