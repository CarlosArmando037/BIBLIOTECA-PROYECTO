using Microsoft.AspNetCore.Mvc;
using libros.Datos;
using CLibro.Models;



namespace Libro.Controllers
{
    public class LibroController : Controller
    {
        LibroDatos _Libros = new LibroDatos();

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
        public IActionResult ObtenerLi(int id)
        {
            var Obtlibro = _Libros.obtenerLi(id);

            if (Obtlibro == null)
            {
                return NotFound(); // Puedes manejar la situación si no se encuentra el libro
            }

            return View(Obtlibro);
        }



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
            var GuarLibro = _Libros.AñadirLibro(model);
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
