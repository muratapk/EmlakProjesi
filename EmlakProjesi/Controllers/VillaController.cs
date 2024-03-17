using DataAccessLayer.Abstract;
using DataAccessLayer.Data;
using EntityLayer.Entire;
using Microsoft.AspNetCore.Mvc;

namespace EmlakProjesi.Controllers
{
    public class VillaController : Controller
    {
        //private readonly IVillaRepository _villaRepo;
        private readonly IUnitofWork _unitofWork;
        private readonly IWebHostEnvironment _webHostEnviroment;
        //kayıt edilecek dosya yolunu belirtmek için kullanıyoruz.
        //public VillaController(IVillaRepository villaRepo)
        //{
        //    _villaRepo = villaRepo;
        //}
         public VillaController(IUnitofWork unitofWork, IWebHostEnvironment webHostEnviroment)
        {
            _unitofWork = unitofWork;
            _webHostEnviroment = webHostEnviroment;
        }
        public IActionResult Index()
        {
            // var sorgu = _db.Villas.ToList();
            var sorgu = _unitofWork.Villa.GetAll();
            return View(sorgu);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //resim dosyasını yüklerken bu yani post ile içeriye alacağız
        public IActionResult Create(Villa entity )
        {
            if(entity.ImagePath!=null)
            {
                //model içerisinde imageurl boş değilse bu kısımında işlem yap
                string filename = Guid.NewGuid().ToString();
                //16 basamaklı benzersiz bir isim dosyası oluşturuyor..
                string uzanti = Path.GetExtension(entity.ImagePath.FileName);
                //gelen dosyayının uzantısı alıyorum geni yeni.jpg ise .jpg kısmını al
                string yeni_isim = filename + uzanti;
                string kayityeri = Path.Combine(_webHostEnviroment.WebRootPath, @"Room_Images\");
                using (var filestream = new FileStream(Path.Combine(kayityeri, yeni_isim), FileMode.Create))
                {
                    entity.ImagePath.CopyTo(filestream);
                    entity.ImageUrl = @"\Room_Images\" + yeni_isim;
                    //veritabanına belirtilen yol ve dosya ismine göre kayıt eklemesi ImageUrl değer atıyoruz
                }

            }
            else
            {
                //model içindeki imageurl boş ise bu kısımda işlem yap
                entity.ImageUrl = "/Room_Images/resim-yok.png";
            }
            //_db.Villas.Add(entity);
            _unitofWork.Villa.Add(entity);
            //_db.SaveChanges();
            _unitofWork.Villa.Save();
            TempData["Success"] = "İşlem Başarılı";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var liste = _db.Villas.Find(id);
            var liste= _unitofWork.Villa.Get(x=>x.Id==id);
            return View(liste);
        }
        [HttpPost]
        public IActionResult Edit(Villa entity)
        {
            // _db.Villas.Update(entity);
            _unitofWork.Villa.Update(entity);
            //_db.SaveChanges();
            _unitofWork.Villa.Save();
            TempData["Success"] = "Kayıt Düzeldi";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //var liste = _db.Villas.Find(id);
            var liste = _unitofWork.Villa.Get(x => x.Id == id);
            return View(liste);
        }
        [HttpPost]
        public IActionResult Delete(Villa entity)
        {
            //_db.Villas.Remove(entity);
            _unitofWork.Villa.Delete(entity);
            //_db.SaveChanges();
            _unitofWork.Villa.Save();
            TempData["Success"] = "Kayıt Silindi";
            return RedirectToAction("Index");
        }
    }
}
