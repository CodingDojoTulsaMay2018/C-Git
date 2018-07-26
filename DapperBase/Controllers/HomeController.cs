using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DapperBase.Factory;
using DapperBase.Models;

namespace DapperBase.Controllers
{
    


    public class HomeController : Controller
    {
        private readonly UserFactory userFactory;

        public HomeController(UserFactory uFactory)
        {
            _userFactory = uFactory;
        }

        public IActionResult Index()
        {
                // Users homer = new Users();
                // homer.Name = "frank";
                // homer.Email = "homer@gmail.com";
                // homer.Password = "88888888";
               
            
                
                // // string query = "hello";
                // userFactory.Add(homer);
                ViewBag.Users = userFactory.FindAll();
                foreach (var item in ViewBag.Users)
                {
                    System.Console.WriteLine("**************");
                    System.Console.WriteLine(item.Name);
                    System.Console.WriteLine(item.Email);
                    System.Console.WriteLine("**************");
                }
                

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
