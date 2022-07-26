using AutoMapper;

namespace EarlyMan.PL.Profiles
{
    public class PromotionProfile:Profile
    {
        public PromotionProfile()
        {
            CreateMap<DL.Entities.Promotion, BL.Models.PromotionDto>();
            CreateMap<BL.Models.PromotionForCreationDto, DL.Entities.Promotion>();
            CreateMap<DL.Entities.Promotion, BL.Models.PromotionForUpdateDto>();
            CreateMap<BL.Models.PromotionForUpdateDto, DL.Entities.Promotion>();
        }
    }
}
