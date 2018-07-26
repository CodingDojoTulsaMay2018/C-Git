using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginReg2.Models;
using Microsoft.AspNetCore.Identity;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {
        private YourContext _context;

        public HomeController(YourContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterModel newUser)
        {
            if (ModelState.IsValid)
            {
                var emailCheck = _context.Users.SingleOrDefault(u => u.Email == newUser.Email);
                if(emailCheck == null)
                {
                    PasswordHasher<RegisterModel> Hasher = new PasswordHasher<RegisterModel>();
                    newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                    _context.Add(newUser);
                    _context.SaveChanges();
                    return RedirectToAction("RegisterSuccess");
                }
              
                return View("Index");

                
            }
            else
            {
                return View("Index", newUser);
            }
        }
        public IActionResult RegisterSuccess()
        {
            return View();
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login (LoginModel userLog)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == userLog.Email);
            if(user != null && userLog.Password != null)
            {
               var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, userLog.Password))
                {
                     return RedirectToAction("LoginSuccess");
                }               
            }
           
            return View("Index",userLog);
        }

        public IActionResult LoginSuccess()
        {
            return View();
        }





        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
