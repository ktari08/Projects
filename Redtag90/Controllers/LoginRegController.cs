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
    public class LoginRegController : Controller
    {
        private MyContext dbContext;
        public LoginRegController(MyContext context)
        {
            dbContext = context;
        }
//////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        [Route("register")]
        public IActionResult Register()
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
            }
            return View();
        }
//////////////////////////////////////////////////////////////////////////////////        
        [HttpGet]
        [Route("login")]
        public IActionResult Login()
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
            }
            return View();
        }
//////////////////////////////////////////////////////////////////////////////////
        [HttpPost("loggingin")]
        public IActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            User ValidateEmail = dbContext.Users.SingleOrDefault(user => user.email == login.loginEmail);
            if (ValidateEmail != null)
            {
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(ValidateEmail, ValidateEmail.password, login.loginPassword))
                {
                   HttpContext.Session.SetInt32("UserId", ValidateEmail.UserId);

                   return RedirectToAction("Index", "Home"); 
                }
                else
                {
                    ViewBag.Error = "Incorrect password or email";

                    return View();
                }
            }
            else
            {
                ViewBag.Error = "Incorrect password or email";

                return View();
            }
        }
//////////////////////////////////////////////////////////////////////////////////
        [HttpPost("Register")]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.Users.Any(u => u.email == newUser.email))
                {
                    ModelState.AddModelError("Email", "Email is already in use!");
                    return View ();
                }
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.password = hasher.HashPassword(newUser, newUser.password);

                dbContext.Add(newUser);
                dbContext.SaveChanges();

                HttpContext.Session.SetInt32("UserId", newUser.UserId);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////        
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
/////////////////////////////////////////////////////////////////////////////////////////////////////////    
}