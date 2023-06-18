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
    public class PropostasController : ControllerBase
    {
        private readonly ES2DbContext _context;

        public PropostasController(ES2DbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetPropostas()
        {
            if (_context.Propostas == null)
            {
                return NotFound();
            }

            return await _context.Propostas
                .Select(b => new
                {
                    b.Id,
                    Users = _context.Users
                        .Where(c => c.Id == b.IdUser)
                        .Select(c => new
                        {
                            c.Id,
                            c.Name
                        }).ToList(),
                    Categorias = _context.Categorias
                        .Where(c => c.Id == b.IdCategoria)
                        .Select(c => new
                        {
                            c.Id,
                            c.Name
                        }).ToList(),
                    Companies = _context.Companies
                        .Where(c => c.Id == b.IdCompany)
                        .Select(c => new
                        {
                            c.Id,
                            c.Name
                        }).ToList(),
                    b.Descricao
                })
                .ToListAsync();

        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proposta>> GetProposta(Guid id)
        {
            if (_context.Propostas == null)
            {
                return NotFound();
            }

            var proposta = await _context.Propostas.FindAsync(id);

            if (proposta == null)
            {
                return NotFound();
            }

            return proposta;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(Guid id, Proposta proposta)
        {
            if (id != proposta.Id)
            {
                return BadRequest();
            }

            _context.Entry(proposta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropostaExists(id))
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
        public async Task<ActionResult<Proposta>> PostBook(Proposta proposta)
        {
            if (_context.Propostas == null)
            {
                return Problem("Entity set 'ES2DbContext.Proposta'  is null.");
            }

            _context.Propostas.Add(proposta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProposta", new { id = proposta.Id }, proposta);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProposta(Guid id)
        {
            if (_context.Propostas == null)
            {
                return NotFound();
            }

            var proposta = await _context.Propostas.FindAsync(id);
            if (proposta == null)
            {
                return NotFound();
            }

            _context.Propostas.Remove(proposta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropostaExists(Guid id)
        {
            return (_context.Propostas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}