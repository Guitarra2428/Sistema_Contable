using CAppIglesia.Data.Repositorio;
using CAppIglesia.Models;
using CAppIglesia.Models.ModelVm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CAppIglesia.Models
{
    public class HomeController : Controller
    {
        private readonly IContenedorTrabajo _contedorTrabajo;

        public HomeController(IContenedorTrabajo contedorTrabajo)
        {
           _contedorTrabajo = contedorTrabajo;
        }

        public IActionResult Index()
        {
            CarteraVM carteraVM = new CarteraVM()
            {
                Sliders = _contedorTrabajo.GetSliders.GetAll()
            };
            return View(carteraVM);
        }

     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
