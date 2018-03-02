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
    public class ResursaValoareFlat
    {
        public ResursaValoareFlat()
        {

        }
        public ResursaValoareFlat(ResursaValoare rv)
        {
            this.Id = rv.IdresursaDict;
            this.Nume = rv.IdresursaDictNavigation.Nume;
            this.Valoare = rv.IdresursaDictNavigation.Valoare;
            this.TableValue = rv.IdresursaDictNavigation.TableValue;
            this.ValoareData = rv.Valoare;
        }
        public long Id { get; set; }
        public string Nume { get; set; }
        public string Valoare { get; set; }
        public string TableValue { get; set; }
        public string ValoareData { get; set; }
    }
    [Produces("application/json")]
    [Route("api/ResursaValoares")]
    public class ResursaValoaresController : Controller
    {




        // GET: api/ResursaValoares
        [HttpGet]
        public async Task<IEnumerable<ResursaValoareFlat>> GetResursaValoare([FromServices]CatalogROContext context, Guid id)
        {
            var data = await context.ResursaValoare.Where(rv=>rv.UniqueId==id)
            .Select(rv => new ResursaValoareFlat()
            {
                Id = rv.IdresursaDict,
                Nume = rv.IdresursaDictNavigation.Nume,
                Valoare = rv.IdresursaDictNavigation.Valoare,
                TableValue = rv.IdresursaDictNavigation.TableValue,
                ValoareData = rv.Valoare
            }).ToArrayAsync();
            return data;
        }
        // GET: api/ResursaValoares/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetResursaValoare([FromServices]CatalogROContext context,[FromRoute] long id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var resursaValoare = await context.ResursaValoare.SingleOrDefaultAsync(m => m.IdresursaDict == id);

        //    if (resursaValoare == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(resursaValoare);
        //}

        // PUT: api/ResursaValoares/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutResursaValoare([FromRoute] long id, [FromBody] ResursaValoare resursaValoare)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != resursaValoare.IdresursaDict)
        //    {
        //        return BadRequest();
        //    }

        //    context.Entry(resursaValoare).State = EntityState.Modified;

        //    try
        //    {
        //        await context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ResursaValoareExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/ResursaValoares
        [HttpPost("{id}")]
        public async Task<IActionResult> PostResursaValoare([FromServices]CatalogROContext context, string id,[FromBody] ResursaValoareFlat[] resursaValoares )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var ids = resursaValoares.Select(it => it.Id).ToArray();
            var rds = await context.ResursaDict.Where(rd => ids.Contains(rd.Id)).ToArrayAsync();
            if(rds.Length!= ids.Length)
            {
                throw new ArgumentException($"NOT same number of arguments {rds.Length} {ids.Length}");
            }
            var names = rds.Select(it => it.Nume).Distinct().ToArray();
            if(names?.Length!= 1)
            {
                throw new ArgumentException($"multiple names");
            }
            if(names[0]!= id)
            {
                throw new ArgumentException($"not correct name");
            }
            var ri = new ResursaInregistrare();
            ri.Identuziast = 1;
            ri.UniqueId = Guid.NewGuid();
            ri.DataIntroducere = DateTime.UtcNow;
            context.ResursaInregistrare.Add(ri);
            await context.SaveChangesAsync();
            foreach (var rv in resursaValoares)
            {
                var rvNew = new ResursaValoare();
                rvNew.IdresursaDict = rv.Id;
                rvNew.UniqueId = ri.UniqueId;
                rvNew.Valoare = rv.ValoareData;
                context.Add(rvNew);
            }
            await context.SaveChangesAsync();
            return CreatedAtAction("GetResursaValoare", new { id = ri.UniqueId});
        }

        // DELETE: api/ResursaValoares/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteResursaValoare([FromRoute] long id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var resursaValoare = await context.ResursaValoare.SingleOrDefaultAsync(m => m.IdresursaDict == id);
        //    if (resursaValoare == null)
        //    {
        //        return NotFound();
        //    }

        //    context.ResursaValoare.Remove(resursaValoare);
        //    await context.SaveChangesAsync();

        //    return Ok(resursaValoare);
        //}

        //private bool ResursaValoareExists(long id)
        //{
        //    return context.ResursaValoare.Any(e => e.IdresursaDict == id);
        //}
    }
}