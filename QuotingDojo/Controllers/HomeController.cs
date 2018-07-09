using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using QuotingDojo.Models;
using System.Web;


namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM users");
            // System.Console.WriteLine("***********************");
            // System.Console.WriteLine(AllUsers[0]["name"]);
            // System.Console.WriteLine(AllUsers[0]["quote"]);
            // System.Console.WriteLine(AllUsers[0]["created_at"]);

            // System.Console.WriteLine("***********************");
            return View();
        }


        [HttpPost]
        [Route("quotes")]
        public IActionResult Quotes(Users user)
        
        {
            if(ModelState.IsValid)
            {
                DateTime CurrentTime  = DateTime.Now;

                string date = CurrentTime.ToString("yyyy-MM-dd HH:mm:ss");
                string query = $"INSERT INTO users (name,quote,created_at) VALUES ('{user.Name}','{user.Quote}','{date}')";
                System.Console.WriteLine(user.Name);
                // string query = "hello";
                DbConnector.Execute(query);
                return RedirectToAction("Index");
               
            }
            else
            {           
                return View("Index",user);
                // return RedirectToAction("Process",user);
            }
        }


        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes(){

            List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM users");
            ViewBag.AllUsers = AllUsers;
            return View("Quotes");
            

        }

           

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
