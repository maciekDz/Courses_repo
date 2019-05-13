using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PraktyczneKursy.DAL;
using PraktyczneKursy.Models;
using PraktyczneKursy.ViewModels;

namespace PraktyczneKursy.Infrastructure
{
    public class PostalMailService : IMailService
    {
        private CoursesContext db = new CoursesContext();

        public void SendOrderConfirmationEmail(Order newOrder)
        {
            var order = db.Orders.Include("OrderItems").Include("OrderItems.Course").SingleOrDefault(o => o.OrderId == newOrder.OrderId && o.LastName == newOrder.LastName);

            OrderConfirmationEmail email = new OrderConfirmationEmail();
            email.To = order.Email;
            email.From = "dzyndz71@gmail.com";
            email.Value = order.OrderValue;
            email.OrderNumber = order.OrderId;
            email.OrderItems = order.OrderItems;
            email.ImagePath = AppConfig.ImageFolder;
            email.Send();
        }

        public void SendFinishedOrderEmail(Order modifiedOrder)
        {
            var order = db.Orders.Include("OrderItems").Include("OrderItems.Course").SingleOrDefault(o => o.OrderId == modifiedOrder.OrderId && o.LastName == modifiedOrder.LastName);

            FinishedOrderEmail email = new FinishedOrderEmail();
            email.To = order.Email;
            email.From = "dzyndz71@gmail.com";
            email.OrderNumber = order.OrderId;
            email.Send();
        }

    }
}