using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EarlyMan.Models.ViewModels
{
    public class HomepageItems
    {
        // Do I plug in the services I have created here?
        public IProductRepository ProductRepository { get; set; }

        public IPromotionRepository PromotionRepository { get; set; }
    }
}