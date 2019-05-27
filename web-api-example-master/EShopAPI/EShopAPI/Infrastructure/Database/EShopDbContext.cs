using EShopAPI.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Infrastructure.Database
{
    public class EShopDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }

        public EShopDbContext(DbContextOptions<EShopDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetUpProducts(modelBuilder);
            SetUpTags(modelBuilder);
            SetUpProductTags(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SetUpProducts(ModelBuilder modelBuilder)
        {
            var productEntity = modelBuilder.Entity<Product>();
            productEntity.HasKey(x => x.Id);
            productEntity.HasMany(x => x.ProductTag)
                .WithOne(pt => pt.Product)
                .HasForeignKey(pt => pt.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void SetUpTags(ModelBuilder modelBuilder)
        {
            var tagEntity = modelBuilder.Entity<Tag>();
            tagEntity.HasKey(x => x.Id);
            tagEntity.HasMany(x => x.ProductTags)
                .WithOne(pt => pt.Tag)
                .HasForeignKey(pt => pt.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void SetUpProductTags(ModelBuilder modelBuilder)
        {
            var productTagEntity = modelBuilder.Entity<ProductTag>();
            productTagEntity
                .HasKey(x => new { x.ProductId, x.TagId });
        }
    }
}
