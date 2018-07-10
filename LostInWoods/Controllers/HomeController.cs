using System;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LostInWoods.Factory;
using LostInWoods.Models;




namespace LostInWoods.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailsFactory trailsFactory;
        public HomeController()
        {
            trailsFactory = new TrailsFactory();
        }

        public IActionResult Index()
        {
            Trails test = new Trails();
            test.Trail_Name = "another trail";
            test.Description = "Yadad   jashadadada";
            test.Trail_Length = 1234256;
            test.Elevation_Change = 223423;
            test.Latitude = 87585;
            test.Longitude = 2353535;
            // trailsFactory.Add(test);
            // List<Dictionary<Trails, object>> AllTrails = trailsFactory.FindAll();
            // // IEnumerable<Trails> AllTrails = trailsFactory.FindAll();
            var AllTrails = trailsFactory.FindAll();
            ViewBag.Trails = AllTrails;
            return View();
        }

        public IActionResult AddPage()
        {
            
            return View();
        }
        [HttpGet]
        [Route("ShowTrail/{id}")]
        public IActionResult ShowTrail(int Id)
        {
            
            ViewBag.Trail = trailsFactory.FindByID(Id);
            return View();
        }

        public IActionResult CreateRecord(Trails trail)
        {
            if(ModelState.IsValid)
            {

                trailsFactory.Add(trail);
               return RedirectToAction("AddPage");
                
            }
            else
            {           
                return View("AddPage",trail);
                
            }            
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
