using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    namespace DateTime.Controllers     //be sure to use your own project's namespace!
    {
        public class DateTimeController : Controller   
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
            
          





        }
    }