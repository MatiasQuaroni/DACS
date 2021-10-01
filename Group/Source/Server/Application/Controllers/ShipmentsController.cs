using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server;
using Server.Persistence.EF;
using Server.Persistence.EF.Repositories;

namespace Server.Application.Controllers
{
    [Route("Shipments")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private UnitOfWork _unit;
        public ShipmentsController(RoadsDbContext context)
        {
            _unit = new UnitOfWork(context);  
        }

        // GET: api/Shipments/all
        [HttpGet("all")]
        public IEnumerable<Shipment> GetShipment()
        {
            return _unit.ShipmentRepository.GetAll();
        }

        // GET: api/Shipments/byId/id
        [HttpGet("/byId/{id}")]
        public ActionResult<Shipment> GetShipment(Guid id)
        {
            var shipment = _unit.ShipmentRepository.Get(id);

            if (shipment == null)
            {
                return NotFound();
            }

            return shipment;
        }

       /*  // PUT: api/Shipments/update/id
        [HttpPut("update/{id}")]
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
        } */

        // POST: api/Shipments/create
        [HttpPost("create")]
        public ActionResult<Shipment> PostShipment(Shipment shipment)
        {
            _unit.ShipmentRepository.Add(shipment);
            _unit.Complete();

            return CreatedAtAction("GetShipment", new { id = shipment.Id }, shipment);
        }

        // DELETE: api/Shipments/delete/id
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteShipment(Guid id)
        {
            var shipment = _unit.ShipmentRepository.Get(id);
            if (shipment == null)
            {
                return NotFound();
            }

            _unit.ShipmentRepository.Remove(shipment);
            _unit.Complete();

            return NoContent();
        }

       // private bool ShipmentExists(Guid id)
       // {
       //     return _unit.ShipmentRepository.(e => e.Id == id);
       // }
    }
}
