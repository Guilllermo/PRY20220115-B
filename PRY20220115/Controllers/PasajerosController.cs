using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRY20220115.Data;
using PRY20220115.Models;

namespace PRY20220115.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasajerosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PasajerosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Pasajeros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pasajero>>> GetPasajeros()
        {
          if (_context.Pasajeros == null)
          {
              return NotFound();
          }
            return await _context.Pasajeros.ToListAsync();
        }

        // GET: api/Pasajeros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pasajero>> GetPasajero(int id)
        {
          if (_context.Pasajeros == null)
          {
              return NotFound();
          }
            var pasajero = await _context.Pasajeros.FindAsync(id);

            if (pasajero == null)
            {
                return NotFound();
            }

            return pasajero;
        }

        // PUT: api/Pasajeros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPasajero(int id, Pasajero pasajero)
        {
            if (id != pasajero.Id)
            {
                return BadRequest();
            }

            _context.Entry(pasajero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasajeroExists(id))
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

        // POST: api/Pasajeros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pasajero>> PostPasajero(Pasajero pasajero)
        {
          if (_context.Pasajeros == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Pasajeros'  is null.");
          }
            _context.Pasajeros.Add(pasajero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPasajero", new { id = pasajero.Id }, pasajero);
        }

        // DELETE: api/Pasajeros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePasajero(int id)
        {
            if (_context.Pasajeros == null)
            {
                return NotFound();
            }
            var pasajero = await _context.Pasajeros.FindAsync(id);
            if (pasajero == null)
            {
                return NotFound();
            }

            _context.Pasajeros.Remove(pasajero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PasajeroExists(int id)
        {
            return (_context.Pasajeros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
