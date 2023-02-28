using ClinicaTurnosPNT1.Models;

namespace ClinicaTurnosPNT1.ADO
{
    public class ADO_Turnos
    {
        AgendaTurnosContext context = new AgendaTurnosContext();
        public void Create(Turno turno) //Crea Turno
        {
            context.Turnos.Add(turno);
            context.SaveChanges();
        }

        public void Delete(Turno turno) //Borra Turno
        {
            context.Turnos.Remove(turno);
            context.SaveChanges();
        }

        public List<Turno> ListarTurnos() //Lista turnos
        {
            return context.Turnos.ToList();
        }

        public Turno? Find(int id) //Busca Turno por ID
        {
            Turno? turno = context.Turnos.Find(id);
            return turno;
        }
    }
}
