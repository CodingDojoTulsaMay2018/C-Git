    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using System;
    using ModelFun.Models;
    using System.Collections.Generic;
    namespace ModelFun.Controllers 
    
    
    //be sure to use your own project's namespace!
    {
    
        public class ModelFunController : Controller   
        {
            //for each route this controller is to handle:
            [HttpGet]       //type of request
            [Route("")]     //associated route string (exclude the leading /)
            public IActionResult Index()
            {
                
                StringText Sometext = new StringText()
                {
                    Sometext = "This is some text of a string",
                };
                return View("Index",Sometext);
            }

            [HttpPost]
            [Route("user")]
            public IActionResult user(string firstName , string lastName)           
            {
            User userinfo = new User()
                {
                    FirstName = firstName,
                    LastName = lastName
                };
                return View("user",userinfo);
                // return RedirectToAction("Index",user);
                }

            [HttpGet]
            [Route("user")]
            public IActionResult user()
            {
            User userinfo = new User()
                {
                    FirstName = "no name",
                    LastName = "no name"
                };

                return View("user",userinfo);
            }

            [HttpGet]
            [Route("numbers")]
            public IActionResult numbers()           
            {
            IntArray numbers = new IntArray()
                {
                    intArray = new int[] {1,2,3},
                };
                return View("numbers",numbers);
                // return RedirectToAction("Index",user);
                }
            
          

            [HttpGet]
            [Route("users")]
            public IActionResult users()           
            {
            UserList userlist = new UserList()
                {
                    listOfUsers = new List<string> {"frank","mike","tom"},
                    
                };
                return View("users",userlist);
                // return RedirectToAction("Index",user);
                }


            
            



            






            
            


        }
    }
    
    