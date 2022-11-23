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
    public class PlayerDetailController : ControllerBase
    {
        private readonly dotnetuasContext _context;

        public PlayerDetailController(dotnetuasContext context)
        {
            _context = context;
        }

        // GET: api/PlayerDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetPlayerDetail>>> GetAspNetPlayerDetails()
        {
          if (_context.AspNetPlayerDetails == null)
          {
              return NotFound();
          }
            return await _context.AspNetPlayerDetails.ToListAsync();
        }

        // GET: api/PlayerDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetPlayerDetail>> GetAspNetPlayerDetail(string id)
        {
          if (_context.AspNetPlayerDetails == null)
          {
              return NotFound();
          }
            var aspNetPlayerDetail = await _context.AspNetPlayerDetails.FindAsync(id);

            if (aspNetPlayerDetail == null)
            {
                return NotFound();
            }

            return aspNetPlayerDetail;
        }

        // PUT: api/PlayerDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetPlayerDetail(string id, AspNetPlayerDetail aspNetPlayerDetail)
        {
            if (id != aspNetPlayerDetail.UserId)
            {
                return BadRequest();
            }

            _context.Entry(aspNetPlayerDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetPlayerDetailExists(id))
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

        // POST: api/PlayerDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AspNetPlayerDetail>> PostAspNetPlayerDetail(AspNetPlayerDetail aspNetPlayerDetail)
        {
          if (_context.AspNetPlayerDetails == null)
          {
              return Problem("Entity set 'dotnetuasContext.AspNetPlayerDetails'  is null.");
          }
            _context.AspNetPlayerDetails.Add(aspNetPlayerDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetPlayerDetailExists(aspNetPlayerDetail.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAspNetPlayerDetail", new { id = aspNetPlayerDetail.UserId }, aspNetPlayerDetail);
        }

        // DELETE: api/PlayerDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspNetPlayerDetail(string id)
        {
            if (_context.AspNetPlayerDetails == null)
            {
                return NotFound();
            }
            var aspNetPlayerDetail = await _context.AspNetPlayerDetails.FindAsync(id);
            if (aspNetPlayerDetail == null)
            {
                return NotFound();
            }

            _context.AspNetPlayerDetails.Remove(aspNetPlayerDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AspNetPlayerDetailExists(string id)
        {
            return (_context.AspNetPlayerDetails?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
