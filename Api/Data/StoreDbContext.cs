using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products {get;set;}
    }
}