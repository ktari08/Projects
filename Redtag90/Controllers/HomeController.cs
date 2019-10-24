using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using redtag90.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace redtag90.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                ViewBag.Login = "Login";
                ViewBag.Register = "Register";
            }
            else
            {
                ViewBag.Cart = "Cart";
                ViewBag.NewProduct = "New Product";
                ViewBag.Logout = "Logout";
                ViewBag.Dashboard = "Dashboard";
            }
            return View();
        }
///////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("dashboard/{UserId}")]
        public IActionResult UserProfile(int UserId)
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                ViewBag.Login = "Login";
                ViewBag.Register = "Register";

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Cart = "Cart";
                ViewBag.NewProduct = "New Product";
                ViewBag.Logout = "Logout";
                ViewBag.Dashboard = "Dashboard";
            }
            User LoggedUser = dbContext.Users
                .SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("UserId"));
            
            return View("UserProfile", LoggedUser);
        }

//////////////////////////////////////////////////////////////        
        [HttpGet("viewproduct/{ProductId}")]
        public IActionResult ViewProduct()
        {
            return View();
        }
////////////////////////////////////////////////////////////////
        [HttpGet("cart")]
        public IActionResult Cart()
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                ViewBag.Login = "Login";
                ViewBag.Register = "Register";
            }
            else
            {
                ViewBag.Cart = "Cart";
                ViewBag.NewProduct = "New Product";
                ViewBag.Logout = "Logout";
                ViewBag.Dashboard = "Dashboard";
            }
            return View();
        }

///////////////////////////////////////////////////////////////
        [HttpGet("newproduct")]
        public IActionResult NewProduct(Product newProduct)
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                ViewBag.Login = "Login";
                ViewBag.Register = "Register";

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Cart = "Cart";
                ViewBag.NewProduct = "New Product";
                ViewBag.Logout = "Logout";
                ViewBag.Dashboard = "Dashboard";
            }

            return View();
        }
///////////////////////////////////////////////////////////////
        [HttpPost("createproduct")]
        public IActionResult CreateProduct(Product newProduct)
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                ViewBag.Login = "Login";
                ViewBag.Register = "Register";

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Cart = "Cart";
                ViewBag.NewProduct = "New Product";
                ViewBag.Logout = "Logout";
                ViewBag.Dashboard = "Dashboard";
            }

            // newProduct.UserId = (int)HttpContext.Session.GetInt32("UserId");

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewProduct", newProduct);
            }
        }
////////////////////////////////////////////////////////////// 
    }
}
