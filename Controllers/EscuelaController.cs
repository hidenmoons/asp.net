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
            escuela.AñoDeCreación=2005;
            escuela.UniqueId = Guid.NewGuid().ToString();
            escuela.Nombre ="Platzi School";
            escuela.Ciudad="Gdl";
            escuela.Pais="Mex";
            escuela.Dirección = "San carlos";
            escuela.TipoEscuela= TiposEscuela.Secundaria;
            ViewBag.CosaDinamica = "La Monja locoshona";

            return View(escuela);
        }
    }
}