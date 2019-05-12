using Hangfire;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraktyczneKursy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            GlobalConfiguration.Configuration.UseSqlServerStorage("CoursesContext");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}