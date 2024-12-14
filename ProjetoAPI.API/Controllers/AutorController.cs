using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Domain.Entities;
using ProjetoAPI.Infrastructure;
using System;

namespace ProjetoAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        
        private readonly ApplicationDbContext _context;

        public AutorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/authors
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _context.Autor.ToListAsync();
            return Ok(authors);
        }

        // GET: api/authors/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var author = await _context.Autor.FindAsync(id);
            if (author == null)
                return NotFound();

            return Ok(author);
        }

        // POST: api/authors
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Autor author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Autor.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
        }

        // PUT: api/authors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Autor updatedAuthor)
        {
            if (id != updatedAuthor.Id)
                return BadRequest();

            _context.Entry(updatedAuthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Autor.Any(e => e.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/authors/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var author = await _context.Autor.FindAsync(id);
            if (author == null)
                return NotFound();

            _context.Autor.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
