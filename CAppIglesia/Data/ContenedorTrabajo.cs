
using CAppIglesia.Data;
using CAppIglesia.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAppIglesia.Models
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext dcontext;
        public ContenedorTrabajo(ApplicationDbContext context)
        {
            dcontext = context;
            GetRegistro = new RegistroRepository(dcontext);
            GetOfrendas = new OfrendasRepository(dcontext);
            GetServicios = new ServiciosRepository(dcontext);
            GetSliders = new SliderRepository(dcontext);
        }

        public IRegistroRepository GetRegistro { get; private set; }
        public IOfrendasRepository GetOfrendas { get; private set; }

        public IServiciosRepository GetServicios { get; private set; }

        public ISlidersRepository GetSliders { get; private set; }

        public void Dispose()
        {
            dcontext.Dispose();
        }

        public void Save()
        {
            dcontext.SaveChanges();
        }
    }
}
