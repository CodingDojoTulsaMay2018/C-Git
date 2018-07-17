using Microsoft.EntityFrameworkCore;
 
namespace WeddingPlanner.Models
{
    public class YourContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public YourContext(DbContextOptions<YourContext> options) : base(options) { }
        public DbSet<User> Users{ get; set; } //reviewer = the table name
        //<Reviewer> is the class model that will link to the database
        public DbSet<Wedding> Weddings{ get; set; }

        public DbSet<Guest> Plans {get;set;}
        //public DbSet<ModelName>TableName
    }
}