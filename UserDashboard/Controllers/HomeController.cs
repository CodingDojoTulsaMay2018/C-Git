using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Linq;
using UserDashboard.Models;

namespace UserDashboard.Controllers
{
    public class HomeController : Controller
    {

        private YourContext _context;
        public HomeController(YourContext context) {
            _context = context;
        }


        public IActionResult Index()
        {
            ViewModel loginReg = new ViewModel()
            {
                regUser = new User(),
                loginUser = new LoginCheck()
            };


            return View();
        }


        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }


        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }




        [HttpPost]
        [Route("Register")]
        public IActionResult Register(ViewModel FormData) {
          

            if(ModelState.IsValid) 
            {
                User NewUser = FormData.regUser;
                User emailCheck = _context.Users.SingleOrDefault(u => u.Email == NewUser.Email);
                if(emailCheck == null)
                {
                    User levelCheck = _context.Users.SingleOrDefault(u=> u.UserLevel == 9);
                    if(levelCheck == null)
                    {
                        NewUser.UserLevel = 9;
                    }
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
                    _context.Add(NewUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("userlevel", NewUser.UserLevel);
                    HttpContext.Session.SetInt32("loggedid", NewUser.Id);


                    return RedirectToAction("Dashboard");
                }
                ModelState.AddModelError("regUser.Email", "Email is already registered.");
                return View("Register", FormData);                
            }
            else {
                ViewBag.errors = ModelState.Values;
                return View("Register",FormData);
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(ViewModel FormData) 
        {

            if(ModelState.IsValid)
            {
                LoginCheck LoginUser = FormData.loginUser;
                var user = _context.Users.SingleOrDefault(u => u.Email == LoginUser.Email); 
                if(user !=null)
            {
                    var Hasher = new PasswordHasher<User>();
                    if(0 !=Hasher.VerifyHashedPassword(user, user.Password, LoginUser.Password))
                    {
                        HttpContext.Session.SetInt32("loggedid", user.Id);
                        HttpContext.Session.SetInt32("userlevel", user.UserLevel);
                      

                        return Redirect("Dashboard");
                    }
                }
                 ModelState.AddModelError("loginUser.Password", "The email or password provided is incorrect.");
                return View("Login", FormData);
                }
                else
                {
                    return View("Login", FormData);
            }
            
        }


        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard() {
            if((int)HttpContext.Session.GetInt32("userlevel") == 9)
                {
                    return RedirectToAction("AdminDashboard");
                }

                    return Redirect("UserDashboard");
                } 


        [HttpGet]
        [Route("UserDashboard")]
        public IActionResult UserDashboard() {
            var userList = _context.Users.ToList();
            ViewBag.AllUsers = userList;
            return View();
        }  


        [HttpGet]
        [Route("AdminDashboard")]
        public IActionResult AdminDashboard() {
            var userList = _context.Users.ToList();
            ViewBag.AllUsers = userList;
            return View();
        } 


        [HttpGet]
        [Route("TheWall/{user_id}")]
        public IActionResult TheWall(int user_id)
        {
            List<Message> allMessages = _context.Messages //Filter grabbing all messages, and comments
                            .Include(m => m.Creator)
                            .Include(c => c.Comments)
                            .ToList();
            User UserWall = _context.Users.SingleOrDefault(user => user.Id == user_id); //Gets the current logged in user based on session ID
            User LoggedUser= _context.Users.SingleOrDefault(user => user.Id == (int)HttpContext.Session.GetInt32("loggedid"));

            ViewBag.UserWall = UserWall;            
            ViewBag.LoggedUser = LoggedUser;
            ViewBag.Messages = allMessages.OrderByDescending(a => a.Created_At);

            return View();
        }
        [HttpGet]
        [Route("Profile")]
        public IActionResult Profile()
        {
                     
            User LoggedUser= _context.Users.SingleOrDefault(user => user.Id == (int)HttpContext.Session.GetInt32("loggedid"));                  
            ViewBag.LoggedUser = LoggedUser;
           

            return View();
        }
        
        [HttpPost]
        [Route("UserEditInfo")]
        public IActionResult UserEditInfo(ViewModel FormData) 
        {
            User LoggedUser= _context.Users.SingleOrDefault(user => user.Id == (int)HttpContext.Session.GetInt32("loggedid"));
            ViewBag.LoggedUser = LoggedUser;

            if(ModelState.IsValid)
                {

                    if(FormData.editUser.Email != null)
                    {
                        User emailCheck = _context.Users.SingleOrDefault(u => u.Email == FormData.editUser.Email);
                        if(emailCheck == null)
                        {
                            LoggedUser.Email = FormData.editUser.Email;
                            _context.Update(LoggedUser);
                            _context.SaveChanges();
                        }
                        if(FormData.editUser.Email == LoggedUser.Email)
                        {
                            ModelState.AddModelError("editUser.Email", " ");
                        }
                        else
                        {
                            ModelState.AddModelError("editUser.Email", "Email already exists.");
                        }
                    }
                    if(FormData.editUser.First_Name != null)
                    {                                               
                            LoggedUser.First_Name = FormData.editUser.First_Name;
                            _context.Update(LoggedUser);
                            _context.SaveChanges();                     
                    }
                    if(FormData.editUser.Last_Name != null)
                    {                                               
                            LoggedUser.Last_Name = FormData.editUser.Last_Name;
                            _context.Update(LoggedUser);
                            _context.SaveChanges();                     
                    }
                    return View("Profile");
                }               
            return View("Profile", FormData);           
        }


        [HttpPost]
        [Route("UserEditPassword")]
        public IActionResult UserEditPassword(ViewModel FormData)
        {
            User LoggedUser= _context.Users.SingleOrDefault(user => user.Id == (int)HttpContext.Session.GetInt32("loggedid"));
            ViewBag.LoggedUser = LoggedUser;
            
            if(ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                LoggedUser.Password = Hasher.HashPassword(LoggedUser, FormData.editPassword.Password);
                            _context.Update(LoggedUser);
                            _context.SaveChanges();  


                return View("Profile");
            }

            return View("Profile", FormData);


        }










        


 

        
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return Redirect("/");
        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
