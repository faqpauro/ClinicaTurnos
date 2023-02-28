using ClinicaTurnosPNT1.ADO;
using ClinicaTurnosPNT1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicaTurnosPNT1.Controllers
{
    public class PersonasController : Controller
    {
        
        public IActionResult Index(string tipoPersona1)
        {
            ViewBag.TipoPersona1 = tipoPersona1;
            return View();
        }

        public IActionResult CreatePersona()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePersona(string nombre, string apellido, string dni, string email, string password, string telefono, string direccion, TipoPersona tipo)
        {
            ADO_Persona ado_persona = new ADO_Persona();
            Persona persona = new Persona
            {
                Email = email,
                Password = password,
                Telefono = telefono,
                Direccion = direccion,
                Dni = dni,
                Nombre = nombre,
                Apellido = apellido,
                tipo = tipo
            };

            ado_persona.Create(persona);


            return RedirectToAction("Index", new { PersonaCreado = true }); /////////ver si sirve de algo el PersonaCreado


        }

        public IActionResult DeletePersona()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeletePersona(string dni)
        {
            ADO_Persona ado_persona = new ADO_Persona();
            Persona? persona = ado_persona.Find(ado_persona.ObtenerIdXDni(dni));

            if (persona == null)
            {
                return RedirectToAction("Index", new { PersonaEliminado = false });
            } else
            {
                ado_persona.Delete(persona);
                return RedirectToAction("Index", new { PersonaEliminado = true });
            }
        }

        public IActionResult ListarPersonas()
        {
            ADO_Persona ado_persona = new ADO_Persona();
            List<Persona> listaDePersonas = ado_persona.ListarPersonas();

            return View(listaDePersonas);
        }

        [HttpGet]
        public IActionResult EditPersona(int Id)
        {
            Persona? persona = null;
            using (AgendaTurnosContext context = new AgendaTurnosContext())
            {
                persona = context.Personas.Find(Id);
                if(persona != null)
                {
                    return View(persona);
                } else
                {
                    return RedirectToAction(nameof(Index));
                }
            }    
        }

        [HttpPost]
        public IActionResult Update(int id, Persona persona)
        {
            using (AgendaTurnosContext context = new AgendaTurnosContext())
            {
                if(id != persona.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    context.Personas.Update(persona);
                    context.SaveChanges();
                }

                return RedirectToAction(nameof(ListarPersonas));
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (AgendaTurnosContext context = new AgendaTurnosContext())
            {
                if (id != 0)
                {
                    Persona? persona = context.Personas.Find(id);
                    if(persona != null)
                    {
                        context.Personas.Remove(persona);
                        context.SaveChanges();
                    }
                }

                return RedirectToAction(nameof(ListarPersonas));
            }
        }

    }
}
