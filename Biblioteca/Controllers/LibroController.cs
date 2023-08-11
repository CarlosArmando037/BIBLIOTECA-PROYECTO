using Microsoft.AspNetCore.Mvc;
using libros.Datos;
using CLibro.Models;


namespace Biblioteca.Controllers
{
    public class LibroController : Controller
    {
        LibroDatos _contactoLibros = new LibroDatos();


        [HttpGet]
        public IActionResult AñadirLi()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AñadirLi(LibroModel model)
        {
            var respuesta = _contactoLibros.AñadirLibro(model);
            if (respuesta)
            {
                return RedirectToAction("añadirLi");
            }
            else
            {
                return View();
            }
        }
    }
}
