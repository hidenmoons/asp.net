using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace platzi_asp_net_core.Controllers
{

    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            return View(_context.Asignaturas.FirstOrDefault());
        }
        public IActionResult MultiAsignatura()
        {
            


            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;
            return View("MultiAsignatura", _context.Asignaturas);
        }
        private EscuelaConexto _context;
        public AsignaturaController(EscuelaConexto context)
        {
            _context = context;
        }
    }
}