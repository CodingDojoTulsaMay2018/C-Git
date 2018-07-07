using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormValidation.Models;

namespace FormValidation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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

        public IActionResult NewUser()
        {
            ViewData["Message"] = "User Page.";

            return View();
        }
        
        public IActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
               return RedirectToAction("Success");
                // return View("Success");
            }
            else
            {           
                return View("NewUser");
                // return RedirectToAction("Process",user);
            }
        }


       

        public IActionResult Success()
        {            
            return View("Success");
        }











        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
