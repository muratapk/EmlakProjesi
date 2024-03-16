using DataAccessLayer.Abstract;
using EntityLayer.Entire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmlakProjesi.Controllers
{
    public class MusteriController : Controller
    {
        private readonly IMusteriRepository _musteriRepository;

        public MusteriController(IMusteriRepository musteriRepository)
        {
            _musteriRepository = musteriRepository;
        }

        // GET: MusteriController
        public ActionResult Index()
        {
            var sorgu = _musteriRepository.GetAll();
            return View(sorgu);
        }

        // GET: MusteriController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MusteriController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusteriController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Musteri entity)
        {
            try
            {
                _musteriRepository.Add(entity);
                _musteriRepository.Save();
                TempData["Success"] = "Ekleme İşlemi Başarılı";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MusteriController/Edit/5
        public ActionResult Edit(int id)
        {
           var sorgu= _musteriRepository.Get(x => x.MusteriId == id);
            return View(sorgu);
        }

        // POST: MusteriController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Musteri entity)
        {
            try
            {
                _musteriRepository.Update(entity);
                _musteriRepository.Save();
                TempData["Success"] = "Güncelleme İşlemi Başarılı";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MusteriController/Delete/5
        public ActionResult Delete(int id)
        {
            var sorgu = _musteriRepository.Get(x => x.MusteriId == id);
            return View(sorgu);
            //silinecek kaydı ekrana getirmesi için bunu yazıyoruz
        }

        // POST: MusteriController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Musteri entity)
        {
            try
            {
                _musteriRepository.Delete(entity);
                _musteriRepository.Save();
                TempData["Success"] = "Silme İşlemi Başarılı";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
