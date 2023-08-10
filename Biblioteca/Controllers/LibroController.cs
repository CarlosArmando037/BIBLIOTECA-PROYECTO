using Microsoft.AspNetCore.Mvc;
using libros.Datos;
using CLibro.Models;


namespace Biblioteca.Controllers
{
    public class LibroController : Controller
    {
        LibroDatos _libros = new LibroDatos();

        [HttpGet]
        public IActionResult añadir()
        {
            return View();
        }
       [HttpPost]
       public IActionResult añadir(LibroDatos model)
        {
            var respuesta = _libros.AñadirLibro(model);
            if (respuesta)
            {
                return RedirectToAction("añadir");
            }
            else
            {
                return View();
            }
        }
    }
}
