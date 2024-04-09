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
    public class CaracteristicaController : Controller
    {
        private readonly REQUERIMIENTOSContext _context;

        public CaracteristicaController(REQUERIMIENTOSContext context)
        {
            _context = context;
        }

        // GET: Caracteristica
        public async Task<IActionResult> Index(int? page)
        {
            return View(await _context.Caracteristicas.ToPagedListAsync(page ?? 1, 5));
        }


        // GET: Caracteristica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Caracteristica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCaracteristica,Descripcion")] Caracteristica caracteristica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caracteristica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caracteristica);
        }

        // GET: Caracteristica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Caracteristicas == null)
            {
                return NotFound();
            }

            var caracteristica = await _context.Caracteristicas.FindAsync(id);
            if (caracteristica == null)
            {
                return NotFound();
            }
            return View(caracteristica);
        }

        // POST: Caracteristica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCaracteristica,Descripcion")] Caracteristica caracteristica)
        {
            if (id != caracteristica.IdCaracteristica)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caracteristica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaracteristicaExists(caracteristica.IdCaracteristica))
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
            return View(caracteristica);
        }

        // GET: Caracteristica/Delete/5
       

        private bool CaracteristicaExists(int id)
        {
          return _context.Caracteristicas.Any(e => e.IdCaracteristica == id);
        }
    }
}
