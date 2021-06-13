using CAppIglesia.Data.Repositorio;
using CAppIglesia.Models;
using CAppIglesia.Models.ModelVm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAppIglesia.Models
{
    public class DesemborsosController : Controller
    {
        private readonly IContenedorTrabajo contenedorTrabajo;
        private readonly ApplicationDbContext applicationDb;

        public DesemborsosController(IContenedorTrabajo Trabajo, ApplicationDbContext context)
        {
            contenedorTrabajo = Trabajo;
            applicationDb = context;
        }

        public IActionResult Index()
        {
            var CANTIDAD = applicationDb.Registros.Sum(c => c.Cantidad);
            ViewBag.cantidad = CANTIDAD;

            var CANTIDADOfrenda = applicationDb.Ofrendas.Sum(c => c.Cantidad); 
            ViewBag.cantidadofrenda=CANTIDADOfrenda;

            var CANTIDADServicios = applicationDb.pagoDeServicios.Sum(c => c.Cantidad);
            ViewBag.cantidasERVICIOS = CANTIDADServicios;

            int total = 0;
            total = CANTIDAD + CANTIDADOfrenda;
            int total1 = 0;
            total1 = total-CANTIDADServicios;

            ViewBag.totalRecolectaos = total;

            ViewBag.totalgeneral = total1;

            ViewBag.Gastototal = CANTIDADServicios;

            CarteraVM carteraVM = new CarteraVM()
            {
                Ofrendas = contenedorTrabajo.GetOfrendas.GetAll(),                
                Registros = contenedorTrabajo.GetRegistro.GetAll(),
                PagoDeServicios = contenedorTrabajo.GetServicios.GetAll()

            };
            return View(carteraVM );

        }

        [HttpGet]
        public IActionResult GetAll()
        {
           // var CANTIDAD = applicationDb.Registros.FromSqlRaw<Registros>("RegistroCantidad ").OrderBy(c => c.Cantidad);
           //var CANTIDAD = applicationDb.Registros.FromSqlRaw("SELECT sum(Cantidad) FROM Registros ").OrderBy(c => c.Cantidad);

             //var CANTIDAD = applicationDb.Registros.FromSqlRaw("SELECT OfrendaID,Cantidad, sum(Cantidad) FROM Registros GROUP BY OfrendaID, Cantidad").Count();
            // ViewBag.RegistroCantidad = CantidadRegistro;

            var CANTIDAD = applicationDb.Registros.Sum(c => c.Cantidad);
            
            return Json(new { data= CANTIDAD } );

        }

       // public async Task<int> GetCountSomeProp() => await applicationDb.SumAsync(c => c.Cantidad);
    }}
