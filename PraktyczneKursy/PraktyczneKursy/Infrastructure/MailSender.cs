using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace PraktyczneKursy.Infrastructure
{
    public static class MailSender
    {
        public static void Call(string url)
        {
            var request = HttpWebRequest.Create(url);
            request.GetResponseAsync();
        }
    }
}