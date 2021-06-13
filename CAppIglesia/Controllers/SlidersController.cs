using CAppIglesia.Data.Repositorio;
using CAppIglesia.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CAppIglesia.Controllers
{
    public class SlidersController : Controller
    {
        private readonly IContenedorTrabajo contenedorTrabajo;
        private readonly IWebHostEnvironment webhostEnviroment;

        public SlidersController(IContenedorTrabajo contenedor, IWebHostEnvironment hostEnvironment)
        {
            contenedorTrabajo = contenedor;
            webhostEnviroment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Slider slider)
        {

            if (ModelState.IsValid)
            {

                var rutstsprincipal = webhostEnviroment.WebRootPath;
                var archivo = HttpContext.Request.Form.Files;


                string Nombrearchivo = Guid.NewGuid().ToString();
                var subida = Path.Combine(rutstsprincipal, @"imagenes\sliders");
                var esxtension = Path.GetExtension(archivo[0].FileName);


                using (var filleStreams = new FileStream(Path.Combine(subida, Nombrearchivo + esxtension), FileMode.Create))
                {
                    archivo[0].CopyTo(filleStreams);
                }

                slider.UrlImagen = @"\imagenes\sliders\" + Nombrearchivo + esxtension;

                contenedorTrabajo.GetSliders.Add(slider);
                contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));

            }
            return View();
        }

        public IActionResult Edit(int? id)
        {

            if (id != null)
            {
                var slider = contenedorTrabajo.GetSliders.GetT(id.GetValueOrDefault());
                return View(slider);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Slider slider)
        {

            if (ModelState.IsValid)
            {
                // var datos = contenedorTrabajo.slider.GetT(id);

                var rutstsprincipal = webhostEnviroment.WebRootPath;
                var archivo = HttpContext.Request.Form.Files;
                var sliderdesdedb = contenedorTrabajo.GetSliders.GetT(slider.Id);

                if (archivo.Count() > 0)
                {
                    var Nombrearchivo = Guid.NewGuid().ToString();
                    var subida = Path.Combine(rutstsprincipal, @"imagenes\sliders");
                    var esxtension = Path.GetExtension(archivo[0].FileName);
                    var Nuevaextesion = Path.GetExtension(archivo[0].FileName);

                    var rutaimagen = Path.Combine(Nuevaextesion, sliderdesdedb.UrlImagen.TrimStart('\\'));

                    if (System.IO.File.Exists(rutaimagen))
                    {
                        System.IO.File.Delete(rutaimagen);
                    }

                    using (var filleStreams = new FileStream(Path.Combine(subida, Nombrearchivo + esxtension), FileMode.Create))
                    {
                        archivo[0].CopyTo(filleStreams);
                    }

                    slider.UrlImagen = @"\imagenes\sliders\" + Nombrearchivo + esxtension;

                    contenedorTrabajo.GetSliders.Update(slider);
                    contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));

                }

                else
                {
                    slider.UrlImagen = sliderdesdedb.UrlImagen;
                }

                contenedorTrabajo.GetSliders.Update(slider);
                contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            var eliminar = contenedorTrabajo.GetSliders.GetT(id);
            if (eliminar == null)
            {
                return Json(new { success = false, messages = "Error al borrar" });
            }

            contenedorTrabajo.GetSliders.Remove(eliminar);
            contenedorTrabajo.Save();
            return Json(new { success = true, messages = " borrado correcto" });

        }


        #region

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = contenedorTrabajo.GetSliders.GetAll() });
        }
        #endregion
    }
}

