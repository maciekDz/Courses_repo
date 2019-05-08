using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PraktyczneKursy.Models.IdentityModels;

namespace PraktyczneKursy.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required(ErrorMessage = "Specify First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Specify Second Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Specify Street Name")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Specify City Name")]
        [StringLength(100)]
        public string City { get; set; }

        [Required(ErrorMessage = "Specify Postal Code")]
        [StringLength(6)]
        public string PostalCode { get; set; }
        
        [Required(ErrorMessage = "Specify phone number")]
        [StringLength(20)]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Wrong phone number format.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Specify e-mail address")]
        [EmailAddress(ErrorMessage = "Wrong e-mail format")]
        public string Email{ get; set; }
        public string Comment { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderState OrderState { get; set; }
        public decimal OrderValue { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

    public enum OrderState
    {
        New,
        Finished
    }
}