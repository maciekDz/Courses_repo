using MvcSiteMapProvider;
using PraktyczneKursy.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraktyczneKursy.Infrastructure
{
    public class CourseDetailsDynamicNodeProvider : DynamicNodeProviderBase
    {
        private CoursesContext db = new CoursesContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue =new List<DynamicNode>();
            foreach (var course in db.Courses)
            {
                DynamicNode node = new DynamicNode();
                node.Title = course.CourseTitle;
                node.Key = "Course_" + course.CourseId;
                node.ParentKey = "Category_" + course.CategoryId;
                node.RouteValues.Add("id", course.CourseId);

                returnValue.Add(node);
            }

            return returnValue;
        }

    }
}