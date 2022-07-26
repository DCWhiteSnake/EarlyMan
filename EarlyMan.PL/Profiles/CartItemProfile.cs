using AutoMapper;
using System.Collections.Generic;

namespace EarlyMan.PL.Profiles
{
    public class CartItemProfile:Profile
    {
        public CartItemProfile()
        {
            CreateMap<DL.Entities.CartItem, BL.Models.CartItemDto>();
            CreateMap<IEnumerable<DL.Entities.CartItem>, IEnumerable<BL.Models.CartItemDto>>();
        }
    }
}
