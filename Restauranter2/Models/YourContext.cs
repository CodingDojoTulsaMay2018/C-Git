using Microsoft.EntityFrameworkCore;
 
namespace Restauranter2.Models
{
    public class YourContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public YourContext(DbContextOptions<YourContext> options) : base(options) { }
        public DbSet<Reviewer> reviewer { get; set; } //reviewer = the table name
        //<Reviewer> is the class model that will link to the database
        
    }
}