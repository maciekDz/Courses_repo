﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PraktyczneKursy.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string CategoryName)
        {
            return View();
        }

        public ActionResult Details(string id)
        {
            return View();
        }
    }
}