using AutoMapper;

namespace EarlyMan.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Entities.Product, Models.ProductDto>();
            CreateMap<Models.ProductDto, Entities.Product>();
            // CreateMap<IEnumerable<Entities.Product>, IEnumerable<Models.ProductDto>>();
            CreateMap<Models.ProductForCreationDto, Entities.Product>();
            CreateMap<Entities.Product, Models.ProductForUpdateDto>();
            CreateMap<Models.ProductForUpdateDto, Entities.Product>();
        }
    }
}