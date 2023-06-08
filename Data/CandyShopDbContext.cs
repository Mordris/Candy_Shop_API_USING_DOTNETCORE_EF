using Microsoft.EntityFrameworkCore;
using CandyShopAPI.Models.Domain;

namespace CandyShopAPI.Data
{
    public class CandyShopDbContext : DbContext
    {
        public CandyShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Dealers> Dealers { get; set; }
        public DbSet<Employees> Employees { get; set; }

    }
}
