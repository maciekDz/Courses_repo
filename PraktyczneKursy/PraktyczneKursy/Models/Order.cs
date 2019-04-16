using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraktyczneKursy.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
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