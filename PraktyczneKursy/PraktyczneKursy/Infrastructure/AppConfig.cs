using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PraktyczneKursy.Infrastructure
{
    public class AppConfig
    {
        private static string _categoryIconFolder = ConfigurationManager.AppSettings["CategoryIconFolder"];

        private static string CategoryIconFolder
        {
            get
            {
                return _categoryIconFolder;
            }
        }

        private static string _imageFolder = ConfigurationManager.AppSettings["ImageFolder"];

        private static string ImageFolder
        {
            get
            {
                return _imageFolder;
            }
        }



    }
}