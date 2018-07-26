using System;
using System.ComponentModel.DataAnnotations;


namespace LoginRegistration.Models

{

    public class Register : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string First_Name { get; set; }

        [Required]
        [MinLength(3)]
        public string Last_Name { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConf { get; set; }
        
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }



    }
}