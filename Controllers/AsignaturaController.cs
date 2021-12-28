using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;
using System;
using System.Collections.Generic;
namespace platzi_asp_net_core.Controllers
{
    
    public class AsignaturaController: Controller
    {
         public IActionResult Index()
        {
            return View(new Asignatura{Nombre="Programacion",
                                    UniqueId = Guid.NewGuid().ToString()
                                });
        }
        public IActionResult MultiAsignatura()
        {
          var listaAsignaturas = new List<Asignatura>(){
                                new Asignatura{Nombre = "Matematicas",
                                    UniqueId = Guid.NewGuid().ToString()

                                },
                                new Asignatura{Nombre="Eduacacion fisica",
                                    UniqueId = Guid.NewGuid().ToString()
                                },
                                new Asignatura{Nombre="Español",
                                    UniqueId = Guid.NewGuid().ToString()
                                },
                                new Asignatura{Nombre="Programacion",
                                    UniqueId = Guid.NewGuid().ToString()
                                }

          };

          
            ViewBag.CosaDinamica="La monja";
            ViewBag.Fecha=DateTime.Now;
            return View("MultiAsignatura",listaAsignaturas);
        }
    }
}