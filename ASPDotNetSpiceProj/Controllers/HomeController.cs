using ASPDotNetSpiceProj.Models;
using ASPDotNetSpiceProj.ViewModels;
using SpicePro.DataLayer;
using SpicePro.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace ASPDotNetSpiceProj.Controllers
{
    public class HomeController : Controller
    {
        RestaurantDbContext db;
        //ApplicationDbContext adb;

        public HomeController()
        {
            db = new RestaurantDbContext();
            //adb = new ApplicationDbContext();
        }
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Menu()
        {
            
            //var Menuitm = db.MenuItem.Include(m=>m.)
            MenuViewModel Mvm = new MenuViewModel()
            {

                MenuItem = db.MenuItem.ToList(),
                Category = db.Category.ToList(),
                Coupon = db.Coupon.Where(c => c.IsActive == true).ToList()
            };

            return View(Mvm);
        }

        public ActionResult GetMenuItem(string name)
        {
            var menuitems = db.MenuItem.Where(e => e.Category.CName == name).ToList();
            return View(menuitems);
        }


        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Cat = db.Category.ToList();
            ViewBag.SubCat = db.SubCategory.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(MenuItem menu)
        {
            if (Request.Files.Count >= 1)
            {
                var photo = Request.Files[0];
                var imgBytes = new Byte[photo.ContentLength - 1];
                photo.InputStream.Read(imgBytes, 0, photo.ContentLength - 1);
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                menu.MImage = base64String;
            }

            db.MenuItem.Add(menu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [Authorize]
        public ActionResult Details(int id)
        {
            //if(User.Identity.IsAuthenticated)
            //{
            //var OneItem = db.MenuItem.Include(e => e.Category).Include(e => e.SubCategory).Where(e => e.CategoryId == id).SingleOrDefault();

                ViewBag.user = User.Identity.GetUserId();
                var info = db.MenuItem.Where(e => e.MenuItemId == id).FirstOrDefault();
                return View(info);

                //var OneItem = db.MenuItem.Include(e => e.Category).Include(e => e.SubCategory).Where(e => e.CategoryId == id).FirstOrDefault();

                //return View(OneItem);
            //}
            //else
            //{
            //    return RedirectToAction("Login", "Account");
            //}
        }

        public ActionResult AddtoCart(int x, ShoppingCart shoppingCart)  //method for inserting into db
        {
            ViewBag.userId = User.Identity.GetUserId();
            string auId = ViewBag.userId;
            var cartItems = db.ShoppingCart.ToList().Where(e => e.ApplicationUserId == auId && e.MenuItemId == x).FirstOrDefault();
            if (cartItems == null)
            {
                db.ShoppingCart.Add(shoppingCart);
                db.SaveChanges();
            }
            else
            {
                cartItems.Count = cartItems.Count + 1;
                db.SaveChanges();

            }
            return RedirectToAction("Cart");
                
        }


        [Authorize]

        public ActionResult Cart()   //method for displaying
        {
            ViewBag.Message = "Items in your Cart";
            ViewBag.userId = User.Identity.GetUserId();
            string auId = ViewBag.userId;
            var cartitems = db.ShoppingCart.Where(e => e.ApplicationUserId == auId).ToList();
            return View(cartitems);
        }

        public ActionResult Delete(int cartId)
        {
            var cart = db.ShoppingCart.FirstOrDefault(e => e.ShoppingId == cartId);
            db.ShoppingCart.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Cart");
        }

        public ActionResult PlusItems(int cartId)
        {
            var cart = db.ShoppingCart.FirstOrDefault(e => e.ShoppingId == cartId);
            cart.Count += 1;
            db.SaveChanges();
            return RedirectToAction("Cart");

        }
        
        public ActionResult MinusItems(int cartId)
        {
            var cart = db.ShoppingCart.FirstOrDefault(e => e.ShoppingId == cartId);
            cart.Count -= 1;
            db.SaveChanges();
            return RedirectToAction("Cart");

        }

        public ActionResult OrderSummary()
        {
            //ViewBag.userId = User.Identity.GetUserId();
            //string auId = ViewBag.auId;
            //var shoppingCart = db.ShoppingCart.Where(e => e.ApplicationUserId == auId).ToList();
            //var viewModel = new MenuViewModel
            //{
            //    ShoppingCarts = shoppingCart
            //};
            //return View(viewModel);

            ViewBag.Message = "Items in your Cart";
            ViewBag.userId = User.Identity.GetUserId();
            string auId = ViewBag.userId;
            var cartitems = db.ShoppingCart.Where(e => e.ApplicationUserId == auId).ToList();
            return View(cartitems);

        }

        public ActionResult Checkout()
        {
            ViewBag.Message = "Order Placed Successfully!! Have a great meal";
            return View();
        }



        public ActionResult CartRemove(string uName)
        {
            var cart = db.ShoppingCart.Where(e => e.ApplicationUserId == uName);
            db.ShoppingCart.RemoveRange(cart);
            db.SaveChanges();
            return RedirectToAction("Checkout");

        }




        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

    }
}
            
       
        
    

