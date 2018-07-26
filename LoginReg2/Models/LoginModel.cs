using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginReg2.Models
{

    public class LoginModel
    {
        [Key]      
        public int Id { get; set; }



        [Required(ErrorMessage = "Please enter a valid email")]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required(ErrorMessage = "Please enter between 8 and 255 characters")]
        [MinLength(8),MaxLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }



    }

    
}