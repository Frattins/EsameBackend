using EsameBackend.Data;
using EsameBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EsameBackend.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnagraficaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var anagrafiche = _context.Anagrafiche.ToList();
            return View(anagrafiche);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                _context.Anagrafiche.Add(anagrafica);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(anagrafica);
        }
    }
}
