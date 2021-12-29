using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace platzi_asp_net_core.Controllers
{
    
    public class AlumnoController: Controller
    {
         public IActionResult Index()
        {
            return View(new Alumno{Nombre="Pepe Perez",
                                    UniqueId = Guid.NewGuid().ToString()
                                });
        }
        public IActionResult MultiAlumno()
        {
          var listaAlumnos = GenerarAlumnosAlAzar();
          
            ViewBag.CosaDinamica="La monja";
            ViewBag.Fecha=DateTime.Now;
            return View("MultiAlumno",listaAlumnos);
        }
        private List<Alumno> GenerarAlumnosAlAzar()
        {
            string[] nombre1= {"Alba","Felipe","Juan","Jose"};
            string[] apellido1={"Ruiz","Sarmiento","Perez","Gomez"};
            string[] nombre2={"Freddy","Anabel","Rick","Murty"};

            var listaAlumnos=from n1 in nombre1
                             from n2 in nombre2
                             from a1 in apellido1
                             select new Alumno {Nombre=$"{n1} {n2} {a1}"};

            return listaAlumnos.OrderBy((al)=>al.UniqueId).ToList();
        }
    }
}