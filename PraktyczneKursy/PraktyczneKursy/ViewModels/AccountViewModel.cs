using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PraktyczneKursy.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Please provide e-mail address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please provide password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please provide e-mail address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide password")]
        [StringLength(30, ErrorMessage = "{0} must have {2} characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage ="Password and Confirm Password don't match.")]
        public string ConfirmPassword { get; set; }
    }
}