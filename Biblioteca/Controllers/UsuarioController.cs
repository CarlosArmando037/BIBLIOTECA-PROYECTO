using Microsoft.AspNetCore.Mvc;
using CRUDusuario.Models;
using usuarios.Datos;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        //el "ContactoDatos" es el nombre del la clase de el archivo "ContactodDatos.cs"

        UsuarioDatos _contactoDatos= new UsuarioDatos();


        [HttpGet]
        public IActionResult Añadir()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Añadir(UsuarioModel model)
        {
            var respuesta = _contactoDatos.AñadirUsuario(model);
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
