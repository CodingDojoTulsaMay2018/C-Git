using System.ComponentModel.DataAnnotations;
namespace DapperBase2.Models
{
    public abstract class BaseEntity {}
    public class Users : BaseEntity
    {
        [Key]
        public long Id { get; set; }
 
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
 
        [Required]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required]
        public string Password { get; set; }
    }
}
