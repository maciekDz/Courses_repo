using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraktyczneKursy.ViewModels
{
    public class CartRemoveViewModel
    {
        public decimal CartTotalValue { get; set; }
        public int CartItemsCount { get; set; }
        public int RemoveItemQuantity { get; set; }
        public int RemoveItemId { get; set; }
    }
}