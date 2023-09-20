using System.Reflection;
using System.Text.Json;
using Core.Entities;
using Core.Entities.OrderAggregate;

namespace Infrastructure.Data;

public class SeedData
{
    public static async Task SeedAsync(StoreDbContext context)
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        if (!context.ProductBrands.Any())
        {
            var brandsData = File.ReadAllText(path + @"/Data/Seeds/json/brands.json");
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
            context.ProductBrands.AddRange(brands);
        }

        if (!context.ProductTypes.Any())
        {
            var typesData = File.ReadAllText(path + @"/Data/Seeds/json/types.json");
            var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
            context.ProductTypes.AddRange(types);
        }

        if (!context.Products.Any())
        {
            var productsData = File.ReadAllText(path + @"/Data/Seeds/json/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            context.Products.AddRange(products);
        }

        if (!context.DeliveryMethods.Any())
        {
            var deliveryData = File.ReadAllText(path + @"/Data/Seeds/json/delivery.json");
            var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);
            context.DeliveryMethods.AddRange(methods);
        }

        if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
    }
}
