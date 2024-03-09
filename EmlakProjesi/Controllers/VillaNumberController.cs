using DataAccessLayer.Data;
using EntityLayer.Entire;
using Microsoft.AspNetCore.Mvc;

namespace EmlakProjesi.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VillaNumberController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var sorgu = _db.VillaNumbers.ToList();
            return View(sorgu);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(VillaNumber entity )
        {
            _db.VillaNumbers.Add(entity);
            _db.SaveChanges();
            TempData["Success"] = "İşlem Başarılı";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var liste = _db.VillaNumbers.Find(id);
            return View(liste);
        }
        [HttpPost]
        public IActionResult Edit(VillaNumber entity)
        {
            _db.VillaNumbers.Update(entity);
            _db.SaveChanges();
            TempData["Success"] = "Kayıt Düzeldi";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var liste = _db.VillaNumbers.Find(id);
            return View(liste);
        }
        [HttpPost]
        public IActionResult Delete(VillaNumber entity)
        {
            _db.VillaNumbers.Remove(entity);
            _db.SaveChanges();
            TempData["Success"] = "Kayıt Silindi";
            return RedirectToAction("Index");
        }
    }
}
