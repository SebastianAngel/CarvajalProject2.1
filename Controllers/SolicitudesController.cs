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
    [Authorize]
    public class SolicitudesController : Controller
    {
        private readonly REQUERIMIENTOSContext _context;

        public SolicitudesController(REQUERIMIENTOSContext context)
        {
            _context = context;
        }

        // GET: Solicitudes
        public async Task<IActionResult> Index(int? page)
        {
            ViewBag.id = TempData["id"];
            ViewBag.rol = TempData["rol"];
            int id = ViewBag.id;
            string rol = ViewBag.rol;

            TempData["id"] = id;
            TempData["rol"] = rol;

            if (ViewBag.rol == "Ingeniero")
            {
                var rEQUERIMIENTOSContext = _context.Solicitudes.Include(s => s.IdCaracteristicaNavigation).Include(s => s.IdComplejidadNavigation).Include(s => s.IdEstadoNavigation).Include(s => s.IdIngenieroNavigation).Include(s => s.IdPeriodicidadNavigation).Include(s => s.IdTipoNavigation).Where(IdIng => IdIng.IdIngeniero == id);
                return View(await rEQUERIMIENTOSContext.ToPagedListAsync(page?? 1,5));

            }
            else
            {
                if (rol == "Administrador")
                {
                    var rEQUERIMIENTOSContext = _context.Solicitudes.Include(s => s.IdCaracteristicaNavigation).Include(s => s.IdComplejidadNavigation).Include(s => s.IdEstadoNavigation).Include(s => s.IdIngenieroNavigation).Include(s => s.IdPeriodicidadNavigation).Include(s => s.IdTipoNavigation);
                    return View(await rEQUERIMIENTOSContext.ToPagedListAsync(page ?? 1, 5));

                }
                else
                {
                    var rEQUERIMIENTOSContext = _context.Solicitudes.Include(s => s.IdCaracteristicaNavigation).Include(s => s.IdComplejidadNavigation).Include(s => s.IdEstadoNavigation).Include(s => s.IdIngenieroNavigation).Include(s => s.IdPeriodicidadNavigation).Include(s => s.IdTipoNavigation);
                    return View(await rEQUERIMIENTOSContext.ToPagedListAsync(page ?? 1, 5));
                }
            }

            //var rEQUERIMIENTOSContext = _context.Solicitudes.Include(s => s.IdCaracteristicaNavigation).Include(s => s.IdComplejidadNavigation).Include(s => s.IdEstadoNavigation).Include(s => s.IdIngenieroNavigation).Include(s => s.IdPeriodicidadNavigation).Include(s => s.IdTipoNavigation);
            //return View(await rEQUERIMIENTOSContext.ToListAsync());
        }

        // GET: Solicitudes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Solicitudes == null)
            {
                return NotFound();
            }

            var solicitude = await _context.Solicitudes
                .Include(s => s.IdCaracteristicaNavigation)
                .Include(s => s.IdComplejidadNavigation)
                .Include(s => s.IdEstadoNavigation)
                .Include(s => s.IdIngenieroNavigation)
                .Include(s => s.IdPeriodicidadNavigation)
                .Include(s => s.IdTipoNavigation)
                .FirstOrDefaultAsync(m => m.IdSolicitud == id);
            if (solicitude == null)
            {
                return NotFound();
            }

            return View(solicitude);
        }

        // GET: Solicitudes/Create
        public IActionResult Create(Solicitante cliente)
        {
            ViewData["IdCaracteristica"] = new SelectList(_context.Caracteristicas, "IdCaracteristica", "Descripcion");
            ViewData["IdComplejidad"] = new SelectList(_context.Complejidads, "IdComplejidad", "Descripcion");
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "Descripcion");
            ViewData["IdIngeniero"] = new SelectList(_context.Ingenieros, "IdIngeniero", "Nombre");
            ViewData["IdPeriodicidad"] = new SelectList(_context.Periodicidads, "IdPeriodicidad", "Descripcion");
            ViewData["IdTipo"] = new SelectList(_context.TipoSolicituds, "IdTipo", "Descripcion");
            return View();
        }

        // POST: Solicitudes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSolicitud,Solicitante,Telefono,Correo,Cliente,IdTipo,Producto,IdCaracteristica,IdEstado,IdComplejidad,Descripcion,Estado,IdPeriodicidad,Email,AsuntoEmail,DominioCorpEmail,CuerpoEmail,NombrePdf,EncriptadoEmail,ClaveEmail,CertificadoEmail,DominioEmail,Sms,Mensaje,Fisico,Color,AislamientoFisico,TamanoFisico,TipoPapelFisico,TipoFisico,Microperforado,Pdf,TipoEntrega,Publicacion,ContenidoPublicacion,FechaSolicitud,FechaInicio,FechaPruebas,FechaAprobacion,FechaFinal,ReqFunc,ReqNoFunc,ReqAmbiente,IdIngeniero")] Solicitud solicitude)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitude);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCaracteristica"] = new SelectList(_context.Caracteristicas, "IdCaracteristica", "IdCaracteristica", solicitude.IdCaracteristica);
            ViewData["IdComplejidad"] = new SelectList(_context.Complejidads, "IdComplejidad", "IdComplejidad", solicitude.IdComplejidad);
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", solicitude.IdEstado);
            ViewData["IdIngeniero"] = new SelectList(_context.Ingenieros, "IdIngeniero", "IdIngeniero", solicitude.IdIngeniero);
            ViewData["IdPeriodicidad"] = new SelectList(_context.Periodicidads, "IdPeriodicidad", "IdPeriodicidad", solicitude.IdPeriodicidad);
            ViewData["IdTipo"] = new SelectList(_context.TipoSolicituds, "IdTipo", "IdTipo", solicitude.IdTipo);
            return View(solicitude);
        }

        // GET: Solicitudes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.id = TempData["id"];
            ViewBag.rol = TempData["rol"];
            int idIng = ViewBag.id;
            string rol = ViewBag.rol;

            TempData["id"] = idIng;
            TempData["rol"] = rol;

            if (id == null || _context.Solicitudes == null)
            {
                return NotFound();
            }

            var solicitude = await _context.Solicitudes.FindAsync(id);
            if (solicitude == null)
            {
                return NotFound();
            }
            ViewData["IdCaracteristica"] = new SelectList(_context.Caracteristicas, "IdCaracteristica", "Descripcion", solicitude.IdCaracteristica);
            ViewData["IdComplejidad"] = new SelectList(_context.Complejidads, "IdComplejidad", "Descripcion", solicitude.IdComplejidad);
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "Descripcion", solicitude.IdEstado);
            ViewData["IdIngeniero"] = new SelectList(_context.Ingenieros, "IdIngeniero", "Nombre", solicitude.IdIngeniero);
            ViewData["IdPeriodicidad"] = new SelectList(_context.Periodicidads, "IdPeriodicidad", "Descripcion", solicitude.IdPeriodicidad);
            ViewData["IdTipo"] = new SelectList(_context.TipoSolicituds, "IdTipo", "Descripcion", solicitude.IdTipo);
            return View(solicitude);
        }

        // POST: Solicitudes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSolicitud,Solicitante,Telefono,Correo,Cliente,IdTipo,Producto,IdCaracteristica,IdEstado,IdComplejidad,Descripcion,Estado,IdPeriodicidad,Email,AsuntoEmail,DominioCorpEmail,CuerpoEmail,NombrePdf,EncriptadoEmail,ClaveEmail,CertificadoEmail,DominioEmail,Sms,Mensaje,Fisico,Color,AislamientoFisico,TamanoFisico,TipoPapelFisico,TipoFisico,Microperforado,Pdf,TipoEntrega,Publicacion,ContenidoPublicacion,FechaSolicitud,FechaInicio,FechaPruebas,FechaAprobacion,FechaFinal,ReqFunc,ReqNoFunc,ReqAmbiente,IdIngeniero")] Solicitud solicitude)
        {
            ViewBag.id = TempData["id"];
            ViewBag.rol = TempData["rol"];
            int idIng = ViewBag.id;
            string rol = ViewBag.rol;

            TempData["id"] = idIng;
            TempData["rol"] = rol;

            if (id != solicitude.IdSolicitud)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitude);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitudeExists(solicitude.IdSolicitud))
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
            ViewData["IdCaracteristica"] = new SelectList(_context.Caracteristicas, "IdCaracteristica", "Descripcion", solicitude.IdCaracteristica);
            ViewData["IdComplejidad"] = new SelectList(_context.Complejidads, "IdComplejidad", "Descripcion", solicitude.IdComplejidad);
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "Descripcion", solicitude.IdEstado);
            ViewData["IdIngeniero"] = new SelectList(_context.Ingenieros, "IdIngeniero", "Nombre", solicitude.IdIngeniero);
            ViewData["IdPeriodicidad"] = new SelectList(_context.Periodicidads, "IdPeriodicidad", "Descripcion", solicitude.IdPeriodicidad);
            ViewData["IdTipo"] = new SelectList(_context.TipoSolicituds, "IdTipo", "Descripcion", solicitude.IdTipo);
            return View(solicitude);
        }

        // GET: Solicitudes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Solicitudes == null)
            {
                return NotFound();
            }

            var solicitude = await _context.Solicitudes
                .Include(s => s.IdCaracteristicaNavigation)
                .Include(s => s.IdComplejidadNavigation)
                .Include(s => s.IdEstadoNavigation)
                .Include(s => s.IdIngenieroNavigation)
                .Include(s => s.IdPeriodicidadNavigation)
                .Include(s => s.IdTipoNavigation)
                .FirstOrDefaultAsync(m => m.IdSolicitud == id);
            if (solicitude == null)
            {
                return NotFound();
            }

            return View(solicitude);
        }

        // POST: Solicitudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Solicitudes == null)
            {
                return Problem("Entity set 'REQUERIMIENTOSContext.Solicitudes'  is null.");
            }
            var solicitude = await _context.Solicitudes.FindAsync(id);
            if (solicitude != null)
            {
                _context.Solicitudes.Remove(solicitude);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitudeExists(int id)
        {
          return _context.Solicitudes.Any(e => e.IdSolicitud == id);
        }
    }
}
