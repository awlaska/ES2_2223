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
        public async Task<ActionResult<IEnumerable<dynamic>>> GetBooks()
        {
            if (_context.Experiencias == null)
            {
                return NotFound();
            }

            return await _context
                .Experiencias.Select(b => new
                {
                    b.Id,
                    b.titulo,
                    b.empresa,
                    b.ano_ini,
                    b.ano_fim,
                    User = new
                    {
                        b.User!.Id,
                        b.User.name,
                        b.User.email,
                        b.User.pais,
                        b.User.pr_hora
                    }
                })
                .ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Experiencia>> GetBook(Guid id)
        {
            if (_context.Experiencias == null)
            {
                return NotFound();
            }

            var book = await _context.Experiencias.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
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
                if (!BookExists(id))
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
                return Problem("Entity set 'ES2DbContext.Books'  is null.");
            }

            _context.Experiencias.Add(experiencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = experiencia.Id }, experiencia);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            if (_context.Experiencias == null)
            {
                return NotFound();
            }

            var book = await _context.Experiencias.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Experiencias.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(Guid id)
        {
            return (_context.Experiencias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}