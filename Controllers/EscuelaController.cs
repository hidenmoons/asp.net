using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;
using System;
using System.Linq;
namespace platzi_asp_net_core.Controllers
{
    public class EscuelaController: Controller
    {
        
        public IActionResult Index()
        {
         
            ViewBag.CosaDinamica = "La Monja locoshona";
           var escuela = _context.Escuelas.FirstOrDefault();
            return View(escuela);
        }
    private EscuelaConexto _context;
    public EscuelaController(EscuelaConexto context)
    {
        _context=context;
    }
    }
}