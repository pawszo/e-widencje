using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using e_widencje.Contexts;
using e_widencje.Models;

namespace e_widencje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExciseEvidencesController : ControllerBase
    {
        private readonly MainDbContext _context;

        public ExciseEvidencesController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/ExciseEvidences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExciseEvidence>>> GetExciseEvidences()
        {
            return await _context.ExciseEvidences.ToListAsync();
        }

        // GET: api/ExciseEvidences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExciseEvidence>> GetExciseEvidence(int id)
        {
            var exciseEvidence = await _context.ExciseEvidences.FindAsync(id);

            if (exciseEvidence == null)
            {
                return NotFound();
            }

            return exciseEvidence;
        }

        // PUT: api/ExciseEvidences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExciseEvidence(int id, ExciseEvidence exciseEvidence)
        {
            if (id != exciseEvidence.Id)
            {
                return BadRequest();
            }

            _context.Entry(exciseEvidence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExciseEvidenceExists(id))
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

        // POST: api/ExciseEvidences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExciseEvidence>> PostExciseEvidence(ExciseEvidence exciseEvidence)
        {
            _context.ExciseEvidences.Add(exciseEvidence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExciseEvidence", new { id = exciseEvidence.Id }, exciseEvidence);
        }

        // DELETE: api/ExciseEvidences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExciseEvidence(int id)
        {
            var exciseEvidence = await _context.ExciseEvidences.FindAsync(id);
            if (exciseEvidence == null)
            {
                return NotFound();
            }

            _context.ExciseEvidences.Remove(exciseEvidence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExciseEvidenceExists(int id)
        {
            return _context.ExciseEvidences.Any(e => e.Id == id);
        }
    }
}
