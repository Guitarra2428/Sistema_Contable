using CAppIglesia.Data.Repositorio;
using CAppIglesia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAppIglesia.Models
{
    public class ServiciosController : Controller
    {

        private readonly IContenedorTrabajo contenedorTrabajo;

        public ServiciosController(IContenedorTrabajo Trabajo)
        {
            contenedorTrabajo = Trabajo;
        }

        public IActionResult Index()
        {
            return View(contenedorTrabajo.GetServicios.GetAll());
        }

        public IActionResult Create()
        {
          

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(PagoDeServicios pagoDeServicios )
        {
            if (ModelState.IsValid)
            {
                contenedorTrabajo.GetServicios.Add(pagoDeServicios);
                contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }

            return View(pagoDeServicios);
        }

        public IActionResult Editar(int id)
        {
            PagoDeServicios pagoDeServicios = new PagoDeServicios();
            pagoDeServicios = contenedorTrabajo.GetServicios.GetT(id);
            if (pagoDeServicios == null)
            {
                return NotFound();
            }
           
            return View(pagoDeServicios);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(PagoDeServicios pagoDeServicios)
        {
            if (ModelState.IsValid)
            {
                contenedorTrabajo.GetServicios.Update(pagoDeServicios);
                contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(pagoDeServicios);
        }

     

         [HttpGet]
         public IActionResult GetAll()
         {
              return Json(new { data = contenedorTrabajo.GetServicios.GetAll() });
         }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            var eliminar = contenedorTrabajo.GetServicios.GetT(id);
            if (eliminar == null)
            {
                return Json(new { success = false, message = "Borrado erroneo" });
            }

            contenedorTrabajo.GetServicios.Remove(eliminar);
            contenedorTrabajo.Save();
            return Json(new {success=true, message="Borrado correcto" });

        }
     
       
    }
}
