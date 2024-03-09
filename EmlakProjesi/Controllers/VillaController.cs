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
            _db.Villas.Add(entity);
            _db.SaveChanges();
            TempData["Success"] = "İşlem Başarılı";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var liste = _db.Villas.Find(id);
            return View(liste);
        }
        [HttpPost]
        public IActionResult Edit(Villa entity)
        {
            _db.Villas.Update(entity);
            _db.SaveChanges();
            TempData["Success"] = "Kayıt Düzeldi";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var liste = _db.Villas.Find(id);
            return View(liste);
        }
        [HttpPost]
        public IActionResult Delete(Villa entity)
        {
            _db.Villas.Remove(entity);
            _db.SaveChanges();
            TempData["Success"] = "Kayıt Silindi";
            return RedirectToAction("Index");
        }
    }
}
