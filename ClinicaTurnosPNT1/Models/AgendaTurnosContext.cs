using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore; //Sirve para poder heredar del DbContext

namespace ClinicaTurnosPNT1.Models
{
    public class AgendaTurnosContext : DbContext
    {
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Turno> Turnos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            if (!option.IsConfigured)
            {
                option.UseSqlServer("Data Source=DESKTOP-SI5AEF8\\SQLEXPRESS; Initial Catalog=Clinica; Integrated Security=true; TrustServerCertificate=True");
            }
        }

    }
}
