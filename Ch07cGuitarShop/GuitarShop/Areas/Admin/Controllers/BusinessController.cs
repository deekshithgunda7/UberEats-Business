using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BusinessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}