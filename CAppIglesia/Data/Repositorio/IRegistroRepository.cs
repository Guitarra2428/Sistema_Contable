using CAppIglesia.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAppIglesia.Data.Repositorio
{
   public interface IRegistroRepository: IRepository<Registros> 
    {
        IEnumerable<SelectListItem> GetTRegistro();

        void Update(Registros registros);
    }
}
