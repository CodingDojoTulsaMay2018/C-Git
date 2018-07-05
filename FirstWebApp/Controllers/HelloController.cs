    using Microsoft.AspNetCore.Mvc;
    namespace FirstWebApp.Controllers     //be sure to use your own project's namespace!
    {
        public class HelloController : Controller   
        {
            //for each route this controller is to handle:
            [HttpGet]       //type of request
            [Route("")]     //associated route string (exclude the leading /)
            public string Index()
            {
                return "This is my index!";
            }


            [HttpGet]
            [Route("projects")]
            public string Projects(string name)
            {
                return "These are my projects";
            }

            [HttpGet]
            [Route("contact")]
            public string contact(string name)
            {
                return "This is my contact";
            }

            [HttpGet]
            [Route("contact/{name}")]
            public string contactName(string name)
            {
                return $"This is my contact {name}";
            }

        }
    }