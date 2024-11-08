using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace CarPark.User.Controllers
{
    public class ContactController : Controller
    {
        private IStringLocalizer<SharedResource> _localizer;

        public ContactController(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }
        public IActionResult Index()
        {
            var welcome_value = _localizer["Welcome"];

            return View();
        }
    }
}
