using Microsoft.AspNetCore.Mvc;

namespace EmlakProjesi.Areas.Home
{
    public class EfeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
