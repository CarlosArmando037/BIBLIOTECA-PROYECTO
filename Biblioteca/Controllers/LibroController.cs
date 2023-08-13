using Microsoft.AspNetCore.Mvc;
using libros.Datos;
using CLibro.Models;
using System.Reflection;


namespace Biblioteca.Controllers
{
    public class LibroController : Controller
    {
        LibroDatos _Libros = new LibroDatos();

        [HttpGet]
        public IActionResult ObtenerLi()
        {
            return View();
        }
        [HttpPost]
        public IActionResult obtenerLi()
        {
            var lista = _Libros.obtenerLi(LibroModel model);
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
            var respuesta= _Libros.editarLibros(model);
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
            var respuesta = _Libros.AñadirLibro(model);
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
