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
            string url = urlHelper.Action("WyslaniePotwierdzenieZamowieniaEmail", "Manage", new { zamowienieId = order.OrderId, nazwisko = order.LastName}, HttpContext.Current.Request.Url.Scheme);

            BackgroundJob.Enqueue(() => MailSender.Call(url));
        }
        public void SendFinishedOrderEmail(Order order)
        {
            throw new NotImplementedException();
        }

    }
}