using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;

namespace Skinet.Infrastructure.Data.ConcreteRepository
{
    public class ProductRepository : IProductRepository
    {
        //We need to inject the storeContext into the PR ctor
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;

        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
           return await _context.Products
                    .Include(p => p.ProductType)
                    .Include(p => p.ProductBrand) 
                    .FirstOrDefaultAsync(p => p.ProductTypeId==id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
           return await _context.Products
                       .Include(p => p.ProductType)
                       .Include(p => p.ProductBrand)           
                       .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
           return await _context.ProductTypes.ToListAsync();
        }
    }


}