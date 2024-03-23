using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUnitofWork
    {
        IVillaNumber VillaNumber { get; }
        IVillaRepository Villa { get; }
        IMusteriRepository Musteri { get; }
    }
}
