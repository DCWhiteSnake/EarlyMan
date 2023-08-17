using AutoMapper;

namespace EarlyMan.Profiles
{
    public class PromotionProfile:Profile
    {
        public PromotionProfile()
        {
            CreateMap<Entities.Promotion, Models.PromotionDto>();
            CreateMap<Models.PromotionForCreationDto, Entities.Promotion>();
            CreateMap<Entities.Promotion, Models.PromotionForUpdateDto>();
            CreateMap<Models.PromotionForUpdateDto, Entities.Promotion>();
        }
    }
}
