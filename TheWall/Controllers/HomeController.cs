using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TheWall.Models;

namespace TheWall.Controllers
{
    public class HomeController : Controller
    {
        private YourContext _context;
        public HomeController(YourContext context) {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("TheWall/{user_id}")]
        public IActionResult TheWall(int user_id)
        {
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
                Comments = new Comment(), //Comments is a reference to ViewModel Class
                Messages = new Message(), //Messages is a reference to ViewModel Class
            };
          List<Message> allMessages = _context.Messages //Filter grabbing all messages, and comments
                                        .Include(m => m.Creator)
                                        .Include(c => c.Comments)
                                        .ToList();

            
            User CurrentUser = _context.Users.SingleOrDefault(user => user.Id == user_id); //Gets the current logged in user based on session ID
            ViewBag.CurrentUser = CurrentUser;
            ViewBag.Messages = allMessages.OrderByDescending(a => a.Created_At);   //Stuffs nessage list and comments into viewbag          
            return View();
        }




        [HttpPost]
        [Route("addMessage")]
        public IActionResult addMessage(Message message)
        {
            int? user_id = HttpContext.Session.GetInt32("id");
            if(ModelState.IsValid)
            {               
                User CurrentUser = _context.Users.SingleOrDefault(user => user.Id == HttpContext.Session.GetInt32("id"));
                message.Creator =CurrentUser;
                _context.Add(message);
                _context.SaveChanges();
                return Redirect($"/TheWall/{user_id}");
            }
                ModelState.AddModelError("Content", "Please enter between 8 and 255 characters");
                return Redirect($"/TheWall/{user_id}");
           
        }
        
        [HttpPost]
        [Route("addComment")]
        public IActionResult addComment(Comment comment)
        {
            int? user_id = HttpContext.Session.GetInt32("id");
            if(ModelState.IsValid)
            {
                int MessageId = Int32.Parse(Request.Form["messageId"]);
                User CurrentUser = _context.Users.SingleOrDefault(user => user.Id == user_id);
                comment.Creator = CurrentUser;
                comment.MessageId = MessageId;            
                _context.Add(comment);
                _context.SaveChanges();
                return Redirect($"/TheWall/{user_id}");
            }
            return Redirect($"/TheWall/{user_id}");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
