using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace platzi_asp_net_core.Controllers
{

    public class CursoController : Controller
    {

        public IActionResult Index(String id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var cursos = from curso in _context.Cursos
                             where curso.Id == id
                             select curso;
                return View(cursos.SingleOrDefault());
            }
            else
            {

                return View("MultiCurso", _context.Cursos);
            }
        }
        public IActionResult MultiCurso()
        {

            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;
            return View("MultiCurso", _context.Cursos);
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
        public CursoController(EscuelaConexto context)
        {
            _context = context;
        }
    }
}