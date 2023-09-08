using Microsoft.AspNetCore.Mvc;

namespace E_ComerceApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
