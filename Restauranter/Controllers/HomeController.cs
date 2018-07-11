using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Restauranter.Models;

namespace Restauranter.Controllers
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
            
            List<Person> ReturnedValues = _context.Users.Where(user => user.Age > 17).ToList();
            ViewBag.allUsers = ReturnedValues;
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
