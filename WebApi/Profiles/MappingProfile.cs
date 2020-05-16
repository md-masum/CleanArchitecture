using AutoMapper;
using WebApi.Dtos;
using WebApi.Models;

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