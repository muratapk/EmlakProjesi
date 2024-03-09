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
        public int Villa_Number{get;set;}

        [ForeignKey("Villa")]
        public int VillaId { get; set; }
        virtual public Villa? Villa { get; set; }
        public string SpecialDetails { get; set; } = string.Empty;
    }
}
