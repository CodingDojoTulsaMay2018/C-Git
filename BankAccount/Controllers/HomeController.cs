using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BankAccount.Models;
using System.Linq;

namespace BankAccount.Controllers {
    public class HomeController : Controller {
        private YourContext _context;
        public HomeController(YourContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("Account/{user_id}")]
        public IActionResult ViewAccount(int user_id) {
            if(HttpContext.Session.GetInt32("id") == null) {
                return RedirectToAction("LoginPage", "User");
            }
            if(HttpContext.Session.GetInt32("id") != user_id) {
                int? UserId = HttpContext.Session.GetInt32("id");
                return RedirectToAction("Logout","User");
            }
            User currentuser = _context.Users
                                .Include(user => user.Transactions)
                                .Where(user => user.Id == user_id).SingleOrDefault();
            if(currentuser.Transactions != null) {
                currentuser.Transactions = currentuser.Transactions.OrderByDescending(transcation => transcation.Created_At).ToList();
            }
            ViewBag.User = currentuser;
            return View();
        }

        [HttpPost]
        [Route("Transaction")]
        public IActionResult Transaction(double Amount) {
            int? user_id = HttpContext.Session.GetInt32("id");
            User CurrentUser = _context.Users.SingleOrDefault(user => user.Id == HttpContext.Session.GetInt32("id"));
            
            if(CurrentUser.Balance + Amount < 0) {
                TempData["error"] = "Insufficient Funds";
                
            }
            else 
            {
                Transaction NewTranscation = new Transaction {
                    Amount = Amount,
                    Created_At = DateTime.Now,
                    UserId = CurrentUser.Id,
                    // User = CurrentUser
                };
                CurrentUser.Balance += Amount;
                _context.Add(NewTranscation);
                _context.SaveChanges();
            }
            return Redirect($"/account/{user_id}");
        }



        
        

    }
}
