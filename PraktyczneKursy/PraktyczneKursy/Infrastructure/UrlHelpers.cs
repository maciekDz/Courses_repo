using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PraktyczneKursy.Infrastructure;

namespace PraktyczneKursy.Infrastructure
{
    public static class UrlHelpers
    {
        public static string CategoryIconPath(this UrlHelper helper, string categoryIconName)
        {
            var CategoryIconFolder = AppConfig.CategoryIconFolder;
            var path = Path.Combine(CategoryIconFolder, categoryIconName);
            var definitePath = helper.Content(path);

            return definitePath; 
        }

        public static string ImagePath(this UrlHelper helper, string imageName)
        {
            var ImageFolder = AppConfig.ImageFolder;
            var path = Path.Combine(ImageFolder, imageName);
            var definitePath = helper.Content(path);

            return definitePath;

        }
    }
}