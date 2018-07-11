using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restauranter2.Models;

namespace Restauranter2.Controllers
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
            // List<Reviewer> ReturnedValues = _context.reviewer.Where(r => r.Stars < 17).ToList();
            // //List<Reviwer> Reviwer is the model name  _context.reviewer reviewer is the table name matches
            // ViewBag.allUsers = ReturnedValues;
            
            return View();
        }

        [HttpPost]
        [Route("CreateRecord")]
        public IActionResult CreateRecord(Reviewer reviewer)
        {

             if(ModelState.IsValid)
            {
            
                _context.Add(reviewer);
                _context.SaveChanges();
              
                 return RedirectToAction("ReviewPage");
            }
            else
            {
                return View("Index",reviewer);
            }
           

            
        }

        public IActionResult ReviewPage()
        {
            List<Reviewer> ReturnedValues = _context.reviewer.ToList();
            
            //List<Reviewer> Reviewer is the model name  _context.reviewer reviewer is the table name matches
            ViewBag.allReviews = ReturnedValues.OrderByDescending(a => a.VisitDate);

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
