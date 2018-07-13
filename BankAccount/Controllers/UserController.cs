using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BankAccount.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace BankAccount.Controllers
{
    public class UserController : Controller
    {
        private YourContext _context;
        public UserController(YourContext context) {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User userReg) {
            if(ModelState.IsValid) {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                userReg.Password = Hasher.HashPassword(userReg, userReg.Password);
                _context.Add(userReg);
                _context.SaveChanges();
                ViewBag.User = userReg;
                HttpContext.Session.SetInt32("id", userReg.Id);
                int? user_id = userReg.Id;
                ViewBag.message = "Successfully Registered. You may now login!";
                return Redirect($"/Account/{user_id}");
            }
            else {
                ViewBag.errors = ModelState.Values;
                return View("Index");
            }
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult LoginPage() {
            return View();
        }

        [HttpPost]
        [Route("ValidLogin")]
        public IActionResult ValidLogin(User userLog) 
        {
            User CheckEmail = _context.Users.SingleOrDefault(user => user.Email == userLog.Email);
            if(CheckEmail != null && userLog.Password != null)
            {
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(CheckEmail, CheckEmail.Password, userLog.Password))
                {

                    ViewBag.User = CheckEmail.Id;
                    HttpContext.Session.SetInt32("id", CheckEmail.Id);
                    int? user_id = CheckEmail.Id;
                    return Redirect($"/account/{user_id}");
                        }
                        ModelState.AddModelError("password", "Incorrect email or password.");
                        return View("LoginPage",userLog);               
                    }
            
                    ModelState.AddModelError("password", "Incorrect email or password.");
                    return View("LoginPage",userLog);
            }
        

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}