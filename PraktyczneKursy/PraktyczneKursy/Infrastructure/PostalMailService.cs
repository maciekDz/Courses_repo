using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PraktyczneKursy.Models;
using PraktyczneKursy.ViewModels;

namespace PraktyczneKursy.Infrastructure
{
    public class PostalMailService : IMailService
    {
        public void SendOrderConfirmationEmail(Order order)
        {
            OrderConfirmationEmail email = new OrderConfirmationEmail();
            email.To = order.Email;
            email.From = "dzyndz71@gmail.com";
            email.Value = order.OrderValue;
            email.OrderNumber = order.OrderId;
            email.OrderItems = order.OrderItems;
            email.ImagePath = AppConfig.ImageFolder;
            email.Send();
        }

        public void SendFinishedOrderEmail(Order order)
        {
            FinishedOrderEmail email = new FinishedOrderEmail();
            email.To = order.Email;
            email.From = "dzyndz71@gmail.com";
            email.OrderNumber = order.OrderId;
            email.Send();
        }

    }
}