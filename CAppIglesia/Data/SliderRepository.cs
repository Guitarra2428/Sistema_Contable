using CAppIglesia.Data.Repositorio;
using CAppIglesia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CAppIglesia.Data
{
   public class SliderRepository : Repository<Slider>, ISlidersRepository
    {
        private readonly ApplicationDbContext dbslider;

        public SliderRepository(ApplicationDbContext context) : base(context)
        {
           dbslider = context;
        }

        public void Update(Slider slider)
        {
            var objeto = dbslider.Sliders.FirstOrDefault(s=> s.Id==s.Id);

            objeto.Id = slider.Id;
            objeto.Nombre = slider.Nombre;
            objeto.UrlImagen = slider.UrlImagen;

            dbslider.SaveChanges();

        }
    }
}
