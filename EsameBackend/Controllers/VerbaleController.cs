using EsameBackend.Data;
using EsameBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EsameBackend.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VerbaleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var verbali = _context.Verbali
                .Include(v => v.Anagrafica)
                .Include(v => v.TipoViolazione)
                .ToList();
            return View(verbali);
        }

        public IActionResult Create()
        {
            ViewBag.Anagrafiche = _context.Anagrafiche.ToList();
            ViewBag.TipoViolazioni = _context.TipoViolazioni.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                _context.Verbali.Add(verbale);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Anagrafiche = _context.Anagrafiche.ToList();
            ViewBag.TipoViolazioni = _context.TipoViolazioni.ToList();
            return View(verbale);
        }
    }
}
