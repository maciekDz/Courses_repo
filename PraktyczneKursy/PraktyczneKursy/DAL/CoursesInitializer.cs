using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PraktyczneKursy.Models;
//using System.Configuration;
using PraktyczneKursy.Migrations;
using System.Data.Entity.Migrations;

namespace PraktyczneKursy.DAL
{
    public class CoursesInitializer : MigrateDatabaseToLatestVersion<CoursesContext, Configuration>
    {


        //public static void SeedCoursesData(CoursesContext context)
        //{
        //    var categories = new List<Category>
        //    {
        //        new Category(){CategoryId=1,CategoryName="asp",IconFileName="aspnet.png",CategoryDescription="descr asp"},
        //        new Category(){CategoryId=2,CategoryName="java",IconFileName="javascript.png",CategoryDescription="descr java"},
        //        new Category(){CategoryId=3,CategoryName="php",IconFileName="javascript.png",CategoryDescription="descr php"},
        //        new Category(){CategoryId=4,CategoryName="html",IconFileName="html.png",CategoryDescription="descr html"},
        //        new Category(){CategoryId=5,CategoryName="css",IconFileName="css.png",CategoryDescription="descr css"},
        //        new Category(){CategoryId=6,CategoryName="xml",IconFileName="xml.png",CategoryDescription="descr xml"},
        //        new Category(){CategoryId=7,CategoryName="c#",IconFileName="csharp.png",CategoryDescription="descr c#"}
        //    };

        //    categories.ForEach(c => context.Categories.AddOrUpdate(c));
        //    context.SaveChanges();

        //    var courses = new List<Course>
        //    {
        //        new Course(){CourseId=1,CourseAuthor="Author1",CourseTitle="course1",CategoryId=1,CoursePrice=99,Bestseller=true,FileOrPicturePhotoName="obrazekaspnet.png",InsertDate=DateTime.Now,CourseDescription="descr 1"},
        //        new Course(){CourseId=2,CourseAuthor="Author2",CourseTitle="course2",CategoryId=1,CoursePrice=99,Bestseller=true,FileOrPicturePhotoName="obrazekcsharp.png",InsertDate=DateTime.Now,CourseDescription="descr 2"},
        //        new Course(){CourseId=3,CourseAuthor="Author3",CourseTitle="course3",CategoryId=3,CoursePrice=99,Bestseller=true,FileOrPicturePhotoName="obrazekcss.png",InsertDate=DateTime.Now,CourseDescription="descr 3"},
        //        new Course(){CourseId=4,CourseAuthor="Author4",CourseTitle="course4",CategoryId=4,CoursePrice=99,Bestseller=true,FileOrPicturePhotoName="obrazekhtml.png",InsertDate=DateTime.Now,CourseDescription="descr 4"},
        //        new Course(){CourseId=5,CourseAuthor="Author5",CourseTitle="course5",CategoryId=3,CoursePrice=99,Bestseller=true,FileOrPicturePhotoName="obrazekjavascript.png",InsertDate=DateTime.Now,CourseDescription="descr 5"},
        //        new Course(){CourseId=6,CourseAuthor="Author6",CourseTitle="course6",CategoryId=6,CoursePrice=99,Bestseller=true,FileOrPicturePhotoName="obrazekjquery.png",InsertDate=DateTime.Now,CourseDescription="descr 6"},
        //        new Course(){CourseId=7,CourseAuthor="Author7",CourseTitle="course7",CategoryId=7,CoursePrice=99,Bestseller=true,FileOrPicturePhotoName="obrazekmvc.png",InsertDate=DateTime.Now,CourseDescription="descr 7"},
        //    };

        //    courses.ForEach(c => context.Courses.AddOrUpdate(c));
        //    context.SaveChanges();
        //}
    }
    
}