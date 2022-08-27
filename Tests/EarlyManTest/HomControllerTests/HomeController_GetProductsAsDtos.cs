using EarlyMan.Controllers;
using EarlyMan.DL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.HomControllerTests
{
    public class HomeController_GetProductsAsDtos
    {
       // Gets Paginated Products

       // Converts each Products Model to ProductDto Model

       /// Logs warning if database is empty

       // Test that the number of products is at most 6 when there's no search keyword
       [Fact]
       public void ReturnsSixProductsWithNoSearchStringOrPageNumber()
       {
            // Arrange
            var productRepo = new InMemoryProductRepository();
            var promotionRepo = new InMemoryPromotionRepository();
            var cartItemRepo = new InMemoryCartItemRepository();
            var cartRepo = new InMemoryCartRepository();

            // How to Mock User Manager and Sign In Manager?
            //var homeController = new HomeController() 
            
            
            //

        }
        // Test that different page numbers yield different results
        // Test that the products returns is sorted date created then time
        // Test that a search string yields the required result.
    }
}
