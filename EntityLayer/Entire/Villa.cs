using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entire
{
    public class Villa
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int? Occupancy { get; set; }
        //doluluk durumu
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set;}
        [NotMapped]
        public IFormFile? ImagePath { get; set; }
    }
}
