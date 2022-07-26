using AutoMapper;

namespace EarlyMan.PL.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<DL.Entities.Cart, BL.Models.CartItemDto>();
            CreateMap<BL.Models.CartForCreationDto, DL.Entities.Cart>();
            CreateMap<DL.Entities.Cart, BL.Models.CartForUpdateDto>();
            CreateMap<BL.Models.CartForUpdateDto, DL.Entities.Cart>();
           
        }
    }
}