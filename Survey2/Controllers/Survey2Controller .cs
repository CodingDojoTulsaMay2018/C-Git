using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survey2.Models;

namespace Survey2.Controllers
{
    public class Survey2Controller : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("survey")]
        public IActionResult Survey(string name, string location, string language, string comment) {
            Ninja user = new Ninja() {
                Name = name,
                Location = location,
                Language = language,
                Comment = comment
            };
            return View(user);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
