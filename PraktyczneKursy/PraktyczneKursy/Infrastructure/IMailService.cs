using PraktyczneKursy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktyczneKursy.Infrastructure
{
    public interface IMailService
    {
        void SendOrderConfirmationEmail(Order order);
        void SendFinishedOrderEmail(Order order);
    }
}
