using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using web.Models.PredstavaViewModels;
using Microsoft.AspNetCore.Authorization;

namespace web.Controllers
{
    public class PredstaveController : Controller
    {
        private readonly KinoContext _context;

        public PredstaveController(KinoContext context)
        {
            _context = context;
        }

        // GET:
        public async Task<IActionResult> Index()
        {
            var predstave = _context.Predstave
                .Include(c => c.Film)
                .Include(d => d.Dvorana)
                .AsNoTracking();
            return View(await predstave.ToListAsync());
        
        }





        // GET:
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predstava = await _context.Predstave
                .FirstOrDefaultAsync(m => m.PredstavaID == id);
            if (predstava == null)
            {
                return NotFound();
            }

            return View(predstava);
        }

        // GET: 
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: 
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PredstavaID,Predstava_cas,FilmID,DvoranaID")] Predstava predstava)
        {
            if (ModelState.IsValid)
            {
                _context.Add(predstava);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(predstava);
        }

        // GET: 
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predstava = await _context.Predstave.FindAsync(id);
            if (predstava == null)
            {
                return NotFound();
            }
            return View(predstava);
        }

        // POST:
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PredstavaID,Predstava_cas,FilmID,DvoranaID")] Predstava predstava)
        {
            if (id != predstava.PredstavaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(predstava);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PredstavaExists(predstava.PredstavaID))
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
            return View(predstava);
        }

        // GET: 
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predstava = await _context.Predstave
                .FirstOrDefaultAsync(m => m.PredstavaID == id);
            if (predstava == null)
            {
                return NotFound();
            }

            return View(predstava);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var predstava = await _context.Predstave.FindAsync(id);
            _context.Predstave.Remove(predstava);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PredstavaExists(int id)
        {
            return _context.Predstave.Any(e => e.PredstavaID == id);
        }
    }
}
