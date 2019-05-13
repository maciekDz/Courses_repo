using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hangfire;
using PraktyczneKursy.Models;

namespace PraktyczneKursy.Infrastructure
{
    public class HangFirePostalMailService : IMailService
    {
        public void SendOrderConfirmationEmail(Order order)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("SendOrderConfirmationEmail", "Manage", new { orderId = order.OrderId, lastName = order.LastName}, HttpContext.Current.Request.Url.Scheme);

            BackgroundJob.Enqueue(() => MailSender.Call(url));
            
            //BackgroundJob.Schedule(() => System.Console.WriteLine("Test scheduled job"),TimeSpan.FromDays(1));
            //RecurringJob.AddOrUpdate(() => System.Console.WriteLine("Test recuring job"), Cron.Daily);

        }
        public void SendFinishedOrderEmail(Order order)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("SendFinishedOrderEmail", "Manage", new { orderId = order.OrderId, lastName = order.LastName}, HttpContext.Current.Request.Url.Scheme);

            BackgroundJob.Enqueue(() => MailSender.Call(url));
        }

    }
}