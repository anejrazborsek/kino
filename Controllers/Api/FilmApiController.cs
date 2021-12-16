using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers_Api
{
    [Route("api/v1/film")]
    [ApiController]
    public class FilmApiController : ControllerBase
    {
        private readonly KinoContext _context;

        public FilmApiController(KinoContext context)
        {
            _context = context;
        }

        // GET: api/FilmApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Film>>> GetFilmi()
        {
            return await _context.Filmi.ToListAsync();
        }

        // GET: api/FilmApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Film>> GetFilm(int id)
        {
            var film = await _context.Filmi.FindAsync(id);

            if (film == null)
            {
                return NotFound();
            }

            return film;
        }

        // PUT: api/FilmApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilm(int id, Film film)
        {
            if (id != film.FilmID)
            {
                return BadRequest();
            }

            _context.Entry(film).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FilmApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Film>> PostFilm(Film film)
        {
            _context.Filmi.Add(film);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilm", new { id = film.FilmID }, film);
        }

        // DELETE: api/FilmApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var film = await _context.Filmi.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }

            _context.Filmi.Remove(film);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmExists(int id)
        {
            return _context.Filmi.Any(e => e.FilmID == id);
        }
    }
}
