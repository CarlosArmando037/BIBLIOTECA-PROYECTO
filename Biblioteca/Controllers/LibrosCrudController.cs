using Microsoft.AspNetCore.Mvc;
using libros.Datos;
using CrudLibro.Models;

namespace Libro.Controllers
{
    public class LibrosCrudController : Controller
    {
        LibroDatos _Libros = new LibroDatos();


        public IActionResult ObtenerLi()
        {
           
            var Obte = _Libros.ListaLi();
            return View(Obte);

        }



        public IActionResult Index()
        {

            var Obte = _Libros.ListaLi();
            return View(Obte);
        }
        /*
        [HttpPost]
        public IActionResult ObtenerLi(LibroModel model)
        {
            var  obtener = _Libros.obtenerLi();
            if (obtener != null)
            {
                return RedirectToAction("ObtenerLi");
            }
            else
            {
                return View();
            }
        }

        
        public IActionResult ObtenerLi(int IdLibro)
        {
            LibroModel lista = _Libros.obtenerLi();
            return View(lista);
        }
        

        
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
        /*MODIFICAR LIBROS-------------------------------------------------------*/

        public IActionResult ModificarLi(int IdLibro)
        {
            LibroModel _libros = _Libros.obtenerLi(IdLibro);
            return View(_libros);
        }
        [HttpPost]
        public IActionResult ModificarLi(LibroModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var EditLibros = _Libros.editarLibros(model);
            if (EditLibros)
            {
                return RedirectToAction("ObtenerLi");
            }
            else
            {
                return View();
            }
        }
       /*ELIMINAR LIBROS--------------------------------------------------------*/
        public IActionResult EliminarLi(int IdLibro)
        {
            LibroModel _libros = _Libros.obtenerLi(IdLibro);
            return View(_libros);
        }
        [HttpPost]
        public IActionResult EliminarLi(LibroModel model)
        {
            var elim = _Libros.eliminarLibro(model.IdLibro);
            if (elim)
            {
                return RedirectToAction("ObtenerLi");
            }
            else
            {
                return View();
            }
        }

        /*AÑADIR LIBROS-----------------------------------------------------*/
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
