using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PraktyczneKursy.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Specify First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Specify Second Name")]
        [StringLength(50)]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Specify Street Name")]
        [StringLength(100)]
        public string Street { get; set; }
        [Required(ErrorMessage = "Specify City Name")]
        [StringLength(100)]
        public string City { get; set; }
        [Required(ErrorMessage = "Specify Postal Code")]
        [StringLength(6)]
        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }
        public string Email{ get; set; }
        public string Comment { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderState OrderState { get; set; }
        public decimal OrderValue { get; set; }
        List<OrderElement> OrderElements { get; set; }
    }

    public enum OrderState
    {
        New,
        Finished
    }
}