using AutoMapper;
using EarlyMan.Models;
using EarlyMan.Entities.Identity;
using EarlyMan.Services;
using EarlyMan.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.RegularExpressions;
namespace EarlyMan.Controllers
{
    [Authorize]
    public partial class HomeController : Controller
    {
        private readonly IProductRepository _prodRepo;
        private readonly IPromotionRepository _promoRepo;
        private readonly ICartRepository _cartRepo;
        private readonly ICartItemRepository _cartItemRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(IProductRepository prodRepo, IPromotionRepository promoRepo,
            ICartRepository cartRepo, ICartItemRepository cartItemRepository, IMapper mapper,
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
            try
            {
                homePageItems.Products = GetProductsAsDtos(pageNumber, homePageItems._DefPageSize, keyword) as List<ProductDto>;

                if (homePageItems.Products.Count == 0)
                {
                    return RedirectToAction("Error", new {message = "Product not found", code =404});
                }
                var _ = InstantiateNumberOfPagesProperty(homePageItems);
                homePageItems.Promotions = GetPromotionAsDtos() as List<PromotionDto>;
                AssignUserCartSizeToViewData_ItemCount_Key();
                return View(homePageItems);
            }
            catch (NullReferenceException)
            {
                    return RedirectToAction("Error", new {message = "Product not found", code =404});

            }
        }

        [AllowAnonymous]
        public ViewResult Error(string message, int code = 400)
        {
            var errorPageViewModel = new ErrorPageViewModel()
            {
                Code = code,
                Message = message
            };
            return View(errorPageViewModel);
        }

        [AllowAnonymous]
        public ViewResult Privacy() => View();

        #region helpers
        public void AssignUserCartSizeToViewData_ItemCount_Key()
        {
            // If the user is signed in then pass their cart size to the viewdata property.
            if (_signInManager.IsSignedIn(User))
            {
                var userId = new Guid(HttpContext.User.Claims.FirstOrDefault
                (c => c.Type == ClaimTypes.NameIdentifier).Value);

                ViewData["ItemCount"] = _cartItemRepo.Count(userId);
            }
        }

        /// <summary>
        /// Asigns the number of pages(which depends on the number of products) to the HomepageViewModel.numberOfPages variable;
        /// </summary>
        /// <param name="homePageItems"></param>
        /// <returns>The number of pages</returns>
        public int InstantiateNumberOfPagesProperty(HomePageViewModel homePageItems)
        {
            var itemCount = _prodRepo.Size();
            //homePageItems.numberOfPages = (itemCount % homePageItems.PageSize == 0)? itemCount/homePageItems.PageSize :
            //    itemCount/homePageItems.PageSize + 1;
            homePageItems.numberOfPages = itemCount % homePageItems._DefPageSize == 0 ? itemCount / homePageItems._DefPageSize :
             itemCount / homePageItems._DefPageSize + 1;

            return homePageItems.numberOfPages;
        }



        /// <summary>
        /// Returns an enumrable of productDtos
        /// </summary>
        /// <param name="pageNumber">The number of the page</param>
        /// <param name="pageSize">The size of the page</param>
        /// <param name="filter">The string to match products to, if empty,
        /// it matches all products</param>
        /// <returns></returns>
        public IEnumerable<ProductDto> GetProductsAsDtos(int pageNumber,
            int pageSize, string filter = "")
        {
            List<ProductDto> productsToPass = new();
            try
            {
                var products = _prodRepo.GetProducts(pageNumber, pageSize, filter);
                if (products.Any())
                {
                    productsToPass = _mapper.Map<IEnumerable<ProductDto>>(products).ToList();
                }
                return productsToPass;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                // log this and catch responsibly.
                return productsToPass;
            }


        }

        public IEnumerable<PromotionDto> GetPromotionAsDtos()
        {
            try
            {
               List<PromotionDto> promotionsToPass = 
               _mapper.Map<IEnumerable<PromotionDto>>(_promoRepo.GetPromos()).ToList();
                return promotionsToPass;

            }
            catch (NullReferenceException)
            {
                throw;
            }

        }
        }
        #endregion
}