using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using Microsoft.AspNetCore.Authorization;

namespace web.Controllers
{
    public class FilmiController : Controller
    {
        private readonly KinoContext _context;

        public FilmiController(KinoContext context)
        {
            _context = context;
        }

        // GET: 
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filmi.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Filmi
                .FirstOrDefaultAsync(m => m.FilmID == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: Create
        //[Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: 
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilmID,Film_ime,Film_trajanje,Film_reziser,Film_opis,Film_img")] Film film)
        {
            if (ModelState.IsValid)
            {
                _context.Add(film);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // GET: 
        //[Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Filmi.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilmID,Film_ime,Film_trajanje,Film_reziser,Film_opis,Film_img")] Film film)
        {
            if (id != film.FilmID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.FilmID))
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
            return View(film);
        }

        // GET: 
        //[Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Filmi
                .FirstOrDefaultAsync(m => m.FilmID == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _context.Filmi.FindAsync(id);
            _context.Filmi.Remove(film);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return _context.Filmi.Any(e => e.FilmID == id);
        }
    }
}
