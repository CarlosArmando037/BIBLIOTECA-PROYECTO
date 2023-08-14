using CrudLibro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class PrestamoController : Controller
    {
        // GET: PrestamoController
        public IActionResult ObtenerLi()
        {

            var Obte = _Libros.ListaLi();
            return View(Obte);

        }

        /*ELIMINAR PRESTAMO-------------------------------------------------------------------------------------*/
        public IActionResult EliminarLi(PrestamoModel model)
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

        /*AÑADIR prestamo-----------------------------------------------------*/
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
