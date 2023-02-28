using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations; //Para poder usar los [Required] etc..

namespace ClinicaTurnosPNT1.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public TipoPersona tipo { get; set; }
    }
}
