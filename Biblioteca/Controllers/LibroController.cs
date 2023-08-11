using Microsoft.AspNetCore.Mvc;
using libros.Datos;
using CLibro.Models;


namespace Biblioteca.Controllers
{
    public class LibroController : Controller
    {
        LibroDatos _contactoLibros = new LibroDatos();

        public IActionResult consultaLi()
        {
            var lista = _contactoLibros.consultaLi();
            return View(lista);
        }

        

        [HttpGet]
        public IActionResult ModificarLi()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ModificarLi(LibroModel model)
        {
            var respuesta=_contactoLibros.editarLibros(model);
            if (respuesta)
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
