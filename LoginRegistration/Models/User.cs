using System;
using System.ComponentModel.DataAnnotations;


namespace LoginRegistration.Models

{
    public abstract class BaseEntity {}

    public class User : BaseEntity
    
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
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string Email { get; set; }
 
        [Required(ErrorMessage = "Please enter between 8 and 255 characters")]
        [MinLength(8),MaxLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
      
        }


    }