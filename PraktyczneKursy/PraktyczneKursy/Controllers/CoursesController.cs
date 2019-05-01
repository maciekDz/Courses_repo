using PraktyczneKursy.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PraktyczneKursy.Controllers
{
    public class CoursesController : Controller
    {
        private CoursesContext db = new CoursesContext();

        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string categoryName)
        {
            var category = db.Categories.Include("Courses").Where(c => c.CategoryName.ToUpper() == categoryName.ToUpper()).Single();
            var courses = category.Courses.ToList();
            return View(courses);
        }

        public ActionResult Details(string id)
        {
            var course = db.Courses.Find(int.Parse(id));
            return View(course);
        }

        [ChildActionOnly] 
        public ActionResult CategoryMenu()
        {
            var categories = db.Categories.ToList();
            return PartialView("_CategoryMenu", categories);
        }

        
    }
}