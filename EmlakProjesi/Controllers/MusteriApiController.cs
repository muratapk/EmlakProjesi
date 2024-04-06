using EntityLayer.Entire;
using Microsoft.AspNetCore.Mvc;

namespace EmlakProjesi.Controllers
{
    public class MusteriApiController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7019/api");
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Musteri musteri)
        {
            return View();
        }
        public IActionResult Delete(int id)
        {

            return View();
        }
        [HttpPost]
        public IActionResult Delete(Musteri musteri,int id)
        {

            return View();
        }
        public IActionResult Update(int id)
        {

            return View();
        }
        [HttpPost]
        public IActionResult Update(Musteri musteri, int id)
        {

            return View();
        }


    }
}
