using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PraktyczneKursy.Models
{
    public class UserData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address{ get; set; }
        public string City{ get; set; }
        [RegularExpression(@"(\+\d{2})*[\d\s-]+",ErrorMessage ="Wrong phone number format")]
        public string PhoneNumber{ get; set; }
        [EmailAddress(ErrorMessage ="Wrong email format")]
        public string Email{ get; set; }
    }
}