using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Carvajar_2._1.Models.Data;
using Microsoft.AspNetCore.Authorization;
using X.PagedList;

namespace Carvajar_2._1.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class SolicitantesController : Controller
    {
        private readonly REQUERIMIENTOSContext _context;

        public SolicitantesController(REQUERIMIENTOSContext context)
        {
            _context = context;
        }

        // GET: Solicitantes
        public async Task<IActionResult> Index(int? page)
        {
            return View(await _context.Solicitantes.ToPagedListAsync(page ?? 1, 5));
        }




        // GET: Solicitantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Solicitantes == null)
            {
                return NotFound();
            }

            var solicitante = await _context.Solicitantes
                .FirstOrDefaultAsync(m => m.IdSolicitante == id);
            if (solicitante == null)
            {
                return NotFound();
            }

            return View(solicitante);
        }

        
        private bool SolicitanteExists(int id)
        {
          return _context.Solicitantes.Any(e => e.IdSolicitante == id);
        }
    }
}
