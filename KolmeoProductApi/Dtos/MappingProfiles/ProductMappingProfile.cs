using AutoMapper;
using KolmeoProductApi.Models;

namespace KolmeoProductApi.Dtos.MappingProfiles
{
    /// <summary>
    /// Represents a mapping profile that maps Products to ProductDtos and vice versa.
    /// </summary>
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<ProductDto, Product>();
        }
    }
}
