using BE_Project_29_07_02_08.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Project_29_07_02_08.Context
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderedProduct> OrderedProducts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }


        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
        }
    }
}
