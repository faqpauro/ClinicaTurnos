using ClinicaTurnosPNT1.Models;
using System.Linq;

namespace ClinicaTurnosPNT1.ADO
{
    public class ADO_Persona
    {
        AgendaTurnosContext context = new AgendaTurnosContext();

        public void Create(Persona persona) //Crea Persona
        {
            context.Personas.Add(persona);
            context.SaveChanges();
        }

        public void Delete(Persona persona) //Borra Persona
        {
                context.Personas.Remove(persona);
                context.SaveChanges();
        }

        public List<Persona> ListarPersonas() //Lista Personas
        {
            return context.Personas.ToList();
        }

        public Boolean ValidarSesion(string email, string pass) //valida email y contraseña de la persona
        {
            int id = ObtenerId(email);

            if(id >= 0)
            {
                Persona? persona = context.Personas.Find(id);
                if(persona.Password == pass)
                {
                    return true;

                } else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public int ObtenerId(string email) //Busca Persona por email y devuelve id
        {
            List<Persona> personas = new List<Persona>();
            personas = context.Personas.ToList();
            int idEncontrado = -1;

            foreach (var persona in personas)
            {
                if(persona.Email == email)
                {
                    idEncontrado = persona.Id;
                }
            }
            return idEncontrado;
        }

        public int ObtenerIdXDni(string dni) //Busca Persona por dni y devuelve id
        {
            List<Persona> personas = new List<Persona>();
            personas = context.Personas.ToList();
            int idEncontrado = -1;

            foreach (var persona in personas)
            {
                if (persona.Dni == dni)
                {
                    idEncontrado = persona.Id;
                }
            }
            return idEncontrado;
        }

        public Persona? Find(int id) //Busca Persona por ID
        {
            Persona? persona = context.Personas.Find(id);
            return persona;
        }
    }
}
