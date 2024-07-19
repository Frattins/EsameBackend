using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EsameBackend.Data;

namespace EsameBackend.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VerbaliPerTrasgressore()
        {
            var report = _context.Verbali
                .Include(v => v.Anagrafica)
                .GroupBy(v => v.Anagrafica.Cognome)
                .Select(g => new { Trasgressore = g.Key, Verbali = g.Count() })
                .ToList();
            return View(report);
        }

        public IActionResult PuntiDecurtatiPerTrasgressore()
        {
            var report = _context.Verbali
                .Include(v => v.Anagrafica)
                .GroupBy(v => v.Anagrafica.Cognome)
                .Select(g => new { Trasgressore = g.Key, PuntiDecurtati = g.Sum(v => v.DecurtamentoPunti) })
                .ToList();
            return View(report);
        }

        public IActionResult ViolazioniImportoMaggiori400()
        {
            var report = _context.Verbali
                .Include(v => v.Anagrafica)
                .Where(v => v.Importo > 400)
                .ToList();
            return View(report);
        }
    }
}
