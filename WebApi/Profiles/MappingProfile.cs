using AutoMapper;
using Domain.Entities.Product;
using WebApi.Dtos;

namespace WebApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>();
            CreateMap<ProductToCreateDto, Product>();
            CreateMap<ProductToUpdateDto, Product>();
            CreateMap<Product, ProductToUpdateDto>();
        }
    }
}