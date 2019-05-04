using PraktyczneKursy.DAL;
using PraktyczneKursy.Infrastructure;
using PraktyczneKursy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            cartManager = new CartManager(sessionManager,db);
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
                RemoveItemQuantity=itemsCount,
                CartTotalValue=cartValue,
                CartItemsCount=cartItemsCount

            };

            return Json(result);
        }


        public int GetCartQuantity()
        {
            return cartManager.GetCartQuantity();
        }
    }
}