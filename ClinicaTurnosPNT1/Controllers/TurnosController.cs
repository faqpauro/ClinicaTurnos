using ClinicaTurnosPNT1.ADO;
using ClinicaTurnosPNT1.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClinicaTurnosPNT1.Controllers
{
    public class TurnosController : Controller
    {
        Persona persona = new Persona();

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult CreateTurno(int id) //GET Obtiene ID del paciente logeado para agregarlo en el turno
        {
            ADO_Persona ado_persona = new ADO_Persona();
            persona = ado_persona.Find(id);
            return View(persona);
        }

        [HttpPost]
        public IActionResult CreateTurno(DateTime fechaHora, bool activo, TipoPrestacion prestacion, int pacienteId) //POST Crea turno
        {
            ADO_Turnos ado_turno = new ADO_Turnos();

            Turno turno = new Turno
            {
                FechaHora = fechaHora,
                Activo = activo,
                PacienteId = pacienteId,
                Prestacion = prestacion
            };

            ado_turno.Create(turno);


            return RedirectToAction("IndexLogueado2", "Home", new { IdLogueado = pacienteId });


        }

        public IActionResult ListarTurnos() //Lista los turnos
        {
            ADO_Turnos ado_turno = new ADO_Turnos();
            List<Turno> listaDeTurnos = ado_turno.ListarTurnos();

            return View(listaDeTurnos);
        }

        [HttpGet]
        public IActionResult Update(int id) //Update para actualizar campo "Activo" del turno
        {
            ADO_Turnos ado_turnos = new ADO_Turnos();
            Turno turno1 = ado_turnos.Find(id);
            using (AgendaTurnosContext context = new AgendaTurnosContext())
            {
                if (turno1.Activo == true)
                {
                    turno1.Activo = false;
                    context.Turnos.Update(turno1);
                    context.SaveChanges();
                } else
                {
                    turno1.Activo = true;
                    context.Turnos.Update(turno1);
                    context.SaveChanges();
                }

                return RedirectToAction(nameof(ListarTurnos));
            }
        }

        [HttpGet]
        public IActionResult Delete(int id) //ELIMINA TURNO DESDE EL LISTADO DE TURNOS
        {
            using (AgendaTurnosContext context = new AgendaTurnosContext())
            {
                if (id != 0)
                {
                    Turno? turno = context.Turnos.Find(id);
                    if (persona != null)
                    {
                        context.Turnos.Remove(turno);
                        context.SaveChanges();
                    }
                }

                return RedirectToAction(nameof(ListarTurnos));
            }
        }
    }
}
