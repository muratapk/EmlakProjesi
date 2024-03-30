using Microsoft.AspNetCore.Mvc;

namespace EmlakProjesi.Areas
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
