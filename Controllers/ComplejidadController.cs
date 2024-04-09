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
    public class ComplejidadController : Controller
    {
        private readonly REQUERIMIENTOSContext _context;

        public ComplejidadController(REQUERIMIENTOSContext context)
        {
            _context = context;
        }

        // GET: Complejidads
        public async Task<IActionResult> Index(int? page)
        {
            return View(await _context.Complejidads.ToPagedListAsync(page ?? 1, 5));
        }


        // GET: Complejidads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Complejidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdComplejidad,Descripcion")] Complejidad complejidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(complejidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(complejidad);
        }

        // GET: Complejidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Complejidads == null)
            {
                return NotFound();
            }

            var complejidad = await _context.Complejidads.FindAsync(id);
            if (complejidad == null)
            {
                return NotFound();
            }
            return View(complejidad);
        }

        // POST: Complejidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdComplejidad,Descripcion")] Complejidad complejidad)
        {
            if (id != complejidad.IdComplejidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(complejidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComplejidadExists(complejidad.IdComplejidad))
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
            return View(complejidad);
        }

        // GET: Complejidads/Delete/5
        
        private bool ComplejidadExists(int id)
        {
          return _context.Complejidads.Any(e => e.IdComplejidad == id);
        }
    }
}
