using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entire
{
    public class VillaNumber
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Required(ErrorMessage ="Bu Alanı Boş Bırakmazsınız")]
        public int Villa_Number{get;set;}

        [ForeignKey("Villa")]
        [Required(ErrorMessage = "Bu Alanı Boş Bırakmazsınız")]
        public int VillaId { get; set; }
       
        virtual public Villa? Villa { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Bırakmazsınız")]
        public string SpecialDetails { get; set; } = string.Empty;
    }
}
