using Microsoft.AspNetCore.Mvc;

namespace EarlyMan.PL.Controllers
{
    public class ErrorController:Controller
    {

        public ViewResult Index()
        {
            return View("NotFound");
        }
    }
}
