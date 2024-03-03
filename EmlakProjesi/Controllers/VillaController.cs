using DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmlakProjesi.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VillaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
