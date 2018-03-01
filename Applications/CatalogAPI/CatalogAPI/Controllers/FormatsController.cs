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
    [Route("api/[controller]")]
    public class FormatsController : Controller
    {
        

        public FormatsController()
        {
            
        }

        // GET: api/Formats
        [HttpGet]
        public IEnumerable<Format> GetFormat([FromServices]CatalogROContext context)
        {
            return context.Format;
        }

        // GET: api/Formats/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFormat([FromServices]CatalogROContext context,[FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var format = await context.Format.SingleOrDefaultAsync(m => m.Idformat == id);

            if (format == null)
            {
                return NotFound($"cannot found format with id :{id}");
            }

            return Ok(format);
        }

        // PUT: api/Formats/5
        
        // POST: api/Formats
        [HttpPost]
        public async Task<IActionResult> PostFormat([FromServices]CatalogROContext context,[FromBody] Format[] formats)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(formats?.Length == 0)
            {
                return Ok("no data sent - no data saved");
            }
            var arrID = formats.Where(it => it.Idformat != 0).Select(it => it.Idformat).ToArray();
            var formatNew = await context.Format.Where(m => arrID.Contains(m.Idformat)).ToArrayAsync();

            foreach(var item in formatNew)
            {
                var existing = formats.First(it => it.Idformat == item.Idformat);
                item.EnglishName = existing.EnglishName;
                item.Nume = existing.Nume;
            }
            var newItems = formats.Where(it => it.Idformat == 0).ToArray();
            if (newItems.Length > 0)
                context.Format.AddRange(newItems);
                
            
            await context.SaveChangesAsync();

            return CreatedAtAction("GetFormat", formats);
        }

        // DELETE: api/Formats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormat([FromServices]CatalogROContext context,[FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var format = await context.Format.SingleOrDefaultAsync(m => m.Idformat == id);
            if (format == null)
            {
                return NotFound($"not found format with id {id}");
            }

            context.Format.Remove(format);
            await context.SaveChangesAsync();

            return Ok(format);
        }

        private bool FormatExists(CatalogROContext context,int id)
        {
            return context.Format.Any(e => e.Idformat == id);
        }
    }
}