
using System.Collections.Generic;
using EarlyMan.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EarlyMan.PL.ViewModels
{
    public class HomePageViewModel
    { 
        public List<PromotionDto> Promotions{ get; set; }
        public List<ProductDto> Products { get; set; }
        
      

      
      
    }
}