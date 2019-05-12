using Postal;
using PraktyczneKursy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraktyczneKursy.ViewModels
{
    public class OrderConfirmationEmail :Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public decimal Value { get; set; }
        public int OrderNumber { get; set; }
        public List<OrderItem> OrderItems { get; set; }


    }
}