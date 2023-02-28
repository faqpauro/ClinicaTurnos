using ClinicaTurnosPNT1.ADO;
using ClinicaTurnosPNT1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace ClinicaTurnosPNT1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string EmailLogueado = "Prueba";
        Boolean UsuarioIncorrecto = false;
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(Boolean UsuarioIncorrecto) //Login - Obtiene un boolean para avisar si el user o passw son incorrectos
        {
            ViewData["usuarioIncorrecto"] = UsuarioIncorrecto;
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string password) //POST Login
        {
            ADO_Persona ado_persona = new ADO_Persona();
            Boolean existeUserPassw = ado_persona.ValidarSesion(email, password);
            Persona persona = ado_persona.Find(ado_persona.ObtenerId(email));

            if (existeUserPassw)
            {
                if(persona.tipo == TipoPersona.Administrador)
                {
                    return RedirectToAction("IndexLogueado", new { EmailLogueado = email });
                }else
                {
                    return RedirectToAction("IndexLogueado2", new { idLogueado = persona.Id });
                }       
                
            } else
            {
                return RedirectToAction("Index", new { UsuarioIncorrecto = true });
            }

            
        }

        public IActionResult IndexLogueado(string EmailLogueado) //Vista de Administrador
        {
            ADO_Persona ado_persona = new ADO_Persona();
            Persona? PersonaLog = ado_persona.Find(ado_persona.ObtenerId(EmailLogueado));
            return View(PersonaLog);
        }

        public IActionResult IndexLogueado2(int idLogueado) //Vista de Paciente
        {
            ADO_Persona ado_persona = new ADO_Persona();
            Persona? PersonaLog = ado_persona.Find(idLogueado);
            return View(PersonaLog);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}