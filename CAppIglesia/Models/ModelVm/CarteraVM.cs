using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAppIglesia.Models.ModelVm
{
   public class CarteraVM
    {

       public  IEnumerable<Ofrendas> Ofrendas { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }

        public IEnumerable< PagoDeServicios> PagoDeServicios { get; set; }
        public IEnumerable<Registros>Registros { get; set; }

    }
}
