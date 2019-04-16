using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PraktyczneKursy.Models
{
    public class Course
    {

        public int CourseId { get; set; }
        public int CategotyId { get; set; }
        [Required(ErrorMessage ="Specify Course Name")]
        [StringLength(100)]
        public string CourseTitle { get; set; }
        [Required(ErrorMessage = "Specify Author Name")]
        [StringLength(100)]
        public int CourseAuthor { get; set; }
        public DateTime InsertDate { get; set; }
        [StringLength(100)]
        public string FileOrPicturePhotoName { get; set; }
        public string CourseDescription { get; set; }
        public decimal CoursePrice { get; set; }
        public bool Bestseller { get; set; }
        public bool Hidden { get; set; }
        public virtual Category Category { get; set; }
    }
}