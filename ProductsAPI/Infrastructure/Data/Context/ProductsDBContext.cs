using Microsoft.EntityFrameworkCore;
using ProductsAPI.Domain.Models;
using ProductsAPI.Infrastructure.Data.EnityConfigurations;

namespace ProductsAPI.Infrastructure.Data
{
    public class ProductsDBContext :DbContext
    {
        public ProductsDBContext(DbContextOptions<ProductsDBContext> options) 
            : base(options)
        {
        }
        public DbSet<ProductModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
