using AutoMapper;
using Skinet.Core.Entities;
using skinetAPI.DTOs;

namespace skinetAPI.Helpers
{
    public class MappingProfile:Profile
    {
        //We need to Add automapper as a server
        //So we do that inside the STartUp class
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDTO>()
                .ForMember(e => e.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(e => e.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(e => e.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}