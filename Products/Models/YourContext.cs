using Microsoft.EntityFrameworkCore;
 
namespace Products.Models
{
    public class YourContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public YourContext(DbContextOptions<YourContext> options) : base(options) { }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories{ get; set; }
       
        



    }
}