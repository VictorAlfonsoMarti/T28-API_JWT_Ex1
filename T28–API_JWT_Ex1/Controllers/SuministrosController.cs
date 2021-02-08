using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T28_API_JWT_Ex1.Models;

namespace T28_API_JWT_Ex1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SuministrosController : ControllerBase
    {
        private readonly T28API_JWT_Ex1Context _context;

        public SuministrosController(T28API_JWT_Ex1Context context)
        {
            _context = context;
        }

        // GET: api/Suministros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suministra>>> GetSuministra()
        {
            return await _context.Suministra.ToListAsync();
        }

        // GET: api/Suministros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Suministra>> GetSuministra(int id)
        {
            var suministra = await _context.Suministra.FindAsync(id);

            if (suministra == null)
            {
                return NotFound();
            }

            return suministra;
        }

        // PUT: api/Suministros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuministra(int id, Suministra suministra)
        {
            if (id != suministra.CodigoPieza)
            {
                return BadRequest();
            }

            _context.Entry(suministra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuministraExists(id))
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

        // POST: api/Suministros
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Suministra>> PostSuministra(Suministra suministra)
        {
            _context.Suministra.Add(suministra);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SuministraExists(suministra.CodigoPieza))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSuministra", new { id = suministra.CodigoPieza }, suministra);
        }

        // DELETE: api/Suministros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Suministra>> DeleteSuministra(int id)
        {
            var suministra = await _context.Suministra.FindAsync(id);
            if (suministra == null)
            {
                return NotFound();
            }

            _context.Suministra.Remove(suministra);
            await _context.SaveChangesAsync();

            return suministra;
        }

        private bool SuministraExists(int id)
        {
            return _context.Suministra.Any(e => e.CodigoPieza == id);
        }
    }
}
