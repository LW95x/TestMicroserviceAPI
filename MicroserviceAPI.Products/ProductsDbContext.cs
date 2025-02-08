using Microsoft.EntityFrameworkCore;

namespace MicroserviceAPI.Products
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
