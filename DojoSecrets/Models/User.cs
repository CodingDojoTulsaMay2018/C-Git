using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DojoSecrets.Models
{

    public class User 
    {
        [Key]      
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter between 2 and 255 characters")]
        [MinLength(2),MaxLength(255)]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Please enter between 2 and 255 characters")]
        [MinLength(2),MaxLength(255)]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "Please enter a valid email")]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required(ErrorMessage = "Please enter between 8 and 255 characters")]
        [MinLength(8),MaxLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

       
        public DateTime Created_At { get; set; } = DateTime.Now;
        public DateTime Updated_At { get; set; } = DateTime.Now;




        public List<Secret>UserSecrets {get;set;}
        public User(){
            Created_At = DateTime.Now;
            UserSecrets = new List<Secret>();
        }
       

    }
 

    
}