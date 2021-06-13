using CAppIglesia.Data;
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
    public class RegistrosController : Controller
    {

        private readonly IContenedorTrabajo db;
        public RegistrosController(IContenedorTrabajo context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var regis = db.GetRegistro.GetAll();
            
            return View(regis);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Registros registro)
        {
            if (ModelState.IsValid)
            {
               
                db.GetRegistro.Add(registro);
                db.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(registro);
        }

        public IActionResult Editar(int id)
        {
            Registros registros = new Registros();
           registros = db.GetRegistro.GetT(id);
            if (registros== null)
            {
                return NotFound();
            }
        
            return View(registros);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Registros registro)
        {
            if (ModelState.IsValid)
            {
                db.GetRegistro.Update(registro);
                db.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(registro);
        }

        
        [HttpGet]
        public IActionResult Getall()
        {
             return Json(new { data = db.GetRegistro.GetAll() });
        }
        [HttpDelete]       
        public IActionResult Eliminar(int id)
        {
            var eliminar = db.GetRegistro.GetT(id);
            if (eliminar == null)
            {
                return Json(new { success=false, message="borrado interumpido" });
            }

            db.GetRegistro.Remove(eliminar);
            db.Save();
            return Json(new { success = true, message = "borrado correcto" });

        }
       
    }
}
