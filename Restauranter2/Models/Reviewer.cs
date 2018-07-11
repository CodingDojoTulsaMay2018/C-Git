using System;
using System.ComponentModel.DataAnnotations;


namespace Restauranter2.Models

{
    public class CustomDateAttribute : RangeAttribute 
    { 
        public CustomDateAttribute() 
        : base(typeof(DateTime), 
        DateTime.Now.AddYears(-6).ToShortDateString(), 
        DateTime.Now.ToShortDateString()) { } 
    }
    public class Reviewer
    
    {
        


        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter between 3 and 255 characters")]
        [MinLength(3),MaxLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter between 10 and 255 characters")]
        public string Restaurant { get; set; }

        [Required(ErrorMessage = "Please enter between 10 and 255 characters")]
        [MinLength(10),MaxLength(255)]
        public string Review { get; set; }

        [Required]
        public int Stars { get; set; }
           
        
        [Required] [CustomDateAttribute (ErrorMessage = "Please enter a valid date")]
        public DateTime VisitDate { get; set; }


        
        }


    }


   

    