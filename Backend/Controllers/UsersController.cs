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
    public class UsersController : ControllerBase
    {
        private readonly ES2DbContext _context;

        public UsersController(ES2DbContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            return await _context
                .Users.Select(a => new
                {
                    a.Id,
                    a.PrHora,
                    a.Name,
                    a.Email,
                    a.Country,
                    Experiences = _context.Experiences
                        .Where(e => e.Id == a.IdExperience)
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
                    }).ToList()
                }).ToListAsync();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetUser(Guid id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            return await _context.Users
                .Where(a => a.Id == id)
                .Select(a => new
                {
                    a.Id,
                    a.PrHora,
                    a.Name,
                    a.Email,
                    a.Country,
                    User_Skill = _context.UserSkills
                        .Where(c => c.IdUser == a.Id)
                        .Select(c => new
                        {
                            c.Id,
                            c.AnoXp,
                            c.IdSkill,
                            c.IdUser,
                            Skill = _context.Skills
                                .Where(u => u.Id == c.IdSkill)
                                .Select(u => new
                                {
                                    u.Id,
                                    u.Name,
                                    u.Area
                                }).ToList()
                        }).ToList()
                }).ToListAsync();
                            
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(Guid id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostAuthor(User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ES2DbContext.Users'  is null.");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(Guid id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}