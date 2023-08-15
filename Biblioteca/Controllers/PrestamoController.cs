using Prestamo.Models;
using Microsoft.AspNetCore.Mvc;
using Presatamo_Datos;

namespace Biblioteca.Controllers
{
    public class PrestamoController : Controller
    {

        Prestamo_Datos _prestamo = new Prestamo_Datos();


        // GET: PrestamoController
        public IActionResult ListarPrestamos()
        {
            
                var list = _prestamo.ListaPrestamo();
                return View(list);
            
        }

        /*ELIMINAR PRESTAMO-------------------------------------------------------------------------------------*/
        public IActionResult EliminarPrestamos(PrestamoModel model)
        {
            var elim = _prestamo.Prestamo_Eliminar(model);
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
        public IActionResult AñadirPrestamos()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AñadirLi(PrestamoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool GuarLibro = _prestamo.Prestamo_Guardar(model);
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
