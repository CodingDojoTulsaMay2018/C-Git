using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Identity;

namespace LoginRegistration.Controllers
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


        public IActionResult Registered()
        {
            return View ("Registered");
        }

        

        // [HttpPost]
        // [Route("Login")]
        // public IActionResult Login(string Email, string Password)
        // {
        //     List<Users> ReturnedValues = _context.Users.ToList();

        //     var user = ReturnedValues.Where(a => a.Email.ToLower() == $"{Email}").ToList().FirstOrDefault();

        //     if(user != null && Password != null)
        //     {
        //         var Hasher = new PasswordHasher<Users>();
                
        //         if(0 != Hasher.VerifyHashedPassword(user, user.Password, Password))
        //         {
        //             return View("LoggedIn");
        //         }
             
                

        //     }
        //     return View("Index");
                        
        // }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
