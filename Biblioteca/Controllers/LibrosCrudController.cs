using Microsoft.AspNetCore.Mvc;
using libros.Datos;
using CrudLibro.Models;
using System.Reflection;

namespace Libro.Controllers
{
    public class LibrosCrudController : Controller
    {
        LibroDatos _Libros = new LibroDatos();

        /*------------------------LISTAR LIBRO------------------------------------------------------*/
        public IActionResult ListarLi()
        {
           
            var Obte = _Libros.ListaLi();
            return View(Obte);

        }
        public IActionResult Index()
        {

            var Obte = _Libros.ListaLi();
            return View(Obte);

        }


        /*-----------------------CONSULTA LIBRO-------------------------------------------------------*/

        /*
         public IActionResult ObtenerLi(int IdLibro)
         {

             var Obte = _Libros.obtenerLi(IdLibro);
             return View(Obte);
             if(!ModelState.IsValid)
             {
                return View(Obte);
             }
            else
            {
                return View();
            }
         }
        */


        public IActionResult ConsultaLi(int IdLibro)
        {

            var Obte = _Libros.obtenerLi(IdLibro);
            return View(Obte);
        }
        

        /*MODIFICAR LIBROS---------------------hjv----------------------------------*/

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
            if (model.IdLibro != 0){
                var EditLibros = _Libros.EditarLibros(model);
                if (EditLibros)
                {
                    return RedirectToAction("ListarLi");
                }
                else
                {
                    return View();
                }
            }
            else{
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
                return RedirectToAction("ListarLi");
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
                return RedirectToAction("ListarLi");
            }
            else
            {
                return View();
            }


        }
        
    }
}
