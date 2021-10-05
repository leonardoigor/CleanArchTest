using CleanApi.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace CleanApi.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }




        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ProductConfig());
        
        }
    }
}
