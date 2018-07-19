using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using DojoSecrets.Models;

namespace DojoSecrets.Controllers
{
    public class UserController : Controller
    {
        private YourContext _context;
        public UserController(YourContext context) {
            _context = context;
        }


        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User userReg) {
            User CheckEmail = _context.Users.SingleOrDefault(user => user.Email == userReg.Email);
            if (CheckEmail != null)
            {
                ModelState.AddModelError("email", "Email already exists"); //Overwrites the default error for email field
                return View("Index",userReg);
            }

            if(ModelState.IsValid) {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                userReg.Password = Hasher.HashPassword(userReg, userReg.Password);
                _context.Add(userReg);
                _context.SaveChanges();
                ViewBag.User = userReg;
                HttpContext.Session.SetInt32("id", userReg.Id);
                int? user_id = userReg.Id;
                return Redirect("/Secrets");
            }
            else {
                ViewBag.errors = ModelState.Values;
                return View("Index",userReg);
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(User userLog) 
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
                    return Redirect("/Secrets");
                    }
                        ModelState.AddModelError("password", "Incorrect email or password.");
                        return View("Index",userLog);               
                    }
            
                    ModelState.AddModelError("password", "Incorrect email or password.");
                    return View("Index",userLog);
            }


            
            [HttpGet]
            [Route("Logout")]
            public IActionResult Logout() {
                HttpContext.Session.Clear();
                return Redirect("/");
            }
           
            public IActionResult Index()
            {
                return View();
            }









    }
    




}