using BE_Project_29_07_02_08.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Project_29_07_02_08.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
        }
    }
}
