using CAppIglesia.Data.Repositorio;
using CAppIglesia.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAppIglesia.Models
{
    public class ServiciosRepository : Repository<PagoDeServicios>, IServiciosRepository
    {

        private readonly ApplicationDbContext db;

        public ServiciosRepository( ApplicationDbContext context): base(context)
        {
            db=context;

        }

        public IEnumerable<SelectListItem> GetTServicios()
        {
            throw new NotImplementedException();
        }

        public void Update(PagoDeServicios pagoDeServicios)
        {
           var OBJET = db.pagoDeServicios.FirstOrDefault(O => O.PagoDeServicioID == pagoDeServicios.PagoDeServicioID);

            OBJET.NombreServicio = pagoDeServicios.NombreServicio;
            OBJET.Cantidad = pagoDeServicios.Cantidad;
            OBJET.FechaDePago = pagoDeServicios.FechaDePago;
        }
    }
}
