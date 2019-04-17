using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PraktyczneKursy.Models;

namespace PraktyczneKursy.DAL
{
    public class CoursesInitializer : DropCreateDatabaseAlways<CoursesContext>
    {
        protected override void Seed(CoursesContext context)
        {
            SeedCoursesData(context);

            base.Seed(context);
        }

        private void SeedCoursesData(CoursesContext context)
        {
            var categories = new List<Category>
            {
                new Category(){CategoryId=1,CategoryName="asp",IconFileName="asp.png",CategoryDescription="descr asp"},
                new Category(){CategoryId=2,CategoryName="java",IconFileName="java.png",CategoryDescription="descr java"},
                new Category(){CategoryId=3,CategoryName="php",IconFileName="php.png",CategoryDescription="descr php"},
                new Category(){CategoryId=4,CategoryName="html",IconFileName="html.png",CategoryDescription="descr html"},
                new Category(){CategoryId=5,CategoryName="css",IconFileName="css.png",CategoryDescription="descr css"},
                new Category(){CategoryId=6,CategoryName="xml",IconFileName="xml.png",CategoryDescription="descr xml"},
                new Category(){CategoryId=7,CategoryName="c#",IconFileName="c#.png",CategoryDescription="descr c#"}
            };

            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course(){CourseId=1,CourseAuthor="Author1",CourseTitle="course1",CategotyId=1,CoursePrice=99,Bestseller=true,FileOrPicturePhotoName="file1.png",InsertDate=DateTime.Now,CourseDescription="descr 1"},
                new Course(){CourseId=2,CourseAuthor="Author2",CourseTitle="course2",CategotyId=1,CoursePrice=99,Bestseller=true,FileOrPicturePhotoName="file2.png",InsertDate=DateTime.Now,CourseDescription="descr 2"},
                new Course(){CourseId=3,CourseAuthor="Author3",CourseTitle="course3",CategotyId=3,CoursePrice=99,Bestseller=true,FileOrPicturePhotoName="file3.png",InsertDate=DateTime.Now,CourseDescription="descr 3"},
                new Course(){CourseId=4,CourseAuthor="Author4",CourseTitle="course4",CategotyId=4,CoursePrice=99,Bestseller=true,FileOrPicturePhotoName="file4.png",InsertDate=DateTime.Now,CourseDescription="descr 4"},
                new Course(){CourseId=5,CourseAuthor="Author5",CourseTitle="course5",CategotyId=3,CoursePrice=99,Bestseller=true,FileOrPicturePhotoName="file5.png",InsertDate=DateTime.Now,CourseDescription="descr 5"},
                new Course(){CourseId=6,CourseAuthor="Author6",CourseTitle="course6",CategotyId=6,CoursePrice=99,Bestseller=true,FileOrPicturePhotoName="file6.png",InsertDate=DateTime.Now,CourseDescription="descr 6"},
                new Course(){CourseId=7,CourseAuthor="Author7",CourseTitle="course7",CategotyId=7,CoursePrice=99,Bestseller=true,FileOrPicturePhotoName="file7.png",InsertDate=DateTime.Now,CourseDescription="descr 7"},
            };

            courses.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();
        }
    }
    
}