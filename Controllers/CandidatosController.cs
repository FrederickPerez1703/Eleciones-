using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Elecciones_itla.Models;
using Microsoft.AspNetCore.Hosting;
using Elecciones_itla.DTo;
using System.IO;

namespace Elecciones_itla.Controllers
{
    public class CandidatosController : Controller
    {
        private readonly Final_EleccionContext _context;
        public IHostingEnvironment HostingEnvironment;

        public CandidatosController(Final_EleccionContext context , IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.HostingEnvironment = hostingEnvironment;
        }

        // GET: Candidatos
        public async Task<IActionResult> Index()
        {
            var final_EleccionContext = _context.Candidatos.Include(c => c.PartidoCan).Include(c => c.PuestoCan);
            return View(await final_EleccionContext.ToListAsync());
        }

        // GET: Candidatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatos = await _context.Candidatos
                .Include(c => c.PartidoCan)
                .Include(c => c.PuestoCan)
                .FirstOrDefaultAsync(m => m.IdCandidato == id);
            if (candidatos == null)
            {
                return NotFound();
            }

            return View(candidatos);
        }

        // GET: Candidatos/Create
        public IActionResult Create()
        {
            ViewData["PartidoCanId"] = new SelectList(_context.Partidos, "IdPartido", "Nombre");
            ViewData["PuestoCanId"] = new SelectList(_context.PuestoElectivo, "IdPuesto", "Nombre");
            return View();
        }

        // POST: Candidatos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CandidatoDto model)
        {
            var det = new Candidatos();
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                if (model.Foto != null)
                {
                    string folderPath = Path.Combine(HostingEnvironment.WebRootPath, "imagenes");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Foto.FileName;
                    string filePath = Path.Combine(folderPath, uniqueFileName);

                    if (filePath != null) model.Foto.CopyTo(new FileStream(filePath, mode: FileMode.Create));
                }
                Candidatos candidatos = new Candidatos {
                 IdCandidato = model.IdCandidato,
                 Nombre = model.Nombre , 
                 Foto= uniqueFileName , 
                 Apellido = model.Apellido,
                 PartidoCanId = model.PartidoCanId,
                 PuestoCanId = model.PuestoCanId , 
                 Estado = model.Estado , 

                };

                _context.Add(candidatos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           // ViewData["PartidoCanId"] = new SelectList(_context.Partidos, "IdPartido", "Nombre", candidatos.PartidoCanId);
          //  ViewData["PuestoCanId"] = new SelectList(_context.PuestoElectivo, "IdPuesto", "Nombre", candidatos.PuestoCanId);
            return View(model);
        }

        // GET: Candidatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatos = await _context.Candidatos.FindAsync(id);
            if (candidatos == null)
            {
                return NotFound();
            }
            ViewData["PartidoCanId"] = new SelectList(_context.Partidos, "IdPartido", "Nombre", candidatos.PartidoCanId);
            ViewData["PuestoCanId"] = new SelectList(_context.PuestoElectivo, "IdPuesto", "Nombre", candidatos.PuestoCanId);
            return View(candidatos);
        }

        // POST: Candidatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCandidato,Nombre,Apellido,PartidoCanId,PuestoCanId,Foto,Estado")] Candidatos candidatos)
        {
            if (id != candidatos.IdCandidato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatosExists(candidatos.IdCandidato))
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
            ViewData["PartidoCanId"] = new SelectList(_context.Partidos, "IdPartido", "Nombre", candidatos.PartidoCanId);
            ViewData["PuestoCanId"] = new SelectList(_context.PuestoElectivo, "IdPuesto", "Nombre", candidatos.PuestoCanId);
            return View(candidatos);
        }

        // GET: Candidatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatos = await _context.Candidatos
                .Include(c => c.PartidoCan)
                .Include(c => c.PuestoCan)
                .FirstOrDefaultAsync(m => m.IdCandidato == id);
            if (candidatos == null)
            {
                return NotFound();
            }

            return View(candidatos);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidatos = await _context.Candidatos.FindAsync(id);
            _context.Candidatos.Remove(candidatos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatosExists(int id)
        {
            return _context.Candidatos.Any(e => e.IdCandidato == id);
        }
    }
}
