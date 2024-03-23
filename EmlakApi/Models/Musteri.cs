using System.ComponentModel.DataAnnotations;

namespace EmlakApi.Models
{
    public class Musteri
    {
        [Key]
        public int MusteriId { get; set; }
        public string MusteriAd { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
