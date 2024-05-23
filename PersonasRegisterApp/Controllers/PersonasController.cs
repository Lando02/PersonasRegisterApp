
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonasRegisterApp.Data;
using PersonasRegisterApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PersonasRegisterApp.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Personas.Include(p => p.Contactos).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Persona persona, Contacto[] contactos)
        {
            if (ModelState.IsValid)
            {
                persona.Contactos = contactos.Where(c => !string.IsNullOrEmpty(c.Email) || !string.IsNullOrEmpty(c.DireccionFisica) || !string.IsNullOrEmpty(c.NumeroTelefonico)).ToList();
                persona.Contactos.First().PersonaDocumentoIdentidad = persona.DocumentoIdentidad;
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }
    }
}
