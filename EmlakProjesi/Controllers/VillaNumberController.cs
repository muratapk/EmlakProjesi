using DataAccessLayer.Data;
using EntityLayer.Entire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            //GetAll()
            return View(sorgu);
        }
        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> villam = _db.Villas.ToList().Select(u => new SelectListItem{
               Text=u.Name,
               Value=u.Name.ToString()
            
               });
            ViewData["Villam"]= villam;
            return View();
        }
        [HttpPost]
        public IActionResult Create(VillaNumber entity )
        {
            //form içindeki verileri kontrol etmek için kullanıyoruz
            if(ModelState.IsValid)
            {

                _db.VillaNumbers.Add(entity);
                //Void Add()
                _db.SaveChanges();
                TempData["Success"] = "İşlem Başarılı";
                return RedirectToAction("Index");
            }

            //Eğer veriler boş ise tekrar seçim kutusunu doldurmak yeniden viewdata kullanarak aynı ekrana verileri gönderiyorum.
            IEnumerable<SelectListItem> villam = _db.Villas.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Name.ToString()

            });
            ViewData["Villam"] = villam;

            return View();
           
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
            //void Update()
            _db.SaveChanges();
            TempData["Success"] = "Kayıt Düzeldi";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var liste = _db.VillaNumbers.Find(id);
            //Get(id) interface kullandığım get methodu
            return View(liste);
        }
        [HttpPost]
        public IActionResult Delete(VillaNumber entity)
        {
            _db.VillaNumbers.Remove(entity);
            //void Delete()
            _db.SaveChanges();
            //void Save()
            TempData["Success"] = "Kayıt Silindi";
            return RedirectToAction("Index");
        }
    }
}
