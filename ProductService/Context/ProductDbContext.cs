
using Microsoft.EntityFrameworkCore;

namespace ProductService.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext()
        {

        }
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }
   //     protected override void OnConfiguring(DbContextOptionsBuilder
   //optionsBuilder)
   //     {
   //         if (!optionsBuilder.IsConfigured)
   //         {
   //             optionsBuilder.UseSqlServer("server=DESKTOP-2OLH8N9; database=ProductDB;Trusted_Connection=True;");
   //         }
   //     }
       public DbSet<Product> Products { get; set; }

    }
}


