using Microsoft.EntityFrameworkCore;

namespace SalesTransactionService.Context
{
    public class SalesTransactionDbContext : DbContext
    {
        public SalesTransactionDbContext()
        {

        }
        public SalesTransactionDbContext(DbContextOptions options) : base(options)
        {
        }
   //     protected override void OnConfiguring(DbContextOptionsBuilder
   //optionsBuilder)
   //     {
           
   //     }
       public DbSet<SalesTransaction> SalesTransactions { get; set; }

    }
}
