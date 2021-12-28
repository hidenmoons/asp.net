using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;
using System;
namespace platzi_asp_net_core.Controllers
{
    public class EscuelaController: Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela();
            escuela.AñoFunddacion=2005;
            escuela.EscuelaId = Guid.NewGuid().ToString();
            escuela.Nombre ="Platzi School";

            ViewBag.CosaDinamica = "La Monja locoshona";

            return View(escuela);
        }
    }
}