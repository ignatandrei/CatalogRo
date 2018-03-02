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
    [Route("api/ResursaDicts")]
    public class ResursaDictsController : Controller
    {
        

        // GET: api/ResursaDicts
        [HttpGet]
        public IEnumerable<ResursaDict> GetResursaDict([FromServices]CatalogROContext context)
        {
            return context.ResursaDict;
        }

        // GET: api/ResursaDicts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetResursaDict([FromServices]CatalogROContext context,[FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resursaDict = await context.ResursaDict.Where(m => m.Nume == id).ToArrayAsync();

            if (resursaDict == null)
            {
                return NotFound();
            }
            
            foreach(var item in resursaDict)
            {
                item.DestroyObjectsRelationship();
            }
            return Ok(resursaDict);
        }

        // PUT: api/ResursaDicts/5
        

        // POST: api/ResursaDicts
        [HttpPost]
        public async Task<IActionResult> PostResursaDict([FromServices]CatalogROContext context, [FromBody] ResursaDict resursaDict)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.ResursaDict.Add(resursaDict);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResursaDictExists(context,resursaDict.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetResursaDict", new { id = resursaDict.Id }, resursaDict);
        }

        // DELETE: api/ResursaDicts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResursaDict([FromServices]CatalogROContext context, [FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resursaDict = await context.ResursaDict.SingleOrDefaultAsync(m => m.Id == id);
            if (resursaDict == null)
            {
                return NotFound();
            }

            context.ResursaDict.Remove(resursaDict);
            await context.SaveChangesAsync();

            return Ok(resursaDict);
        }

        private bool ResursaDictExists(CatalogROContext context, long id)
        {
            return context.ResursaDict.Any(e => e.Id == id);
        }
    }
}