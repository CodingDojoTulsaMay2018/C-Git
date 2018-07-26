using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace LoginRegistration.Controllers

{
    public class UserController : Controller
    {
        private YourContext _context;
        public UserController(YourContext context)
        {
                _context = context;
        }

        //Display the register page
        [HttpGet]
        [Route("register")]
        public IActionResult ShowRegister()
        {
            return View("RegisterPage");
        }

        //Display the login page
        [HttpGet]
        [Route("login")]
        public IActionResult ShowLogin()
        {
            return View("LoginPage");
        }


        //Logout and clear the session
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home"); 
            //????? This will route to Home controller, and go to Index route
        }

        [HttpPost]
        [Route("register")]
        public IActionResult SubmitRegister(Register userReg)
        {
            if (ModelState.IsValid)
            {
                // take the userReg object and convert it to User, with a hashed pw
                PasswordHasher<Register> Hasher = new PasswordHasher<Register>();
                User newUser = new User {
                    First_Name = userReg.First_Name,
                    Last_Name = userReg.Last_Name,
                    Email = userReg.Email,
                    Password = Hasher.HashPassword(userReg, userReg.Password), // hash pw
                    Created_At = DateTime.Now,
                    Updated_At = DateTime.Now
                };
                // save the new user with hashed pw
                _context.User.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.Id);
                return RedirectToAction("Registered", "Home");
            }
            return View("RegisterPage", userReg);
        }




        //         [HttpPost]
        // [Route("login")]
        // public IActionResult SubmitLogin(UserLogin userLog)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         var User = _context.Users.SingleOrDefault(user => user.Email == userLog.Email);
        //         if (User != null && userLog.Password != null)
        //         {
        //             // check if the password matches
        //             var Hasher = new PasswordHasher<User>();
        //             if (0 != Hasher.VerifyHashedPassword(User, User.Password, userLog.Password))
        //             {
        //                 // if match, set id to session & redirect
        //                 HttpContext.Session.SetInt32("UserId", User.UserId);
        //                 return RedirectToAction("ActivityList", "Activity");
        //             }
        //         }
        //     }
        //     return View("Login", userLog);
        // }



    }



}