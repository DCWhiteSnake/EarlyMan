using AutoMapper;
using EarlyMan.BL.Models;
using EarlyMan.DL.Entities.Identity;
using EarlyMan.DL.Services;
using EarlyMan.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace EarlyMan.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProductRepository _prodRepo;
        private readonly IPromotionRepository _promoRepo;
        private readonly ICartRepository _cartRepo;
        private readonly ICartItemRepository _cartItemRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(IProductRepository prodRepo, IPromotionRepository promoRepo, ICartRepository cartRepo, ICartItemRepository cartItemRepository, IMapper mapper,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _promoRepo = promoRepo;
            _prodRepo = prodRepo;
            _cartRepo = cartRepo;
            _cartItemRepo = cartItemRepository;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Index(string keyword, int pageNumber)
        {
            ViewBag.Title = "Home | EarlyMan";
            HomePageViewModel homePageItems = new();
            
            homePageItems.PageNumber = pageNumber;
            var pageSize = homePageItems.PageSize;
            homePageItems.Keyword = keyword;
            homePageItems.Products = GetProductsAsDtos(homePageItems.PageNumber, pageSize, keyword).ToList();

            if (homePageItems.Products.Count == 0)
            {
                return Redirect("/error/index");
            }



            homePageItems.Promotions = GetPromotionAsDtos().ToList();
            var itemCount = _prodRepo.Size();

            homePageItems.numberOfPages = (itemCount % pageSize == 0)? itemCount/pageSize: itemCount/pageSize + 1;

            if (_signInManager.IsSignedIn(User))
            {
                var userId = new Guid(HttpContext.User.Claims.FirstOrDefault
                (c => c.Type == ClaimTypes.NameIdentifier).Value);

                ViewData["ItemCount"] = _cartItemRepo.Count(userId);
            }


            
            return View(homePageItems);
        }

        [AllowAnonymous]
        public ViewResult NotFound() => View();

        [AllowAnonymous]
        public ViewResult Error() => View();

        [AllowAnonymous]
        public ViewResult Privacy() => View();




        #region utility functions

        public IEnumerable<ProductDto> GetProductsAsDtos(int pageNumber,
            int pageSize, string filter = "")
        { 
           
            IEnumerable<ProductDto> productsToPass;
            try
            {
                var products = _prodRepo.GetProducts(pageNumber, pageSize, filter);
                productsToPass = _mapper.Map<IEnumerable<ProductDto>>(products);
            }
            catch (NullReferenceException ex)
            {
                // log this and catch responsibly.
                throw ex;
            }

            return productsToPass;
        }

        public IEnumerable<PromotionDto> GetPromotionAsDtos()
        {
            var promotionsToPass = new List<PromotionDto>();
            try
            {
                var promotion = _promoRepo.GetPromos();
                promotionsToPass = _mapper.Map<IEnumerable<PromotionDto>>(promotion).ToList();
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }

            return promotionsToPass;
        }

        private int GetCartSize()
        {
            //int result = 0;
            //if (_signInManager.IsSignedIn(User))
            //{
            //    result = _cartRepo.GetById().CartItems.Count;
            //}
            return 5;
        }


        
        #endregion utility functions
    }
}