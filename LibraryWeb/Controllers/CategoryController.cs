using Microsoft.AspNetCore.Mvc;

namespace LibraryWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
