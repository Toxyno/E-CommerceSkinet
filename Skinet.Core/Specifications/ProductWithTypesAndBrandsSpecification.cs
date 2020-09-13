using System;
using System.Linq.Expressions;
using Skinet.Core.Entities;

namespace Skinet.Core.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Entities.Product>
    {
        public ProductWithTypesAndBrandsSpecification(ProductSpecParams productParams)
        :base(x=>
               (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))
               && (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId)
               && (!productParams.typeId.HasValue || x.ProductTypeId == productParams.typeId)
           )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x=>x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex-1),productParams.PageSize);

            if(!string.IsNullOrEmpty(productParams.Sort))
            {
                switch(productParams.Sort){
                    case "priceASC": AddOrderBy(p =>p.Price);
                    break;
                    case "priceDESC": AddOrderByDescending(p => p.Price);
                    break;
                    default:
                    AddOrderBy(p => p.Name);
                    break;
                }
            }
        }

        public ProductWithTypesAndBrandsSpecification(int id)
         : base(x => x.Id == id)
        { 
             AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}