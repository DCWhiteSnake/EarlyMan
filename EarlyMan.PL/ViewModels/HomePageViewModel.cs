﻿
using System.Collections.Generic;
using EarlyMan.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EarlyMan.PL.ViewModels
{
    public class HomePageViewModel
    { 
        public  readonly int _DefPageNum = 1;
        public  readonly int _DefPageSize = 6;
        public int numberOfPages;
        public List<PromotionDto> Promotions{ get; set; }
        public List<ProductDto> Products { get; set; }
        
        //[BindProperty(SupportsGet =true)]
        //public int PageNumber { get; set; }
        
        //[BindProperty(SupportsGet = true)]
        //public int PageSize { get; set; } = _DefPageSize;
        
        [BindProperty(SupportsGet = true)]
        public string Keyword { get; set; }
      

      
      
    }
}