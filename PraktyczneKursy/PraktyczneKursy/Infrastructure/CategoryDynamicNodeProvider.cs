using MvcSiteMapProvider;
using PraktyczneKursy.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraktyczneKursy.Infrastructure
{
    public class CategoryDynamicNodeProvider : DynamicNodeProviderBase
    {
        private CoursesContext db = new CoursesContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();
            foreach (var category in db.Categories)
            {
                DynamicNode node = new DynamicNode();
                node.Title = category.CategoryName;
                node.Key = "Category_" + category.CategoryId;
                node.RouteValues.Add("categoryName", category.CategoryName);

                returnValue.Add(node);
            }

            return returnValue;
        }
    }    
}