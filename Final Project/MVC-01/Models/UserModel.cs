using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVC_01.Models
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName is Required.")]
        [Display(Name = "FirstName * ")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "LastName is Required.")]
        [Display(Name = "LastName * ")]
        public string LastName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "EmailId is Required.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email * ")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password * ")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is Required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password * ")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password should be same.")]
        public string ConfirmPassword { get; set; }


        public DateTime CreatedOn { get; set; }

        public string SuccessMessage { get; set; }
    }
}