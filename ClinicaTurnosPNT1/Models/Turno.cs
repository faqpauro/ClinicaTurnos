using System.ComponentModel.DataAnnotations;

namespace ClinicaTurnosPNT1.Models
{
    public class Turno
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public bool Activo { get; set; }
        public Persona Paciente { get; set; }
        public int PacienteId { get; set; }
        public TipoPrestacion Prestacion { get; set; }
    }
}
