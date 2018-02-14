using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogDAL.Models;

namespace CatalogAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Formats")]
    public class FormatsController : Controller
    {
        private readonly CatalogROContext _context;

        public FormatsController(CatalogROContext context)
        {
            _context = context;
        }

        // GET: api/Formats
        [HttpGet]
        public IEnumerable<Format> GetFormat()
        {
            return _context.Format;
        }

        // GET: api/Formats/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFormat([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var format = await _context.Format.SingleOrDefaultAsync(m => m.Idformat == id);

            if (format == null)
            {
                return NotFound();
            }

            return Ok(format);
        }

        // PUT: api/Formats/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormat([FromRoute] int id, [FromBody] Format format)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != format.Idformat)
            {
                return BadRequest();
            }

            _context.Entry(format).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormatExists(id))
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

        // POST: api/Formats
        [HttpPost]
        public async Task<IActionResult> PostFormat([FromBody] Format format)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Format.Add(format);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormat", new { id = format.Idformat }, format);
        }

        // DELETE: api/Formats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormat([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var format = await _context.Format.SingleOrDefaultAsync(m => m.Idformat == id);
            if (format == null)
            {
                return NotFound();
            }

            _context.Format.Remove(format);
            await _context.SaveChangesAsync();

            return Ok(format);
        }

        private bool FormatExists(int id)
        {
            return _context.Format.Any(e => e.Idformat == id);
        }
    }
}