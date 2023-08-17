using Biblioteca.Models;

namespace Prestamo.Models
{
    public class PrestamoModel
    {
        public int idPrestamo { get; set; }
        public string Titulo { get; set; }
        public UsuarioModel IdUsuario { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha_de_Prestamo { get; set; }
        public DateTime Fecha_de_Entrega { get; set; }
        public int Estatus { get; set; }

    }
}
