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
    public class CategoriesController : Controller
    {
        private readonly CatalogROContext _context;

        public CategoriesController(CatalogROContext context)
        {
            _context = context;
        }
        private void DestroyObjectsRelationship(Categorie c)
        {
            c.InverseParentNavigation = null;
            c.ParentNavigation = null;
        }
        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Categorie> GetCategorie()
        {
            var cat = _context.Categorie.ToList();
            cat.ForEach(it => DestroyObjectsRelationship(it));
            return _context.Categorie;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategorie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categorie = await _context.Categorie.SingleOrDefaultAsync(m => m.Idcategorie == id);

            if (categorie == null)
            {
                return NotFound();
            }
            DestroyObjectsRelationship(categorie);
            return Ok(categorie);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorie([FromRoute] int id, [FromBody] Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categorie.Idcategorie)
            {
                return BadRequest();
            }

            _context.Entry(categorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(id))
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

        // POST: api/Categories
        [HttpPost]
        public async Task<IActionResult> PostCategorie([FromBody] Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Categorie.Add(categorie);
            await _context.SaveChangesAsync();
            DestroyObjectsRelationship(categorie);
            return CreatedAtAction("GetCategorie", new { id = categorie.Idcategorie }, categorie);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categorie = await _context.Categorie.SingleOrDefaultAsync(m => m.Idcategorie == id);
            if (categorie == null)
            {
                return NotFound();
            }

            _context.Categorie.Remove(categorie);
            await _context.SaveChangesAsync();

            return Ok(categorie);
        }

        private bool CategorieExists(int id)
        {
            return _context.Categorie.Any(e => e.Idcategorie == id);
        }
    }
}