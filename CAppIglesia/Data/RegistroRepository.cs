using CAppIglesia.Data.Repositorio;
using CAppIglesia.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAppIglesia.Models
{ 
    public class RegistroRepository : Repository<Registros>, IRegistroRepository
    {

        private readonly ApplicationDbContext db;

        public RegistroRepository( ApplicationDbContext context): base(context)
        {
            db=context;

        }

        public IEnumerable<SelectListItem> GetTRegistro()
        {
           return db.Registros.Select(i => new SelectListItem()
            {
                Text = i.PrimerNombre,
                Value = i.OfrendaID.ToString()
            }) ;

        }

        public void Update(Registros registros)
        {

            var objeto = db.Registros.FirstOrDefault(d => d.OfrendaID == d.OfrendaID);

            objeto.PrimerNombre = registros.PrimerNombre;
            objeto.PrimerApellido = registros.PrimerApellido;
            objeto.Concepto = registros.Concepto;
            objeto.Cantidad = registros.Cantidad;
            objeto.FechaDePago = registros.FechaDePago;



        }
    }
}
