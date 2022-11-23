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
    public class PunishmentTypeController : ControllerBase
    {
        private readonly dotnetuasContext _context;

        public PunishmentTypeController(dotnetuasContext context)
        {
            _context = context;
        }

        // GET: api/PunishmentType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetPunishmentType>>> GetAspNetPunishmentTypes()
        {
          if (_context.AspNetPunishmentTypes == null)
          {
              return NotFound();
          }
            return await _context.AspNetPunishmentTypes.ToListAsync();
        }

        // GET: api/PunishmentType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetPunishmentType>> GetAspNetPunishmentType(int id)
        {
          if (_context.AspNetPunishmentTypes == null)
          {
              return NotFound();
          }
            var aspNetPunishmentType = await _context.AspNetPunishmentTypes.FindAsync(id);

            if (aspNetPunishmentType == null)
            {
                return NotFound();
            }

            return aspNetPunishmentType;
        }

        // PUT: api/PunishmentType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetPunishmentType(int id, AspNetPunishmentType aspNetPunishmentType)
        {
            if (id != aspNetPunishmentType.Id)
            {
                return BadRequest();
            }

            _context.Entry(aspNetPunishmentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetPunishmentTypeExists(id))
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

        // POST: api/PunishmentType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AspNetPunishmentType>> PostAspNetPunishmentType(AspNetPunishmentType aspNetPunishmentType)
        {
          if (_context.AspNetPunishmentTypes == null)
          {
              return Problem("Entity set 'dotnetuasContext.AspNetPunishmentTypes'  is null.");
          }
            _context.AspNetPunishmentTypes.Add(aspNetPunishmentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAspNetPunishmentType", new { id = aspNetPunishmentType.Id }, aspNetPunishmentType);
        }

        // DELETE: api/PunishmentType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspNetPunishmentType(int id)
        {
            if (_context.AspNetPunishmentTypes == null)
            {
                return NotFound();
            }
            var aspNetPunishmentType = await _context.AspNetPunishmentTypes.FindAsync(id);
            if (aspNetPunishmentType == null)
            {
                return NotFound();
            }

            _context.AspNetPunishmentTypes.Remove(aspNetPunishmentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AspNetPunishmentTypeExists(int id)
        {
            return (_context.AspNetPunishmentTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
