using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using RandomPasscode.Models;

namespace RandomPasscode.Controllers

{
    public class HomeController : Controller
    {
        public int counter = 1;
        
        
        public IActionResult Index()
        {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var stringChars = new char[14];
        Random rand = new Random();
        for(var i = 0; i < stringChars.Length;i++){
            stringChars[i] = chars[rand.Next(chars.Length)];
        }
        var finalString = new String(stringChars);
        TempData["passcode"] = finalString;
        // return RedirectToAction("Index");





            return View();
        }
        public IActionResult Generate()
        {
            
            if(HttpContext.Session.GetInt32("Counter") == null)
            {
                HttpContext.Session.SetInt32("Counter", 0);
            }
            counter = (int)HttpContext.Session.GetInt32("Counter");
            counter++;            
            HttpContext.Session.SetInt32("Counter", counter);                     
            int? IntVariable = HttpContext.Session.GetInt32("Counter");
            TempData["TempModel"] = IntVariable; 
                               
            return RedirectToAction("Index");
            
        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
