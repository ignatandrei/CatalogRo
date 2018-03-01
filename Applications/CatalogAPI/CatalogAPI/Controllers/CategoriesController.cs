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
       

        // POST: api/Categories
        [HttpPost]
        public async Task<IActionResult> PostCategorie([FromServices]CatalogROContext context, [FromBody] Categorie[] categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (categories?.Length == 0)
            {
                return Ok("no data sent - no data saved");
            }
            var arrID = categories.Where(it => it.Idcategorie!= 0).Select(it => it.Idcategorie).ToArray();
            var formatNew = await context.Categorie.Where(m => arrID.Contains(m.Idcategorie)).ToArrayAsync();

            foreach (var item in formatNew)
            {
                var existing = categories.First(it => it.Idcategorie == item.Idcategorie);
                item.EnglishName = existing.EnglishName;
                item.Nume = existing.Nume;
                item.Parent = existing.Parent;
            }
            var newItems = categories.Where(it => it.Idcategorie == 0).ToArray();
            if (newItems.Length > 0)
                context.Categorie.AddRange(newItems);


            await context.SaveChangesAsync();
            categories.ToList().ForEach(DestroyObjectsRelationship);
            return CreatedAtAction("POSTCategorie", categories);

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