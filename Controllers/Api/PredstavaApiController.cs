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
    [Route("api/v1/predstava")]
    [ApiController]
    public class PredstavaApiController : ControllerBase
    {
        private readonly KinoContext _context;

        public PredstavaApiController(KinoContext context)
        {
            _context = context;
        }

        // GET: api/PredstavaApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Predstava>>> GetPredstave()
        {
            return await _context.Predstave.ToListAsync();
        }

        // GET: api/PredstavaApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Predstava>> GetPredstava(int id)
        {
            var predstava = await _context.Predstave.FindAsync(id);

            if (predstava == null)
            {
                return NotFound();
            }

            return predstava;
        }

        // PUT: api/PredstavaApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPredstava(int id, Predstava predstava)
        {
            if (id != predstava.PredstavaID)
            {
                return BadRequest();
            }

            _context.Entry(predstava).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PredstavaExists(id))
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

        // POST: api/PredstavaApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Predstava>> PostPredstava(Predstava predstava)
        {
            _context.Predstave.Add(predstava);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPredstava", new { id = predstava.PredstavaID }, predstava);
        }

        // DELETE: api/PredstavaApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePredstava(int id)
        {
            var predstava = await _context.Predstave.FindAsync(id);
            if (predstava == null)
            {
                return NotFound();
            }

            _context.Predstave.Remove(predstava);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PredstavaExists(int id)
        {
            return _context.Predstave.Any(e => e.PredstavaID == id);
        }
    }
}
