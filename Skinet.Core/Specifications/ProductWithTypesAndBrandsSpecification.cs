using System;
using System.Linq.Expressions;
using Skinet.Core.Entities;

namespace Skinet.Core.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecication<Entities.Product>
    {
        public ProductWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);

        }

        public ProductWithTypesAndBrandsSpecification(int id)
         : base(x => x.Id == id)
        { 
             AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}