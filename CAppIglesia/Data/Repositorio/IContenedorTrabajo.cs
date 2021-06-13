using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAppIglesia.Data.Repositorio
{
    public interface IContenedorTrabajo : IDisposable
    {
        IRegistroRepository GetRegistro { get; }
        IOfrendasRepository GetOfrendas { get; }
        IServiciosRepository GetServicios { get; }
        ISlidersRepository GetSliders {get;}

        void Save();

    }
}
