using PraktyczneKursy.DAL;
using PraktyczneKursy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PraktyczneKursy.Controllers
{
    public class HomeController : Controller
    {
        private CoursesContext db = new CoursesContext();

        public ActionResult Index()
        {
            //comment
            var categoryList = db.Categories.ToList();
            return View();
        }
    }
}