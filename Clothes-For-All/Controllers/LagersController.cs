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
    public class LagersController : ControllerBase
    {
        private readonly CfaContext _context;

        public LagersController(CfaContext context)
        {
            _context = context;
        }

        // GET: api/Lagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lager>>> GetLager()
        {
          if (_context.Lager == null)
          {
              return NotFound();
          }
            return await _context.Lager.ToListAsync();
        }

        // GET: api/Lagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lager>> GetLager(long id)
        {
          if (_context.Lager == null)
          {
              return NotFound();
          }
            var lager = await _context.Lager.FindAsync(id);

            if (lager == null)
            {
                return NotFound();
            }

            return lager;
        }

        // PUT: api/Lagers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLager(long id, Lager lager)
        {
            if (id != lager.id)
            {
                return BadRequest();
            }

            _context.Entry(lager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LagerExists(id))
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

        // POST: api/Lagers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lager>> PostLager(Lager lager)
        {
          if (_context.Lager == null)
          {
              return Problem("Entity set 'CfaContext.Lager'  is null.");
          }
            _context.Lager.Add(lager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLager", new { id = lager.id }, lager);
        }

        // DELETE: api/Lagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLager(long id)
        {
            if (_context.Lager == null)
            {
                return NotFound();
            }
            var lager = await _context.Lager.FindAsync(id);
            if (lager == null)
            {
                return NotFound();
            }

            _context.Lager.Remove(lager);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LagerExists(long id)
        {
            return (_context.Lager?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
