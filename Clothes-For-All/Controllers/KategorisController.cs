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
    public class KategorisController : ControllerBase
    {
        private readonly CfaContext _context;

        public KategorisController(CfaContext context)
        {
            _context = context;
        }

        // GET: api/Kategoris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kategori>>> GetKategoris()
        {
          if (_context.Kategoris == null)
          {
              return NotFound();
          }
            return await _context.Kategoris.ToListAsync();
        }

        // GET: api/Kategoris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kategori>> GetKategori(long id)
        {
          if (_context.Kategoris == null)
          {
              return NotFound();
          }
            var kategori = await _context.Kategoris.FindAsync(id);

            if (kategori == null)
            {
                return NotFound();
            }

            return kategori;
        }

        // PUT: api/Kategoris/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKategori(long id, Kategori kategori)
        {
            if (id != kategori.Id)
            {
                return BadRequest();
            }

            _context.Entry(kategori).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategoriExists(id))
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

        // POST: api/Kategoris
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kategori>> PostKategori(Kategori kategori)
        {
          if (_context.Kategoris == null)
          {
              return Problem("Entity set 'CfaContext.Kategoris'  is null.");
          }
            _context.Kategoris.Add(kategori);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKategori), new { id = kategori.Id }, kategori);
        }

        // DELETE: api/Kategoris/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKategori(long id)
        {
            if (_context.Kategoris == null)
            {
                return NotFound();
            }
            var kategori = await _context.Kategoris.FindAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }

            _context.Kategoris.Remove(kategori);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KategoriExists(long id)
        {
            return (_context.Kategoris?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
