using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmlakProjesi.Controllers
{
    public class MusteriController : Controller
    {
        //private readonly IMusteriRepository _musteriRepository;
        //bu yerine oluşturduğumuz unitofwork yapısını buraya çağırıyoruz
        private readonly IUnitofWork _unit;

        //public MusteriController(IMusteriRepository musteriRepository)
        //{
        //    _musteriRepository = musteriRepository;
        //}

        public MusteriController(IUnitofWork unit)
        {
            _unit = unit;
        }
        // GET: MusteriController
        public ActionResult Index()
        {
            var sorgu = _unit.Musteri.GetAll();
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
                _unit.Musteri.Add(entity);
                _unit.Musteri.Save();
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
           var sorgu= _unit.Musteri.Get(x => x.MusteriId == id);
            return View(sorgu);
        }

        // POST: MusteriController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Musteri entity)
        {
            try
            {
                _unit.Musteri.Update(entity);
                _unit.Musteri.Save();
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
            var sorgu = _unit.Musteri.Get(x => x.MusteriId == id);
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
                _unit.Musteri.Delete(entity);
                _unit.Musteri.Save();
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
