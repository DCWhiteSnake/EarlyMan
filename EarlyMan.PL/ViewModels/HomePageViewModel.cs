
using System.Collections.Generic;
using EarlyMan.BL.Models;

namespace EarlyMan.PL.ViewModels
{
    public class HomePageViewModel
    { 
        public List<PromotionDto> Promotions{ get; set; }
        public List<ProductDto> Products { get; set; }
        public int Count { get; set; }
      
      
    }
}