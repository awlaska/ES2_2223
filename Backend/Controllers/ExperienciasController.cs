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
        public async Task<ActionResult<IEnumerable<dynamic>>> GetExperiencias()
        {
            if (_context.Experiencias == null)
            {
                return NotFound();
            }

            return await _context
                .Experiencias.Select(b => new
                {
                    b.Id,
                    titulo = b.Titulo,
                    empresa = b.Empresa,
                    ano_ini = b.AnoIni,
                    ano_fim = b.AnoFim
                })
                .ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Experiencia>> GetExperiencia(Guid id)
        {
            if (_context.Experiencias == null)
            {
                return NotFound();
            }

            var experiencia = await _context.Experiencias.FindAsync(id);

            if (experiencia == null)
            {
                return NotFound();
            }

            return experiencia;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(Guid id, Experiencia experiencia)
        {
            if (id != experiencia.Id)
            {
                return BadRequest();
            }

            _context.Entry(experiencia).State = EntityState.Modified;

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
        public async Task<ActionResult<Experiencia>> PostBook(Experiencia experiencia)
        {
            if (_context.Experiencias == null)
            {
                return Problem("Entity set 'ES2DbContext.Experiencias'  is null.");
            }

            _context.Experiencias.Add(experiencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExperiencia", new { id = experiencia.Id }, experiencia);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperiencia(Guid id)
        {
            if (_context.Experiencias == null)
            {
                return NotFound();
            }

            var experiencia = await _context.Experiencias.FindAsync(id);
            if (experiencia == null)
            {
                return NotFound();
            }

            _context.Experiencias.Remove(experiencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExperienciaExists(Guid id)
        {
            return (_context.Experiencias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}