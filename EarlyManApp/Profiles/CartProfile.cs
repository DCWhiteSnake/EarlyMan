using AutoMapper;

namespace EarlyMan.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Entities.Cart, Models.CartItemDto>();
            CreateMap<Models.CartForCreationDto, Entities.Cart>();
            CreateMap<Entities.Cart, Models.CartForUpdateDto>();
            CreateMap<Models.CartForUpdateDto, Entities.Cart>();
        }
    }
}