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
   
    public class OfrendasController : Controller
    {

        private readonly IContenedorTrabajo contenedorTrabajo;

        public OfrendasController(IContenedorTrabajo Trabajo)
        {
            contenedorTrabajo = Trabajo;
        }

        public IActionResult Index()
        {
            contenedorTrabajo.GetOfrendas.GetAll();
            return View(contenedorTrabajo.GetOfrendas.GetAll());
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Ofrendas  ofrendas)
        {
            if (ModelState.IsValid)
            {
                contenedorTrabajo.GetOfrendas.Add(ofrendas);
                contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }

            return View(ofrendas);
        }

        public IActionResult Editar(int id)
        {
            Ofrendas ofrendas = new Ofrendas();
            ofrendas = contenedorTrabajo.GetOfrendas.GetT(id);
            if (ofrendas == null)
            {
                return NotFound();
            }
           
            return View(ofrendas);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Ofrendas ofrendas)
        {
            if (ModelState.IsValid)
            {
               contenedorTrabajo.GetOfrendas.Update(ofrendas);
              contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(ofrendas);
        }
       


        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            var eliminar = contenedorTrabajo.GetOfrendas.GetT(id);
            if (eliminar == null)
            {
                return Json(new { success=false, message="Intento de borrado fallido"});
            }
            contenedorTrabajo.GetOfrendas.Remove(eliminar);
            contenedorTrabajo.Save();
            return Json(new { success = true, message = "Borrado Corecto" });

        }



        public IActionResult Getall()
         {
                 return Json(new { data = contenedorTrabajo.GetOfrendas.GetAll() });
          }

    }

}
