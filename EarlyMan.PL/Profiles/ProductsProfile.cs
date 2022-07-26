using AutoMapper;
using EarlyMan.DL.Entities;
using System.Collections.Generic;

namespace EarlyMan.Pl.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<DL.Entities.Product, BL.Models.ProductDto>();
            CreateMap<BL.Models.ProductDto, DL.Entities.Product>();
            CreateMap<BL.Models.ProductForCreationDto, DL.Entities.Product>();
            CreateMap<DL.Entities.Product, BL.Models.ProductForUpdateDto>();
            CreateMap<BL.Models.ProductForUpdateDto, DL.Entities.Product>();
        }
    }
}