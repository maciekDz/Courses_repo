using PraktyczneKursy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PraktyczneKursy.Controllers.ManageController;
using System.ComponentModel.DataAnnotations;

namespace PraktyczneKursy.ViewModels
{

    public class ManageCredentialsViewModel
    {
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
        public ManageMessageId? Message { get; set; }
        public UserData UserData { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Current Password")]
        public string OldPassword { get; set; }


        [Required]
        [StringLength(100,ErrorMessage ="The {0} must be at least {2} characters long.",MinimumLength =6)]
        [DataType(DataType.Password)]
        [Display(Name ="New Password")]
        public string NewPassword { get; set; }

        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword",ErrorMessage ="The new password and confirmation password don't match.")]
        public string ConfirmPassword { get; set; }
    }

}