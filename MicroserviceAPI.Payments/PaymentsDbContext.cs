using Microsoft.EntityFrameworkCore;

namespace MicroserviceAPI.Payments
{
    public class PaymentsDbContext : DbContext
    {
        public DbSet<Payment> Payments { get; set; } = null!;

        public PaymentsDbContext(DbContextOptions<PaymentsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
