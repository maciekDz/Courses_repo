using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PraktyczneKursy.Models
{
    public class Category
    {
        public int CategoryId{ get; set; }
        [Required(ErrorMessage = "Specify Category Name")]
        [StringLength(100)]
        public string CategoryName{ get; set; }
        [Required(ErrorMessage = "Specify Category Description")]
        public string CategoryDescription { get; set; }
        public string IconFileName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }


    }
}