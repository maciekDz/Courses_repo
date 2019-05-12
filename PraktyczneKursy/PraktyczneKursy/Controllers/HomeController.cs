using MvcSiteMapProvider.Caching;
using NLog;
using NLog.Targets;
using PraktyczneKursy.DAL;
using PraktyczneKursy.Infrastructure;
using PraktyczneKursy.Models;
using PraktyczneKursy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PraktyczneKursy.Controllers
{
    [Target("Elmah")]
    public class HomeController : Controller
    {
        private CoursesContext db = new CoursesContext();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ActionResult Index()
        {
            logger.Info("U r on the main page");
            //throw new Exception("ascasca");
            ICacheProvider cache = new DefaultCacheProvider();

            List<Category> categories;
            if (cache.IsSet(Const.CATEGORIES_CACHE_KEY))
            {
                categories = cache.Get(Const.CATEGORIES_CACHE_KEY) as List<Category>;
            }
            else
            {
                categories = db.Categories.ToList();
                cache.Set(Const.CATEGORIES_CACHE_KEY, categories, 60);
            }

            List<Course> brandNews;
            if (cache.IsSet(Const.BRAND_NEWS_CACHE_KEY))
            {
                brandNews = cache.Get(Const.BRAND_NEWS_CACHE_KEY) as List<Course>;
            }
            else
            {
                brandNews = db.Courses.Where(x => !x.Hidden).OrderByDescending(x => x.InsertDate).Take(3).ToList();
                cache.Set(Const.BRAND_NEWS_CACHE_KEY, brandNews, 1);
            }
            
            List<Course> bestsellers;
            if (cache.IsSet(Const.BESTSELLERS_CACHE_KEY))
            {
                bestsellers = cache.Get(Const.BESTSELLERS_CACHE_KEY) as List<Course>;
            }
            else
            {
                bestsellers = db.Courses.Where(x => x.Bestseller == true && !x.Hidden).OrderBy(x => Guid.NewGuid()).Take(3).ToList();
                cache.Set(Const.BESTSELLERS_CACHE_KEY, bestsellers, 1);
            }

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