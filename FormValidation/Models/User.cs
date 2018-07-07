using System.ComponentModel.DataAnnotations;
namespace FormValidation.Models
{
    public class User
    {
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }
 
        [Required]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Range(1,99)]
        public string Age { get; set; }

        
    }
}
