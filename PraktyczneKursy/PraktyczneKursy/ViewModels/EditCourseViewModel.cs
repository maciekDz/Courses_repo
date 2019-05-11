using PraktyczneKursy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraktyczneKursy.ViewModels
{
    public class EditCourseViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public bool? Confirmation { get; set; }
        public string Msg { get; set; }

    }
}