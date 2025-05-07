using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ProyectoLibreria.Models.Entidades
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El Campoo {0} es obligatorio. ")]
        public string Nombre { get; set; }

        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd hh:mm tt}")]
        public DateTime FechaNacimiento { get; set; }

    }
}
