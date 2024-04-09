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
    public class PeriodicidadController : Controller
    {
        private readonly REQUERIMIENTOSContext _context;

        public PeriodicidadController(REQUERIMIENTOSContext context)
        {
            _context = context;
        }

        // GET: Periodicidad
        public async Task<IActionResult> Index(int? page)
        {
            return View(await _context.Periodicidads.ToPagedListAsync(page ?? 1, 5));
        }

        // GET: Periodicidad/Details/5


        // GET: Periodicidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Periodicidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeriodicidad,Descripcion")] Periodicidad periodicidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(periodicidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(periodicidad);
        }

        // GET: Periodicidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Periodicidads == null)
            {
                return NotFound();
            }

            var periodicidad = await _context.Periodicidads.FindAsync(id);
            if (periodicidad == null)
            {
                return NotFound();
            }
            return View(periodicidad);
        }

        // POST: Periodicidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPeriodicidad,Descripcion")] Periodicidad periodicidad)
        {
            if (id != periodicidad.IdPeriodicidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periodicidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodicidadExists(periodicidad.IdPeriodicidad))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(periodicidad);
        }

        // GET: Periodicidad/Delete/5
       
        private bool PeriodicidadExists(int id)
        {
          return _context.Periodicidads.Any(e => e.IdPeriodicidad == id);
        }
    }
}
