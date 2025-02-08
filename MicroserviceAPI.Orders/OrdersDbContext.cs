using Microsoft.EntityFrameworkCore;

namespace MicroserviceAPI.Orders
{
    public class OrdersDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } = null!;

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
