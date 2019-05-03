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

        public ActionResult List(string categoryName, string searchQuery = null)
        {
            var category = db.Categories.Include("Courses").Where(c => c.CategoryName.ToUpper() == categoryName.ToUpper()).Single();

            //var courses = category.Courses.ToList();
            var courses = category.Courses.Where(a => (searchQuery == null ||
                a.CourseTitle.ToLower().Contains(searchQuery.ToLower()) ||
                a.CourseAuthor.ToLower().Contains(searchQuery.ToLower())) &&
                !a.Hidden);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_CoursesList", courses);
            }

            return View(courses);
        }

        public ActionResult Details(string id)
        {
            var course = db.Courses.Find(int.Parse(id));
            return View(course);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60000)]
        public ActionResult CategoryMenu()
        {

            var categories = db.Categories.ToList();
            return PartialView("_CategoryMenu", categories);
        }

        public ActionResult CoursesHints(string term)
        {
            var courses = db.Courses.Where(a => !a.Hidden && a.CourseTitle.ToLower().Contains(term.ToLower()))
                    .Take(5).Select(a => new { label = a.CourseTitle });

            return Json(courses, JsonRequestBehavior.AllowGet);

        }



    }
}