    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    namespace RazorFun.Controllers     //be sure to use your own project's namespace!
    {
        public class RazorController : Controller   
        {
            //for each route this controller is to handle:
            [HttpGet]       //type of request
            [Route("")]     //associated route string (exclude the leading /)
            public IActionResult Index()
            {
                // ViewBag.Example = "Hello World";
                return View();
            }
            // public string Index()
            // {
            //     return "Hello World";
            // }
            
          

            // [HttpGet]
            // [Route("projects")]
            // public IActionResult Projects(string name)
            // {
            //     return View("Project");
            // }

            // [HttpGet]
            // [Route("contact")]
            // public IActionResult contact(string name)
            // {
            //     return View("Contact");
            // }

            // [HttpPost]
            // [Route("message")]
            // public IActionResult message()
            // {
            //     return RedirectToAction("Index");
            // }



        }
    }