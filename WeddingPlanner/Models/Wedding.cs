using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{

    public class Wedding
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter between 2 and 255 characters")]
        [MinLength(2),MaxLength(255)]
        public string Groom {get; set;}
        [Required(ErrorMessage = "Please enter between 2 and 255 characters")]
        [MinLength(2),MaxLength(255)]
        public string Bride{get; set;}
        public DateTime Wedding_Date {get; set;}

        public int Guest_Count {get;set;}
        [Required(ErrorMessage = "Please enter between 2 and 255 characters")]
        [MinLength(2),MaxLength(255)]
        public string Address {get;set;}
        
        
        public int UserId { get; set; } ///Column foreign key
        public User Creator { get; set; }
        
        public List<Guest> GuestList {get; set;}
        
        
        public Wedding(){
            List<Guest> GuestList = new List<Guest>();
            
            Guest_Count = 0;
            
        }
        

        
    }
}