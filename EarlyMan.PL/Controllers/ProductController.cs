using AutoMapper;
using EarlyMan.DL.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EarlyMan.PL.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductRepository _productRepo;
        public readonly IMapper _mapper;

      
        
        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepo = productRepository;
            _mapper = mapper;
        }
  
        
        public IActionResult Details(Guid productId)
        {     
            //var productGuid = Guid.Parse(productId);
            var product = _productRepo.GetProductById(productId);
            var productDto = _mapper.Map<BL.Models.ProductDto>(product);
            return View(productDto);
        }

        
        public IActionResult Product([FromQuery]Guid productId)
        {
            //var productGuid = Guid.Parse(productId);
            var product = _productRepo.GetProductById(productId);
            var productDto = _mapper.Map<BL.Models.ProductDto>(product);
            return View("Details", productDto);
        }



    }
}
