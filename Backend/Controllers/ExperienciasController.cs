using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Context;
using BusinessLogic.Entities;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienciasController : ControllerBase
    {
        private readonly ES2DbContext _context;

        public ExperienciasController(ES2DbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetExperiences()
        {
            if (_context.Experiences == null)
            {
                return NotFound();
            }

            return await _context.Experiences
                .Select(b => new
                {
                    b.Id,
                    b.Title,
                    b.AnoIni,
                    b.AnoFim,
                    Companies = _context.Companies
                        .Where(c => c.Id == b.IdCompany)
                        .Select(c => new
                        {
                            c.Id,
                            c.Name
                        }).ToList()
                })
                .ToListAsync();

        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Experience>> GetExperience(Guid id)
        {
            if (_context.Experiences == null)
            {
                return NotFound();
            }

            var experiencia = await _context.Experiences.FindAsync(id);

            if (experiencia == null)
            {
                return NotFound();
            }

            return experiencia;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(Guid id, Experience experience)
        {
            if (id != experience.Id)
            {
                return BadRequest();
            }

            _context.Entry(experience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienciaExists(id))
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

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Experience>> PostBook(Experience experience)
        {
            if (_context.Experiences == null)
            {
                return Problem("Entity set 'ES2DbContext.Experiencias'  is null.");
            }

            _context.Experiences.Add(experience);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExperience", new { id = experience.Id }, experience);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperience(Guid id)
        {
            if (_context.Experiences == null)
            {
                return NotFound();
            }

            var experiencia = await _context.Experiences.FindAsync(id);
            if (experiencia == null)
            {
                return NotFound();
            }

            _context.Experiences.Remove(experiencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExperienciaExists(Guid id)
        {
            return (_context.Experiences?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}