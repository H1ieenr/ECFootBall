using ECFootball.Order.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECFootball.Order.API.Data
{
    public class ECFootBallOrderDBContext : DbContext
    {
        public ECFootBallOrderDBContext(DbContextOptions<ECFootBallOrderDBContext> options) : base(options)
        { }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ECFootball.Order.API.Models.Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>().HasKey(p => p.Id);
            modelBuilder.Entity<CartItem>().HasKey(p => p.Id);
            modelBuilder.Entity<OrderItem>().HasKey(p => p.Id);
            modelBuilder.Entity<ECFootball.Order.API.Models.Order>().HasKey(p => p.Id);
        }
    }
}
