using Microsoft.AspNetCore.Mvc;
using libros.Datos;
using Libro.Models;

namespace Libro.Controllers
{
    public class LibrosCrudController : Controller
    {
        LibroDatos _Libros = new LibroDatos();

        public IActionResult ObtenerLi(int IdLibro)
        {
            var ObLib = _Libros.obtenerLi(IdLibro);
            return View(ObLib);
        }


        /*
        [HttpGet]
        public IActionResult ObtenerLi()
        {
            return View();
        }
        [HttpPost]
        public IActionResult obtenerLi(LibroModel model)
        {
            var lista = _Libros.obtenerLi(model);
            if (lista)
            {
                return RedirectToAction("ObtenerLi");
            }
            else
            {
                return View();
            }
        }
       */
        
        [HttpGet]
        public IActionResult ModificarLi()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ModificarLi(LibroModel model)
        {
            var EditLibros = _Libros.editarLibros(model);
            if (EditLibros)
            {
                return RedirectToAction("ModificarLi");
            }
            else
            {
                return View();
            }
        }
       


        [HttpGet]
        public IActionResult AñadirLi()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AñadirLi(LibroModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool GuarLibro = _Libros.AñadirLibro(model);
            if (GuarLibro)
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
