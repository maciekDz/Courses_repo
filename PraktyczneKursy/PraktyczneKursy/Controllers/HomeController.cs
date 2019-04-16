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
            Category category = new Category { CategoryName = "asp.net mvc", IconFileName = "aspNetMvc.png", CategoryDescription = "Description" };
            db.Categories.Add(category);
            db.SaveChanges();
            return View();
        }
    }
}