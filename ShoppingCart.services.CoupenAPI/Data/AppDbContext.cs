using Microsoft.EntityFrameworkCore;
using ShoppingCart.services.CoupenAPI.Models;

namespace ShoppingCart.services.CoupenAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Coupen> Coupen { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupen>().HasData(new Coupen
            {
                CoupenId = 1,
                CoupenCode = "Coupen1",
                DiscountAmount = 100,
                MinAmount=400

            });
            modelBuilder.Entity<Coupen>().HasData(new Coupen
            {
                CoupenId = 2,
                CoupenCode = "Coupen3",
                DiscountAmount = 90,
                MinAmount = 872

            });
            modelBuilder.Entity<Coupen>().HasData(new Coupen
            {
                CoupenId = 3,
                CoupenCode = "Coupen3",
                DiscountAmount = 98,
                MinAmount = 748

            });
        }
    }
}
