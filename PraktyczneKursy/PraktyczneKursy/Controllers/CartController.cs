using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PraktyczneKursy.DAL;
using PraktyczneKursy.Infrastructure;
using PraktyczneKursy.Models;
using PraktyczneKursy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static PraktyczneKursy.App_Start.IdentityConfig;

namespace PraktyczneKursy.Controllers
{
    public class CartController : Controller
    {

        private CartManager cartManager;
        private ISessionManager sessionManager { get; set; }
        private CoursesContext db;

        public CartController()
        {
            db = new CoursesContext();
            sessionManager = new SessionManager();
            cartManager = new CartManager(sessionManager, db);
        }

        // GET: Cart
        public ActionResult Index()
        {
            var cartItems = cartManager.GetCart();
            var totalPrice = cartManager.GetCartValue();

            CartViewModel cartVM = new CartViewModel()
            {
                CartItems = cartItems,
                CartValue = totalPrice
            };
            return View(cartVM);
        }


        public ActionResult AddToCart(int id)
        {
            cartManager.AddToCart(id);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int courseId)
        {

            int itemsCount = cartManager.RemoveFromCart(courseId);
            int cartItemsCount = cartManager.GetCartQuantity();
            decimal cartValue = cartManager.GetCartValue();

            var result = new CartRemoveViewModel
            {
                RemoveItemId = courseId,
                RemoveItemQuantity = itemsCount,
                CartTotalValue = cartValue,
                CartItemsCount = cartItemsCount

            };

            return Json(result);
        }

        public int GetCartQuantity()
        {
            return cartManager.GetCartQuantity();
        }

        public async Task<ActionResult> Pay()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                var order = new Order
                {
                    FirstName = user.UserData.FirstName,
                    LastName = user.UserData.LastName,
                    Address = user.UserData.Address,
                    City = user.UserData.City,
                    PostalCode = user.UserData.PostalCode,
                    Email = user.UserData.Email,
                    PhoneNumber = user.UserData.PhoneNumber
                };
                return View(order);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Pay", "Cart") });
            }
        }
        [HttpPost]
        public async Task<ActionResult> Pay(Order orderDetails)
        {
            if (ModelState.IsValid)
            {

                var userId = User.Identity.GetUserId();
                var newOrder = cartManager.CreateOrder(orderDetails, userId);

                var user = await UserManager.FindByIdAsync(userId);

                TryUpdateModel(user.UserData);
                await UserManager.UpdateAsync(user);

                cartManager.EmptyCart();

                return RedirectToAction("OrderConfirmation");
            }
            else
            {
                return View(orderDetails);
            }
        }
        public ActionResult OrderConfirmation()
        {
            return View();
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

    }
}