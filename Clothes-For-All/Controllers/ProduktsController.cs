using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clothes_For_All.Models;

namespace Clothes_For_All.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktsController : ControllerBase
    {
        private readonly CfaContext _context;

        public ProduktsController(CfaContext context)
        {
            _context = context;
        }

        // GET: api/Produkts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produkt>>> GetProdukts()
        {
          if (_context.Produkts == null)
          {
              return NotFound();
          }
            return await _context.Produkts.ToListAsync();
        }

        // GET: api/Produkts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produkt>> GetProdukt(long id)
        {
          if (_context.Produkts == null)
          {
              return NotFound();
          }
            var produkt = await _context.Produkts.FindAsync(id);

            if (produkt == null)
            {
                return NotFound();
            }

            return produkt;
        }

        // PUT: api/Produkts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdukt(long id, Produkt produkt)
        {
            if (id != produkt.Id)
            {
                return BadRequest();
            }

            _context.Entry(produkt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduktExists(id))
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

        // POST: api/Produkts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Produkt>> PostProdukt(Produkt produkt)
        {
          if (_context.Produkts == null)
          {
              return Problem("Entity set 'CfaContext.Produkts'  is null.");
          }
            _context.Produkts.Add(produkt);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdukt), new { id = produkt.Id }, produkt);
        }

        // DELETE: api/Produkts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdukt(long id)
        {
            if (_context.Produkts == null)
            {
                return NotFound();
            }
            var produkt = await _context.Produkts.FindAsync(id);
            if (produkt == null)
            {
                return NotFound();
            }

            _context.Produkts.Remove(produkt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProduktExists(long id)
        {
            return (_context.Produkts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
