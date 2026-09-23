using Microsoft.AspNetCore.Mvc;

namespace Quan_Ly_Nha_Tro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
