using CAppIglesia.Data.Repositorio;
using CAppIglesia.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAppIglesia.Models
{
    public class OfrendasRepository : Repository<Ofrendas>, IOfrendasRepository
    {

        private readonly ApplicationDbContext db;

        public OfrendasRepository( ApplicationDbContext context): base(context)
        {
            db=context;

        }

        public IEnumerable<SelectListItem> GetTOfrenda()
        {
            throw new NotImplementedException();
        }

       

        public void Update(Ofrendas ofrendas)
        {
            var OBJET = db.Ofrendas.FirstOrDefault(O => O.OfrendaID == ofrendas.OfrendaID);

            OBJET.Cantidad = ofrendas.Cantidad;
            OBJET.FechaOfrenda= ofrendas.FechaOfrenda;
        }
    }
}
