using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Domain;
using Server.Persistence;
using Server.Application.Services;
using Server.Application.Services.DTOs;

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

        [HttpGet("all")]
        public IEnumerable<ShipmentDTO> GetShipment()
        {
            var shipments = from s in _unit.ShipmentRepository.GetAll()
                            select new ShipmentDTO()
                            {
                                Id = s.Id,
                                Weight = s.Weight,
                                Precautions = s.Precautions,
                                EstimatedArrivalDate = s.EstimatedArrivalDate
                            };
            return shipments;
          
        }

        [HttpGet("/byId/{id}")]
        public ActionResult<ShipmentDTO> GetShipment(Guid id)
        {
            var s = _unit.ShipmentRepository.Get(id);

            if (s == null)
            {
                return NotFound();
            }
            ShipmentDTO shipmentDTO = new ShipmentDTO {Id = s.Id,
                                Weight = s.Weight,
                                Precautions = s.Precautions,
                                EstimatedArrivalDate = s.EstimatedArrivalDate };

            return shipmentDTO;
        }

        [HttpPut("update/{id}")]
        public IActionResult PutShipment(Guid id, ShipmentDTO shipmentDTO)
        {
            if (id != shipmentDTO.Id)
            {
                return BadRequest();
            }
            Shipment s = _unit.ShipmentRepository.Get(id);
            s.ArrivalDate = shipmentDTO.ArrivalDate;
            s.Weight = shipmentDTO.Weight;
            s.Precautions = shipmentDTO.Precautions;
            s.States = shipmentDTO.States;
            _unit.Context.Entry(s).State = EntityState.Modified;
            try
            {
                _unit.Complete();
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

        [HttpPost("create")]
        public ActionResult<Shipment> PostShipment(ShipmentDTO shipmentDTO)
        {
            Shipment s = new Shipment
            {
                Id = Guid.NewGuid(),
                EstimatedArrivalDate = shipmentDTO.EstimatedArrivalDate,
                Precautions = shipmentDTO.Precautions,
                Weight = shipmentDTO.Weight,
            };
            _unit.ShipmentRepository.Add(s);
            _unit.Complete();

            return CreatedAtAction("GetShipment", new { id = s.Id }, s);
        }

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

        private bool ShipmentExists(Guid id) =>
             _unit.ShipmentRepository.GetAll().Any(s => s.Id == id);
    }
}
