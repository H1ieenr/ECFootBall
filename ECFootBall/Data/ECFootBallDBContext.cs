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
        public DbSet<Brand> Brands { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DateTime staticDate = new DateTime(2026, 1, 1, 0, 0, 0);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<ProductVariant>().HasKey(p => p.Id);
            modelBuilder.Entity<Category>().HasKey(p => p.Id);
            modelBuilder.Entity<Color>().HasKey(p => p.Id);
            modelBuilder.Entity<Image>().HasKey(p => p.Id);
            modelBuilder.Entity<Size>().HasKey(p => p.Id);
            modelBuilder.Entity<Brand>().HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
              .HasMany(p => p.Categories)
              .WithMany(c => c.Products)
              .UsingEntity(j => j.ToTable("ProductCategoryLinks"));

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.PricePromotion).HasColumnType("decimal(18,2)");
            });


            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Nike", IsDelete = false, DisplayOrder = 1,CreateBy = "admin",CreateDate = staticDate, IsActive = true },
                new Brand { Id = 2, Name = "Adidas", IsDelete = false, DisplayOrder = 2, CreateBy = "admin", CreateDate = staticDate, IsActive = true },
                new Brand { Id = 3, Name = "Joma", IsDelete = false, DisplayOrder = 3, CreateBy = "admin", CreateDate = staticDate, IsActive = true },
                new Brand { Id = 4, Name = "Mizuno", IsDelete = false, DisplayOrder = 4, CreateBy = "admin", CreateDate = staticDate, IsActive = true },
                new Brand { Id = 5, Name = "Puma", IsDelete = false, DisplayOrder = 5, CreateBy = "admin", CreateDate = staticDate, IsActive = true },
                new Brand { Id = 6, Name = "Asics", IsDelete = false, DisplayOrder = 6, CreateBy = "admin", CreateDate = staticDate, IsActive = true }
            );
            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Name = "Đỏ", IsDelete = false, DisplayOrder = 1, CreateBy = "admin", CreateDate = staticDate, IsActive = true },
                new Color { Id = 2, Name = "Xanh Lá", IsDelete = false, DisplayOrder = 2, CreateBy = "admin", CreateDate = staticDate, IsActive = true },
                new Color { Id = 3, Name = "Đen", IsDelete = false, DisplayOrder = 3, CreateBy = "admin", CreateDate = staticDate, IsActive = true },
                new Color { Id = 4, Name = "Trắng", IsDelete = false, DisplayOrder = 4, CreateBy = "admin", CreateDate = staticDate, IsActive = true },
                new Color { Id = 5, Name = "Vàng", IsDelete = false, DisplayOrder = 5, CreateBy = "admin", CreateDate = staticDate, IsActive = true },
                new Color {Id = 6, Name = "Xanh Dương", IsDelete = false, DisplayOrder = 6, CreateBy = "admin", CreateDate = staticDate   , IsActive = true }
            );

            modelBuilder.Entity<Size>().HasData(
                new Size { Id = 1, Name = "38", IsDelete = false, DisplayOrder = 1, CreateBy = "admin", CreateDate = staticDate, IsActive = true },
                new Size {Id = 2, Name = "39", IsDelete = false, DisplayOrder = 2, CreateBy = "admin", CreateDate = staticDate, IsActive = true },
                new Size {Id = 3, Name = "40", IsDelete = false, DisplayOrder = 3, CreateBy = "admin", CreateDate = staticDate, IsActive = true },
                new Size {Id = 4, Name = "41", IsDelete = false, DisplayOrder = 4, CreateBy = "admin", CreateDate = staticDate, IsActive = true },
                new Size {Id = 5, Name = "42", IsDelete = false, DisplayOrder = 5, CreateBy = "admin", CreateDate = staticDate, IsActive = true },
                new Size {Id = 6, Name = "43", IsDelete = false, DisplayOrder = 6, CreateBy = "admin", CreateDate = staticDate, IsActive = true },
                new Size {Id = 7, Name = "44", IsDelete = false, DisplayOrder = 7, CreateBy = "admin", CreateDate = staticDate, IsActive = true }
            );

            modelBuilder.Entity<Category>().HasData(
                //new Category { Id = 1, Name = "Giày Cỏ Tự Nhiên", IsActive = true },
                //new Category { Id = 2, Name = "Giày Cỏ Nhân Tạo", IsActive = true }
            );
        }
    }
}
