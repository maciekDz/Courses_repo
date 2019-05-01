using PraktyczneKursy.DAL;
using PraktyczneKursy.Models;
using PraktyczneKursy.ViewModels;
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

            var categories = db.Categories.ToList();
            var brandNews = db.Courses.Where(x => !x.Hidden).OrderByDescending(x => x.InsertDate).Take(3).ToList();
            var bestsellers = db.Courses.Where(x => x.Bestseller ==true &&  !x.Hidden).OrderBy(x=>Guid.NewGuid()).Take(3).ToList();

            var vm = new HomeViewModel()
            {
                Categories = categories,
                BrandNew = brandNews,
                Bestsellers = bestsellers
            };


            return View(vm);
        }

        public ActionResult StaticPages(string name)
        {
            return View(name);
        }

       
    }
}