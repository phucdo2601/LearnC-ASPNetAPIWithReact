using Microsoft.EntityFrameworkCore;

namespace LearnCRUDRestAPIAspNetRestaurantApp.Models
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<FoodItem> FoodItems { get; set; }

        public DbSet<OrderMaster> OrderMaster { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; } 


    }
}
