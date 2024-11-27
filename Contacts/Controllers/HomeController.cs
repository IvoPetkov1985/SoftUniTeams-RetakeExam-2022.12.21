using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Contacts.Data.Common.DataConstants;

namespace Contacts.Controllers
{
    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction(AllActionName, ContactsContrName);
            }

            return View();
        }
    }
}
