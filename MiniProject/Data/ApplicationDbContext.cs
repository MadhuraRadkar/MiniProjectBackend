using Microsoft.EntityFrameworkCore;
using MiniProject.Model;

namespace MiniProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Registration> registers {  get; set; } 

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
   
}
