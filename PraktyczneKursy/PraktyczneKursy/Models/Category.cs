using System.Collections.Generic;

namespace PraktyczneKursy.Models
{
    public class Category
    {
        public int CategoryId{ get; set; }
        public string CategoryName{ get; set; }
        public string CategoryDescription { get; set; }
        public string IconFileName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }


    }
}