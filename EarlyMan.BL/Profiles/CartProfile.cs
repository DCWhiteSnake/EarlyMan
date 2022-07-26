using AutoMapper;

namespace EarlyMan.BL.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<DL.Entities.Cart, Models.CartItemDto>();
            CreateMap<Models.CartForCreationDto, DL.Entities.Cart>();
            CreateMap<DL.Entities.Cart, Models.CartForUpdateDto>();
            CreateMap<Models.CartForUpdateDto, DL.Entities.Cart>();
        }
    }
}