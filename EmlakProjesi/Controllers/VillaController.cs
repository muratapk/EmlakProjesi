using DataAccessLayer.Data;
using EntityLayer.Entire;
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
            var sorgu = _db.Villas.ToList();
            return View(sorgu);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Villa entity )
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Villa entity)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Villa entity)
        {
            return View();
        }
    }
}
