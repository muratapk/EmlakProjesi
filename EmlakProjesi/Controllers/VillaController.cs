using DataAccessLayer.Abstract;
using DataAccessLayer.Data;
using EntityLayer.Entire;
using Microsoft.AspNetCore.Mvc;

namespace EmlakProjesi.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaRepository _villaRepo;

        public VillaController(IVillaRepository villaRepo)
        {
            _villaRepo = villaRepo;
        }

        public IActionResult Index()
        {
            // var sorgu = _db.Villas.ToList();
            var sorgu = _villaRepo.GetAll();
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
            //_db.Villas.Add(entity);
            _villaRepo.Add(entity);
            //_db.SaveChanges();
            _villaRepo.Save();
            TempData["Success"] = "İşlem Başarılı";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var liste = _db.Villas.Find(id);
            var liste=_villaRepo.Get(x=>x.Id==id);
            return View(liste);
        }
        [HttpPost]
        public IActionResult Edit(Villa entity)
        {
            // _db.Villas.Update(entity);
            _villaRepo.Update(entity);
            //_db.SaveChanges();
            _villaRepo.Save();
            TempData["Success"] = "Kayıt Düzeldi";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //var liste = _db.Villas.Find(id);
            var liste = _villaRepo.Get(x => x.Id == id);
            return View(liste);
        }
        [HttpPost]
        public IActionResult Delete(Villa entity)
        {
            //_db.Villas.Remove(entity);
            _villaRepo.Delete(entity);
            //_db.SaveChanges();
            _villaRepo.Save();
            TempData["Success"] = "Kayıt Silindi";
            return RedirectToAction("Index");
        }
    }
}
