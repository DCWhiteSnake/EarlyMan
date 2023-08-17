using Microsoft.AspNetCore.Mvc;

namespace EarlyMan.Controllers
{
    public class ErrorController:Controller
    {

        public ViewResult Index()
        {
            return View("NotFound");
        }
    }
}
