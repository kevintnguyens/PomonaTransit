using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PomonaTransit;

namespace PomonaTransit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripOfferingsController : ControllerBase
    {
        private readonly TransitContext _context;

        public TripOfferingsController(TransitContext context)
        {
            _context = context;
        }

        // GET: api/TripOfferings
        [HttpGet]
        public IEnumerable<TripOffering> GettripOfferings()
        {
            return _context.tripOfferings;
        }

        // GET: api/TripOfferings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripOffering([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tripOffering = await _context.tripOfferings.FindAsync(id);

            if (tripOffering == null)
            {
                return NotFound();
            }

            return Ok(tripOffering);
        }

        // PUT: api/TripOfferings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTripOffering([FromRoute] int id, [FromBody] TripOffering tripOffering)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tripOffering.ID)
            {
                return BadRequest();
            }

            _context.Entry(tripOffering).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripOfferingExists(id))
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

        // POST: api/TripOfferings
        [HttpPost]
        public async Task<IActionResult> PostTripOffering([FromBody] TripOffering tripOffering)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.tripOfferings.Add(tripOffering);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTripOffering", new { id = tripOffering.ID }, tripOffering);
        }

        // DELETE: api/TripOfferings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTripOffering([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tripOffering = await _context.tripOfferings.FindAsync(id);
            if (tripOffering == null)
            {
                return NotFound();
            }

            _context.tripOfferings.Remove(tripOffering);
            await _context.SaveChangesAsync();

            return Ok(tripOffering);
        }

        private bool TripOfferingExists(int id)
        {
            return _context.tripOfferings.Any(e => e.ID == id);
        }
    }
}