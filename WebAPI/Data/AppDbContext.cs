using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
       
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<News> News { get; set; }
        public  DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Subscribe> Subscribe { get; set; }
    }
}
