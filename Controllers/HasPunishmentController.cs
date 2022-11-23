using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcwithlogin.Models;

namespace mvcwithlogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HasPunishmentController : ControllerBase
    {
        private readonly dotnetuasContext _context;

        public HasPunishmentController(dotnetuasContext context)
        {
            _context = context;
        }

        // GET: api/HasPunishment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetHasPunishment>>> GetAspNetHasPunishments()
        {
          if (_context.AspNetHasPunishments == null)
          {
              return NotFound();
          }
            return await _context.AspNetHasPunishments.ToListAsync();
        }

        // GET: api/HasPunishment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetHasPunishment>> GetAspNetHasPunishment(string id)
        {
          if (_context.AspNetHasPunishments == null)
          {
              return NotFound();
          }
            var aspNetHasPunishment = await _context.AspNetHasPunishments.FindAsync(id);

            if (aspNetHasPunishment == null)
            {
                return NotFound();
            }

            return aspNetHasPunishment;
        }

        // PUT: api/HasPunishment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetHasPunishment(string id, AspNetHasPunishment aspNetHasPunishment)
        {
            if (id != aspNetHasPunishment.UserId)
            {
                return BadRequest();
            }

            _context.Entry(aspNetHasPunishment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetHasPunishmentExists(id))
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

        // POST: api/HasPunishment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AspNetHasPunishment>> PostAspNetHasPunishment(AspNetHasPunishment aspNetHasPunishment)
        {
          if (_context.AspNetHasPunishments == null)
          {
              return Problem("Entity set 'dotnetuasContext.AspNetHasPunishments'  is null.");
          }
            _context.AspNetHasPunishments.Add(aspNetHasPunishment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetHasPunishmentExists(aspNetHasPunishment.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAspNetHasPunishment", new { id = aspNetHasPunishment.UserId }, aspNetHasPunishment);
        }

        // DELETE: api/HasPunishment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspNetHasPunishment(string id)
        {
            if (_context.AspNetHasPunishments == null)
            {
                return NotFound();
            }
            var aspNetHasPunishment = await _context.AspNetHasPunishments.FindAsync(id);
            if (aspNetHasPunishment == null)
            {
                return NotFound();
            }

            _context.AspNetHasPunishments.Remove(aspNetHasPunishment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AspNetHasPunishmentExists(string id)
        {
            return (_context.AspNetHasPunishments?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
