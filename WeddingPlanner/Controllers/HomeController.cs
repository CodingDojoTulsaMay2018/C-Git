using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private YourContext _context;
        public HomeController(YourContext context) {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

 

        [HttpGet]
        [Route("PlanWedding")]
        public IActionResult PlanWedding()
        {
        
            return View();
        }

        [HttpGet]
        [Route("WeddingDetails/{wedding_id}")]
        public IActionResult WeddingDetails(int wedding_id)
        {

            Wedding viewWedding = _context.Weddings //Filter grabbing all messages, and comments
                                        .Include(w => w.GuestList)
                                            .ThenInclude(g => g.InvitedGuest)
                                        .SingleOrDefault(w=> w.Id == wedding_id);
                                             
            ViewBag.Wedding = viewWedding;
           
            return View();
        }


     
        [HttpPost]
        [Route("CreatePlan")]
        public IActionResult CreatePlan(Wedding weddings)
        {
            int? user_id = HttpContext.Session.GetInt32("id");
            if(ModelState.IsValid)
            {               
                User CurrentUser = _context.Users.SingleOrDefault(user => user.Id == HttpContext.Session.GetInt32("id"));
                weddings.Creator =CurrentUser;
                _context.Add(weddings);
                _context.SaveChanges();

                Wedding wedding = _context.Weddings.Last();
                int wedding_id = wedding.Id;  

                return Redirect($"/WeddingDetails/{wedding_id}");
            }
                ModelState.AddModelError("Content", "Please enter between 8 and 255 characters");
                return Redirect($"/TheWall/{user_id}");
           
        }



        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            System.Console.WriteLine("*************");
            int? user_id = HttpContext.Session.GetInt32("id");
            if(HttpContext.Session.GetInt32("id") == null) { //Validates if there is id in session
                return RedirectToAction("Logout", "User");
            }
            if(HttpContext.Session.GetInt32("id") != user_id) { //Compares id in session to id in URL
                int? UserId = HttpContext.Session.GetInt32("id");
                return RedirectToAction("Logout","User");
            }
            ViewModel view = new ViewModel() //Creates a view model to reference
            {
                Users = new User(),  //Users is a reference to ViewModel Class
                Guests = new Guest(), //Comments is a reference to ViewModel Class
                Weddings = new Wedding(), //Messages is a reference to ViewModel Class
            };
          List<Wedding> allWeddings = _context.Weddings //Filter grabbing all messages, and comments
                                        .Include(w => w.Creator)
                                        .Include(g => g.GuestList)
                                        .ToList();
            User CurrentUser = _context.Users.SingleOrDefault(user => user.Id == user_id); //Gets the current logged in user based on session ID
            
            ViewBag.CurrentUser = CurrentUser;
            ViewBag.WeddingList = allWeddings;   //Stuffs nessage list and comments into viewbag      
          

   
            return View();
        }
        

        [HttpGet]
        [Route("RSVP/{wedding_id}")]
        public IActionResult RSVP(int wedding_id)
        {
            int? user_id = HttpContext.Session.GetInt32("id");
            User CurrentUser = _context.Users.SingleOrDefault(user => user.Id == user_id);
            Wedding CurrentWedding = _context.Weddings.SingleOrDefault(wed => wed.Id == wedding_id);

            Guest newGuest = new Guest();
            newGuest.InvitedGuest = CurrentUser;
            newGuest.UserId = CurrentUser.Id;
            newGuest.WeddingId = wedding_id;
            newGuest.Weddings = CurrentWedding;
            _context.Add(newGuest);
            _context.SaveChanges();
        
            return RedirectToAction("Dashboard");
        }


        [HttpGet]
        [Route("UnRSVP/{wedding_id}")]
                public IActionResult UnRSVP(int wedding_id)
        {
            int? user_id = HttpContext.Session.GetInt32("id");
            User CurrentUser = _context.Users.SingleOrDefault(user => user.Id == user_id);
            Wedding CurrentWedding = _context.Weddings.SingleOrDefault(wed => wed.Id == wedding_id);
            Guest CuurentGuest = _context.Plans.SingleOrDefault(i=>i.UserId == CurrentUser.Id && i.WeddingId == wedding_id);
            CurrentWedding.GuestList.Remove(CuurentGuest);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }




        [HttpGet]
        [Route("DELETE/{wedding_id}")]
        public IActionResult DELETE(int wedding_id)
        {
            
            Wedding CurrentWedding = _context.Weddings.SingleOrDefault(wed => wed.Id == wedding_id);         
            _context.Remove(CurrentWedding);
            _context.SaveChanges();
        
            return RedirectToAction("Dashboard");
        }











        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
