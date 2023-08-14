using System.ComponentModel.DataAnnotations;

namespace CrudLibro.Models
{
    public class LibroModel
    {
        public int IdLibro { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="Nombre es Obligatorio")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "Autor es Obligatorio")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "Cantidad es Obligatorio")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "ISBN es Obligatorio")]
        public DateTime Fecha_de_Compra{ get; set; }
        public DateTime Fecha_de_Adquisicion { get; set; }

    }
}
