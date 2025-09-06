using Microsoft.AspNetCore.Mvc;

namespace MarketplaceSaaS.API.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
