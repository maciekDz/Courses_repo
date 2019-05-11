namespace PraktyczneKursy.Migrations
{
    using PraktyczneKursy.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<PraktyczneKursy.DAL.CoursesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PraktyczneKursy.DAL.CoursesContext";
        }

        protected override void Seed(PraktyczneKursy.DAL.CoursesContext context)
        {
            //CoursesInitializer.SeedCoursesData(context);
            CoursesInitializer.SeedUsers(context);


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
