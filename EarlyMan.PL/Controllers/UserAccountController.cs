using EarlyMan.DL.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EarlyMan.PL.Controllers
{
    [Authorize]
    public class UserAccountController : Controller
    {
        private readonly UserManager<ApplicationUser> usrMgr;

        public UserAccountController(UserManager<ApplicationUser> usrMgr)
        {
            this.usrMgr = usrMgr;
        }
        public IActionResult Index(bool pwd_ChangeSuccess, bool account_ChangeSuccess)
        {
            if (pwd_ChangeSuccess == true)
            {
                ViewBag.pwd_ChangeSuccess = true;
            }

            else if(account_ChangeSuccess == true)
            {
                ViewBag.account_ChangeSuccess = true;
            }


            return View();

        }
    }
}
