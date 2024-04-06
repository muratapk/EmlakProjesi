using EntityLayer.Entire;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmlakProjesi.Controllers
{
    public class MusteriApiController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7019/api/");
        private readonly HttpClient _client;

        public MusteriApiController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Musteri> musteriler = new List<Musteri>();
            //size boş bir musteri listesi nesnesi 
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress+"/Musteri/").Result;

            if(response.IsSuccessStatusCode)
            {
                string data= response.Content.ReadAsStringAsync().Result;
                //gelen datayı api ile gelen içeriği al
                musteriler=JsonConvert.DeserializeObject<List<Musteri>>(data);
                //aldığım içeriği JsonConvert.Deserialize oku Musteri Listesi oku
            }
            return View(musteriler);
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
