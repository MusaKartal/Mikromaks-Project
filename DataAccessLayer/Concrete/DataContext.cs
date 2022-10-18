using EntitiesLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MOSES\SQLEXPRESS;Database=MikromaksDb;User Id=sa;Password=1;");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set;}
        public DbSet<Order> Orders { get; set; }
    }
}
