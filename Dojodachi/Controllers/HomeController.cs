using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Dojodachi.Models;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
      
            
        Dachi newdachi = new Dachi();

        public IActionResult Index()
        {
                    
            if(HttpContext.Session.GetInt32("fullness") == null)
            {
                HttpContext.Session.SetInt32("fullness", 20);
                HttpContext.Session.SetInt32("happiness", 20);
                HttpContext.Session.SetInt32("meals", 3);
                HttpContext.Session.SetInt32("energy", 50);
                HttpContext.Session.SetString("status", "Hello! Would you like to play a game?");

            } 
            newdachi.Status = HttpContext.Session.GetString("status");
            newdachi.Happiness = (int)HttpContext.Session.GetInt32("happiness");
            newdachi.Energy = (int)HttpContext.Session.GetInt32("energy");
            newdachi.Fullness = (int)HttpContext.Session.GetInt32("fullness");
            newdachi.Meals = (int)HttpContext.Session.GetInt32("meals");                      
            return View(newdachi);
        }

        public IActionResult Feed()
        {
            int mealsleft = (int)HttpContext.Session.GetInt32("meals");
            Random rand = new Random();
            if(mealsleft > 0)
            {
                var randomchance = rand.Next(1,100);
                if(randomchance > 25)
                {
                    var addFullness = rand.Next(5,11);
                    int currentFullness = (int)HttpContext.Session.GetInt32("fullness");
                    currentFullness += addFullness;
                    HttpContext.Session.SetInt32("fullness", currentFullness);
                    HttpContext.Session.SetString("status", "You fed Pikachu!!  Fullness+" + addFullness+ ", Meals -1");
                }
                else{
                    HttpContext.Session.SetString("status", "Pikachu didnt like your food. Meals -1");
                }
                mealsleft--;
                HttpContext.Session.SetInt32("meals", mealsleft);
            }
            else
            {
                HttpContext.Session.SetString("status", "You have no food left to feed");
            }                    
                                  
            return RedirectToAction("Index");
        }


        public IActionResult Play()
        {   Random rand = new Random();
            int energy = (int)HttpContext.Session.GetInt32("energy");
            int currenthappiness = (int)HttpContext.Session.GetInt32("happiness");

            if(energy >=5){
                var randomchance = rand.Next(1,100);
                if(randomchance > 25)
                {
                    var randhappiness = rand.Next(5,11);
                    currenthappiness += randhappiness;
                    HttpContext.Session.SetInt32("happiness", currenthappiness);
                    HttpContext.Session.SetString("status", "You played with Pikachu!!  Happiness+" + randhappiness+ ", Energy -5");
                }
                else
                {
                    HttpContext.Session.SetString("status", "Pikachu did not want to play. Energy -5");
                }
                energy -=5;
                HttpContext.Session.SetInt32("energy", energy);
            }
            else
            {
                HttpContext.Session.SetString("status", "Pikachu needs some sleep to gain energy");
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Work()
        {
            
            int energy = (int)HttpContext.Session.GetInt32("energy");
            int mealsleft = (int)HttpContext.Session.GetInt32("meals");
            if(energy>=5){
                Random rand = new Random();
                var randmeal = rand.Next(1,4);
                mealsleft +=randmeal;
                HttpContext.Session.SetInt32("meals", mealsleft);
                energy -=5;
                HttpContext.Session.SetInt32("energy", energy);
                HttpContext.Session.SetString("status", "Pikachu worked gaining +" + randmeal+ " meals. Energy -5");
            }
            else
            {
                HttpContext.Session.SetString("status", "Pikachu needs some sleep to gain energy");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Sleep()
        {

            int currentFullness = (int)HttpContext.Session.GetInt32("fullness");
            int currenthappiness = (int)HttpContext.Session.GetInt32("happiness");
            int energy = (int)HttpContext.Session.GetInt32("energy");

            if((currentFullness >=5) && (currenthappiness  >=5)){
                energy +=15;
                currentFullness -=5;
                currenthappiness -=5;
                HttpContext.Session.SetString("status", "Pikachu gained 15 energy!! Fulnnes -5, Happiness -5");
            }
            else
            {
                HttpContext.Session.SetString("status", "You do not have enough Fullness or Happiness for Sleep");
            }

            HttpContext.Session.SetInt32("fullness", currentFullness);
            HttpContext.Session.SetInt32("happiness", currenthappiness);
            HttpContext.Session.SetInt32("energy", energy);


            return RedirectToAction("Index");
        }
        public IActionResult Restart()
        {
            HttpContext.Session.SetInt32("fullness", 20);
            HttpContext.Session.SetInt32("happiness", 20);
            HttpContext.Session.SetInt32("meals", 3);
            HttpContext.Session.SetInt32("energy", 50);
            HttpContext.Session.SetString("status", "Hello! Please keep me happy");
            return RedirectToAction("Index");
        }







        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
