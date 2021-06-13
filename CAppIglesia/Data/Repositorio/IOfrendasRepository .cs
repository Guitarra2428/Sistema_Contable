using CAppIglesia.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAppIglesia.Data.Repositorio
{
   public interface IOfrendasRepository: IRepository<Ofrendas> 
    {
        IEnumerable<SelectListItem> GetTOfrenda();

        void Update(Ofrendas ofrendas);
    }
}
