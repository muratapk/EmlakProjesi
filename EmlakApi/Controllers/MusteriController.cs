using EmlakApi.Data;
using EmlakApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmlakApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusteriController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MusteriController(ApplicationDbContext context)
        {
            _context = context;
        }
        //tüm verileri çekmek için kullanıyoruz
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musteri>>> GetMusteri()
        {
            //tüm verileri getirmesini için bu methodu 
            return await _context.Musteris.ToListAsync();
            //async kullandığınızda mutlaka tolistAsync kullanmak zorundasınız
        }

        //tek veri çekmek için kullanıyorum
        [HttpGet("id")]
        public async Task<ActionResult<Musteri>> GetMusteri(int id)
        {
            //tek bir veri çekmek için kullandığımız method
            return await _context.Musteris.Where(x => x.MusteriId == id).FirstOrDefaultAsync();
            //task methodu yazıldığında mutlaka sorgu içerisinde await kullanmak zorundayız.   
                
        }
        [HttpDelete("id")]
        public async Task<ActionResult<Musteri>>DeleteMusteri(int id)
        {
            var result = await _context.Musteris.Where(x => x.MusteriId == id).FirstOrDefaultAsync();
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
                //method fonksiyon içinde async kullanıldığında mutlaka await kullanıyoruz
            }
            return result;
        }
        //güncelleme
        [HttpPut]
        public async Task<ActionResult<Musteri>>UpdateMusteri(Musteri musteri,int id)
        {
            var result = await _context.Musteris.Where(x => x.MusteriId == id).FirstOrDefaultAsync();
            if(result != null)
            {
                result.MusteriAd = musteri.MusteriAd;
                result.Email = musteri.Email;
                result.Password = musteri.Password;
                await _context.SaveChangesAsync();

            }
            return result;
        }

        //dört method get verileri listelemek için tek bir veri olabilir tüm veriler
        //method post kaydet kullanılan yeni  bir method
        //delete buda veri silmek sillmak
        //put verileri güncellemek için kullanıyoruz
        //yeni verileri kaydetmek için kullanıyoruz
        [HttpPost]
        public async Task<ActionResult> PostMusteri(Musteri musteri)
        {
            _context.Musteris.Add(musteri);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
