using EntityLayer.Entire;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress+"/Musteri/Get").Result;

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
            try
            {
                string data = JsonConvert.SerializeObject(musteri);
                //gelen verileri serializeobject Jsonformatına dönüştürüyorum
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/api/Musteri/Post", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex;
                return View();
            }


           
            return View();
        }
        public IActionResult Delete(int id)
        {
            try
            {
                Musteri musteri = new Musteri();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Api/Musteri/Get" + id).Result;
                //id numarasına göre verileri çek getir
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    musteri = JsonConvert.DeserializeObject<Musteri>(data);
                    return View(musteri);
                }

            }
            catch (Exception ex)
            {
                TempData["errorMesssage"] = ex.Message;
                return View();
            }
           
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Musteri musteri,int id)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Api/Musteri/Delete" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Kayıt Silindi";
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }


            

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Musteri musteri = new Musteri();
            //boş bir musteri satırı oluşturdu
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/api/Musteri/Get" + id).Result;
            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                //responso içindeki verileri string olarak oku data  string türüne çeviriyor
                //json gelen verileri okumam lazım bunun içinde 
                musteri=JsonConvert.DeserializeObject<Musteri>(data);
            }
            return View(musteri);
        }
        [HttpPost]
        public IActionResult Edit(Musteri musteri, int id)
        {
            try
            {
                string data = JsonConvert.SerializeObject(musteri);
                //form ile gelen verileri json formatında dönüştürüyoruz.
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Api/Musteri/Put", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "İşlem Başarılı";
                    return RedirectToAction("Index");
                }


            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }


           
            return View();
        }


    }
}
