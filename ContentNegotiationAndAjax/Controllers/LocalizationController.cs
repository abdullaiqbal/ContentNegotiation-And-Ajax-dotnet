using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ContentNegotiationAndAjax.Controllers
{
    public class LocalizationController : Controller
    {
        private readonly IStringLocalizer<LocalizationController> _localizer;
        public LocalizationController(IStringLocalizer<LocalizationController> localizer)
        {
            _localizer = localizer;
        }
        public IActionResult Index()
        {
            return View();
        }


        //[HttpGet]
        //public string GetData()
        //{
        //    return _localizer["About"];
        //}

    }
}
