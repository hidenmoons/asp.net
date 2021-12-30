using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace platzi_asp_net_core.Controllers
{

    public class AlumnoController : Controller
    {
        public IActionResult Index()
        {
            return View(_context.Alumnos.FirstOrDefault());
        }
        public IActionResult MultiAlumno()
        {

            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;
            return View("MultiAlumno", _context.Alumnos);
        }
        private List<Alumno> GenerarAlumnosAlAzar()
        {
            string[] nombre1 = { "Alba", "Felipe", "Juan", "Jose" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Perez", "Gomez" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno
                               {
                                   Nombre = $"{n1} {n2} {a1}",
                                   Id = Guid.NewGuid().ToString()
                               };

            return listaAlumnos.OrderBy((al) => al.Id).ToList();
        }
        private EscuelaConexto _context;
        public AlumnoController(EscuelaConexto context)
        {
            _context = context;
        }
    }
}