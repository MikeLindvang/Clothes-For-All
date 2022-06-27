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
    public class ProduktTypesController : ControllerBase
    {
        private readonly CfaContext _context;

        public ProduktTypesController(CfaContext context)
        {
            _context = context;
        }

        // GET: api/ProduktTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProduktType>>> GetProduktTypes()
        {
          if (_context.ProduktTypes == null)
          {
              return NotFound();
          }
            return await _context.ProduktTypes.ToListAsync();
        }

        // GET: api/ProduktTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProduktType>> GetProduktType(long id)
        {
          if (_context.ProduktTypes == null)
          {
              return NotFound();
          }
            var produktType = await _context.ProduktTypes.FindAsync(id);

            if (produktType == null)
            {
                return NotFound();
            }

            return produktType;
        }

        // PUT: api/ProduktTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduktType(long id, ProduktType produktType)
        {
            if (id != produktType.Id)
            {
                return BadRequest();
            }

            _context.Entry(produktType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduktTypeExists(id))
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

        // POST: api/ProduktTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProduktType>> PostProduktType(ProduktType produktType)
        {
          if (_context.ProduktTypes == null)
          {
              return Problem("Entity set 'CfaContext.ProduktTypes'  is null.");
          }
            _context.ProduktTypes.Add(produktType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduktType), new { id = produktType.Id }, produktType);
        }

        // DELETE: api/ProduktTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduktType(long id)
        {
            if (_context.ProduktTypes == null)
            {
                return NotFound();
            }
            var produktType = await _context.ProduktTypes.FindAsync(id);
            if (produktType == null)
            {
                return NotFound();
            }

            _context.ProduktTypes.Remove(produktType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProduktTypeExists(long id)
        {
            return (_context.ProduktTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
