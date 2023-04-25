using Harambee.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Harambee.Data.SQL
{
    public class ShopDbContext : DbContext
    {
        private readonly string _connectionString;

        public ShopDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SQL");
        }
        //public ShopDbContext(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString, builder =>
    builder.MigrationsAssembly("Harambee.Data"));
        }

        // Define your entity sets here
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
