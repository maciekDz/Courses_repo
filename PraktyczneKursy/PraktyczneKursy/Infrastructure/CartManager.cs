using PraktyczneKursy.DAL;
using PraktyczneKursy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraktyczneKursy.Infrastructure
{
    public class CartManager
    {
        private CoursesContext db;
        private ISessionManager session;
        public CartManager(ISessionManager session,CoursesContext db)
        {
            this.session= session;
            this.db = db;
        }

        public List<CartItem> GetCart()
        {
            List<CartItem> cart;

            if (session.Get<List<CartItem>>(Const.CART_SESSION_KEY)==null)
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart=session.Get<List<CartItem>>(Const.CART_SESSION_KEY) as List<CartItem>;
            }

            return cart;
        }

        public void AddToCart(int courseId)
        {
            var cart = GetCart();
            var cartItem = cart.Find(c => c.Course.CourseId == courseId);


            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                var courseToAdd = db.Courses.Where(c => c.CourseId == courseId).SingleOrDefault();

                if (courseToAdd != null)
                {
                    var newCourseItem = new CartItem()
                    {
                        Course=courseToAdd,
                        Quantity=1,
                        Value=courseToAdd.CoursePrice
                    };
                    cart.Add(newCourseItem);
                }
            }
            session.Set(Const.CART_SESSION_KEY, cart);
        }

        public int RemoveFromCart(int courseId)
        {
            var cart = GetCart();
            var cartItem = cart.Find(c => c.Course.CourseId == courseId);

            if (cartItem!=null)
            {
                if (cartItem.Quantity>1)
                {
                    cartItem.Quantity--;
                    return cartItem.Quantity;
                }
                else
                {
                    cart.Remove(cartItem);
                }
            }
            return 0;
        } 

        public decimal GetCartValue()
        {
            var cart = GetCart();
            return cart.Sum(c => (c.Quantity * c.Course.CoursePrice));
        }

        public int GetCartQuantity()
        {
            var cart = GetCart();
            return cart.Sum(c=>(c.Quantity));
        }

        public Order CreateOrder(Order newOrder,string userId)
        {
            var cart = GetCart();
            newOrder.OrderDate = DateTime.Now;
            //newOrder.UserId = userId;
            db.Orders.Add(newOrder);
            if (newOrder.OrderItems==null)
                newOrder.OrderItems = new List<OrderItem>();
            decimal cartValue = 0;
            foreach (var cartItem in cart)
            {
                var newOrderItem = new OrderItem()
                {
                    CourseId = cartItem.Course.CourseId,
                    Quatity=cartItem.Quantity,
                    PurchaseValue=cartItem.Course.CoursePrice
                };

                cartValue += (cartItem.Quantity * cartItem.Course.CoursePrice);
                newOrder.OrderItems.Add(newOrderItem);
            }
            newOrder.OrderValue = cartValue;
            db.SaveChanges();

            return newOrder;
        }
        public void EmptyCart()
        {
            session.Set<List<CartItem>>(Const.CART_SESSION_KEY, null);
        }
    }
}