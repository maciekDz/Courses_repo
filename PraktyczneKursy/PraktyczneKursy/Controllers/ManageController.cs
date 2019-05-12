using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PraktyczneKursy.DAL;
using PraktyczneKursy.Infrastructure;
using PraktyczneKursy.Models;
using PraktyczneKursy.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static PraktyczneKursy.App_Start.IdentityConfig;
using static PraktyczneKursy.Models.IdentityModels;

namespace PraktyczneKursy.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private CoursesContext db = new CoursesContext();

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            Error
        }

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }

            if (User.IsInRole("Admin"))
                ViewBag.UserIsAdmin = true;
            else
                ViewBag.UserIsAdmin = false;

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }

            var model = new ManageCredentialsViewModel
            {
                Message = message,
                UserData = user.UserData
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeProfile([Bind(Prefix = "UserData")]UserData userData)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                user.UserData = userData;
                var result = await UserManager.UpdateAsync(user);

                AddErrors(result);
            }
            else
            {
                TempData["ViewData"] = ViewData;
            }

            return RedirectToAction("Index");

        }

        public async Task<ActionResult> ChangePassword([Bind(Prefix = "ChangePasswordViewModel")]ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            var message = ManageMessageId.ChangePasswordSuccess;
            return RedirectToAction("Index", new { Message = message });
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }

        public ActionResult OrderList()
        {
            bool isAdmin = User.IsInRole("Admin");
            ViewBag.UserIsAdmin = isAdmin;

            IEnumerable<Order> userOrder;

            if (isAdmin)
            {
                userOrder = db.Orders.Include("OrderItems").OrderByDescending(o => o.OrderDate).ToArray();
            }
            else
            {
                var userId = User.Identity.GetUserId();
                userOrder = db.Orders.Include("OrderItems").Where(o => o.UserId == userId).OrderByDescending(o => o.OrderDate).ToArray();
            }

            return View(userOrder);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public OrderState ChangeOrderState(Order order)
        {
            Order orderToBeModified = db.Orders.Find(order.OrderId);
            orderToBeModified.OrderState = order.OrderState;
            db.SaveChanges();

            return order.OrderState;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddCourse(int? courseId, bool? confirmation, string msg = "")
        {
            Course course;

            if (courseId.HasValue)
            {
                ViewBag.EditeMode = true;
                course = db.Courses.Find(courseId);
            }
            else
            {
                ViewBag.EditeMode = false;
                course = new Course();
            }

            var result = new EditCourseViewModel();
            result.Categories = db.Categories.ToList();
            result.Course = course;
            result.Confirmation = confirmation;
            result.Msg = msg;

            return View(result);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddCourse(EditCourseViewModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var fileExt = "";
                var fileName = "";
                if (file != null && file.ContentLength > 0)
                {
                    fileExt = Path.GetExtension(file.FileName);
                    fileName = Guid.NewGuid() + fileExt;

                    var path = Path.Combine(Server.MapPath(AppConfig.ImageFolder), fileName);
                    file.SaveAs(path);

                    //model.Course.FileOrPicturePhotoName = fileName;
                }

                if (model.Course.CourseId > 0)
                {
                    var oldFileName = Path.Combine(Server.MapPath(AppConfig.ImageFolder), model.Course.FileOrPicturePhotoName);
                    System.IO.File.Delete(oldFileName);

                    model.Course.FileOrPicturePhotoName = fileName;
                    db.Entry(model.Course).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("AddCourse", new { confirmation = true, msg = "Successfully modified!" });
                }
                else
                {
                    if (! String.IsNullOrEmpty(fileExt))
                    {
                        model.Course.InsertDate = DateTime.Now;
                        model.Course.FileOrPicturePhotoName = fileName;

                        db.Entry(model.Course).State = EntityState.Added;
                        db.SaveChanges();

                        return RedirectToAction("AddCourse", new { confirmation = true, msg = "Successfully added!" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "No image choosen");
                        var categories = db.Categories.ToList();
                        model.Categories = categories;
                        return View(model);
                    }
                }
            }
            else
            {
                var categories = db.Categories.ToList();
                model.Categories = categories;
                return View(model);
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult HideCourse(int courseId)
        {
            var course = db.Courses.Find(courseId);
            course.Hidden = true;
            db.SaveChanges();

            return RedirectToAction("AddCourse", new { confirmation = true,msg="Course hidden" });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ShowCourse(int courseId)
        {
            var kurs = db.Courses.Find(courseId);
            kurs.Hidden = false;
            db.SaveChanges();

            return RedirectToAction("AddCourse", new { confirmation = true, msg = "Course restored" });
        }

        [AllowAnonymous]
        public ActionResult SendOrderConfirmationEmail(int orderId, string lastName)
        {
            var order = db.Orders.Include("OrderItems").Include("OrderItems.Course").SingleOrDefault(o => o.OrderId == orderId && o.LastName == lastName);

            if (order == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            OrderConfirmationEmail email = new OrderConfirmationEmail();
            email.To = order.Email;
            email.From = "dzyndz71@gmail.com";
            email.Value = order.OrderValue;
            email.OrderNumber = order.OrderId;
            email.OrderItems = order.OrderItems;
            email.ImagePath = AppConfig.ImageFolder;
            email.Send();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [AllowAnonymous]
        public ActionResult SendFinishedOrderEmail(int orderId, string lastName)
        {
            var order = db.Orders.Include("OrderItems").Include("OrderItems.Course").SingleOrDefault(o => o.OrderId == orderId && o.LastName == lastName);

            if (order == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            FinishedOrderEmail email = new FinishedOrderEmail();
            email.To = order.Email;
            email.From = "mariuszjurczenko@gmail.com";
            email.OrderNumber = order.OrderId;
            email.Send();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}