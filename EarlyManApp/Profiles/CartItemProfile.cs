using AutoMapper;

namespace EarlyMan.Profiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<Entities.CartItem, Models.CartItemDto>();
            CreateMap<IEnumerable<Entities.CartItem>, IEnumerable<Models.CartItemDto>>();      
        }
    }
}
