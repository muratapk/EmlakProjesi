using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entire
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
