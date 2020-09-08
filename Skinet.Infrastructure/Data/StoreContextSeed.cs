using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Skinet.Core.Entities;

namespace Skinet.Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerfactory)
        {
            try
            {
                if(!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Skinet.Infrastructure/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    
                   foreach (var item in brands)
                   {
                       context.ProductBrands.Add(item);
                   }
                    await context.SaveChangesAsync();
                }

                 if(!context.ProductTypes.Any())
                {
                    var brandsData = File.ReadAllText("../Skinet.Infrastructure/Data/SeedData/types.json");

                    var producttypes = JsonSerializer.Deserialize<List<ProductType>>(brandsData);
                    
                   foreach (var item in producttypes)
                   {
                       context.ProductTypes.Add(item);
                   }
                    await context.SaveChangesAsync();
                }

                 if(!context.Products.Any())
                {
                    var brandsData = File.ReadAllText("../Skinet.Infrastructure/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(brandsData);
                    
                   foreach (var item in products)
                   {
                       context.Products.Add(item);
                   }
                    await context.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                
                var logger = loggerfactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}