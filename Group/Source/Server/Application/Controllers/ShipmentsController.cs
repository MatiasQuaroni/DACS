using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server;
using Server.Persistence.EF;

namespace Server.Application.Controllers
{
    [Route("Shipments")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly RoadsDbContext _context;

        public ShipmentsController(RoadsDbContext context)
        {
            _context = context;
        }

        // GET: api/Shipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipment()
        {
            return await _context.Shipment.ToListAsync();
        }

        // GET: api/Shipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipment>> GetShipment(Guid id)
        {
            var shipment = await _context.Shipment.FindAsync(id);

            if (shipment == null)
            {
                return NotFound();
            }

            return shipment;
        }

        // PUT: api/Shipments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipment(Guid id, Shipment shipment)
        {
            if (id != shipment.Id)
            {
                return BadRequest();
            }

            _context.Entry(shipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipmentExists(id))
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

        // POST: api/Shipments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shipment>> PostShipment(Shipment shipment)
        {
            _context.Shipment.Add(shipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipment", new { id = shipment.Id }, shipment);
        }

        // DELETE: api/Shipments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipment(Guid id)
        {
            var shipment = await _context.Shipment.FindAsync(id);
            if (shipment == null)
            {
                return NotFound();
            }

            _context.Shipment.Remove(shipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShipmentExists(Guid id)
        {
            return _context.Shipment.Any(e => e.Id == id);
        }
    }
}
