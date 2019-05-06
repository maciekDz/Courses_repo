using Microsoft.AspNet.Identity.EntityFramework;
using PraktyczneKursy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using static PraktyczneKursy.Models.IdentityModels;

namespace PraktyczneKursy.DAL
{
    public class CoursesContext:IdentityDbContext<ApplicationUser>
    {
        public CoursesContext() : base("CoursesContext")
        {

        }
        static CoursesContext()
        {
            Database.SetInitializer<CoursesContext>(new CoursesInitializer());
        }

        public static CoursesContext Create()
        {
            return new CoursesContext();
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}