using ECFootBall.Models;
using Microsoft.EntityFrameworkCore;

namespace ECFootBall.Data
{
    public class ECFootBallDBContext : DbContext
    {
        public ECFootBallDBContext(DbContextOptions<ECFootBallDBContext> options) : base(options)
        {}
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<ProductVariant>().HasKey(pv => pv.Id);
            modelBuilder.Entity<Category>().HasKey(p => p.Id);
            modelBuilder.Entity<Color>().HasKey(pv => pv.Id);
            modelBuilder.Entity<Image>().HasKey(pv => pv.Id);
            modelBuilder.Entity<Size>().HasKey(pv => pv.Id);
        }
    }
}
