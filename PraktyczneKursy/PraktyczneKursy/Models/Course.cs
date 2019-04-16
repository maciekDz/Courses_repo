using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraktyczneKursy.Models
{
    public class Course
    {

        public int CourseId { get; set; }
        public int CategotyId { get; set; }
        public string CourseTitle { get; set; }
        public int CourseAuthor { get; set; }
        public DateTime InsertDate { get; set; }
        public string FileOrPicturePhotoName { get; set; }
        public string CourseDescription { get; set; }
        public decimal CoursePrice { get; set; }
        public bool Bestseller { get; set; }
        public bool Hidden { get; set; }
    }
}