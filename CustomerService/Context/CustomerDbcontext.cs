using Microsoft.EntityFrameworkCore;

namespace CustomerService.Context
{
    public class CustomerDbContext:DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder
   optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=DESKTOP-2OLH8N9; database=CustomerDB;Trusted_Connection=True;");
            }
        }
     public   DbSet<Customer> Customers { get; set; }

    }
}


