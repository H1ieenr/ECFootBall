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

            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Name = "Đỏ", IsDelete = false },
                new Color { Id = 2, Name = "Xanh Lá", IsDelete = false },
                new Color { Id = 3, Name = "Đen", IsDelete = false },
                new Color { Id = 4, Name = "Trắng", IsDelete = false },
                new Color { Id = 5, Name = "Vàng", IsDelete = false },
                new Color { Id = 6, Name = "Xanh Dương", IsDelete = false }
            );

            modelBuilder.Entity<Size>().HasData(
                new Size { Id = 1, Name = "38", IsDelete = false },
                new Size { Id = 2, Name = "39", IsDelete = false },
                new Size { Id = 3, Name = "40", IsDelete = false },
                new Size { Id = 4, Name = "41", IsDelete = false },
                new Size { Id = 5, Name = "42", IsDelete = false },
                new Size { Id = 6, Name = "43", IsDelete = false },
                new Size { Id = 7, Name = "44", IsDelete = false }
            );

            modelBuilder.Entity<Category>().HasData(
                //new Category { Id = 1, Name = "Giày Cỏ Tự Nhiên", IsActive = true },
                //new Category { Id = 2, Name = "Giày Cỏ Nhân Tạo", IsActive = true }
            );
        }
    }
}
