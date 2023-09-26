using System.Reflection;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products {get;set;}
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuration Fluent API
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Microsoft.EntityFrameworkCore.Sqlite         
            // if (Database.ProviderName == "Microsoft.EntityFrameworkCore.SqlServer")
            // {
            //     foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //     {
            //         var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

            //         foreach (var property in properties)
            //         {
            //             //modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
            //             modelBuilder.Entity(entityType.Name).Property(property.Name).HasColumnType("decimal(18,2)");
            //         }
            //     }
            // }

            // modelBuilder.Entity<Product>()
            // .Property(p => p.Price)
            // .HasColumnType("decimal(18,4)");

            foreach(var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
        }
    }
}