using System;
using System.Collections.Generic;
using System.Linq;
using Server.Domain;
using Server.Application.Services.DataTransfer;
using Server.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Server.Application.ExternalAPIs;
using System.Threading.Tasks;

namespace Server.Application.Services
{
    public interface IShipmentsServices
    {
        public IEnumerable<Shipment> GetAllShipments();
        public Shipment GetShipment(Guid id);
        public Shipment GetShipmentByTrackingNumber(Guid trackingNumber);
        public IEnumerable<Shipment> GetShipmentByArrivalDate(string arrivalDate);
        public IEnumerable<Shipment> GetShipmentByStatus(string status);
        public IEnumerable<Shipment> GetShipmentByPostalCode(string postalCode); 
        public void UpdateShipment(Guid id, ShipmentData shipmentDTO);
        public void CreateShipment(ShipmentData shipmentDTO);
        public void DeleteShipment(Guid id);
        public void CreateItinerary(IList<Guid> shipmentsIDs);
    }

    public class ShipmentsServices : IShipmentsServices
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        private readonly Guid _baseLocationId = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");

        public ShipmentsServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unit = unitOfWork;
            _mapper = mapper;
            var baseLocation = _unit.LocationRepository.Get(_baseLocationId);
            if (baseLocation==null)
            {
                double[] baseCoordinates = {-58.2308008, -32.4962985 }; 
                _unit.LocationRepository.Add(new Location { 
                    Id = _baseLocationId,
                Address = "676 Ingeniero Pereyra",
                PostalCode = 3260,
                Type = 0,
                Coordinates = baseCoordinates,
                }
                );;
            }
            _unit.Complete();
        }
        public IEnumerable<Shipment> GetAllShipments()
        {
            var shipments = this._unit.ShipmentRepository.GetAllShipments();
            return shipments;
        }
        public Shipment GetShipment(Guid id)
        {
            var s = this._unit.ShipmentRepository.Get(id);
            return s;
        }
        public Shipment GetShipmentByTrackingNumber(Guid trackingNumber)
        {
            var s = this._unit.ShipmentRepository.GetByTrackingNumber(trackingNumber);
            return s;
        }
        public IEnumerable<Shipment> GetShipmentByArrivalDate(string arrivalDate)
        {
            var shipments = this._unit.ShipmentRepository.GetByArrivalDate(DateTime.Parse(arrivalDate));
            return shipments;
        }
        public IEnumerable<Shipment> GetShipmentByStatus(string status)
        {
            var shipments = this._unit.ShipmentRepository.GetByStatus(Int32.Parse(status));
            return shipments;
        }
        public IEnumerable<Shipment> GetShipmentByPostalCode(string postalCode)
        {
            var shipments = this._unit.ShipmentRepository.GetByPostalCode(Int32.Parse(postalCode));
            return shipments;
        }
        public void UpdateShipment(Guid id, ShipmentData shipmentDTO)
        {
            try
            {
                Shipment s = this._unit.ShipmentRepository.Get(id);
                s.EstimatedArrivalDate = shipmentDTO.EstimatedArrivalDate;
                s.Weight = shipmentDTO.Weight;
                s.Precautions = shipmentDTO.Precautions;

                s.Customer = _mapper.Map<CustomerInfo>(shipmentDTO.Customer);
                s.DestinationAddress = _mapper.Map<Location>(shipmentDTO.DestinationAddress);

                ShipmentStateData shipmentStateDTO = new ShipmentStateData
                {
                    CurrentState = shipmentDTO.Status,
                    ToDate = DateTime.Now
                };
                s.addNewState(shipmentDTO.Status);
                _unit.ShipmentRepository.Update(s);
                _unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        public void CreateShipment(ShipmentData shipmentDTO)
        {
            Shipment s = new Shipment();
            s.EstimatedArrivalDate = shipmentDTO.EstimatedArrivalDate;
            s.Precautions = shipmentDTO.Precautions;
            s.Weight = shipmentDTO.Weight;

            s.Customer.Dni = shipmentDTO.Customer.Dni;
            s.Customer.Email = shipmentDTO.Customer.Email;
            s.Customer.Name = shipmentDTO.Customer.Name;
            s.Customer.PhoneNumber = shipmentDTO.Customer.PhoneNumber;

            s.DestinationAddress.Address = shipmentDTO.DestinationAddress.Address;
            s.DestinationAddress.Number = shipmentDTO.DestinationAddress.Number;
            s.DestinationAddress.PostalCode = shipmentDTO.DestinationAddress.PostalCode;
            s.DestinationAddress.Floor = shipmentDTO.DestinationAddress.Floor;

            var rootObject = NominatimCoordinatesAPI.
                GetCoordinates(s.DestinationAddress.Address + " " + s.DestinationAddress.PostalCode.ToString());
            s.DestinationAddress.Coordinates = (rootObject.Result.Features[0].Geometry.Coordinates);
            _unit.ShipmentRepository.Add(s);
            _unit.Complete();
        }
        public void DeleteShipment(Guid id)
        {
            var shipment = _unit.ShipmentRepository.Get(id);
            _unit.ShipmentRepository.Remove(shipment);
            _unit.Complete();
        }
        public void CreateItinerary(IList<Guid> shipmentsIDs)
        {
            Itinerary itinerary = new Itinerary();
            List<Shipment> shipments = new List<Shipment>();
            List<double[]> coordinates = new List<double[]>();

            coordinates.Add(_unit.LocationRepository.Get(_baseLocationId).Coordinates);
            foreach (Guid id in shipmentsIDs)
            {
                shipments.Add(GetShipment(id));
            }
            foreach (Shipment s in shipments)
            {
                coordinates.Add(_unit.LocationRepository.Get(s.DestinationAddress.Id).Coordinates);
            }
            var distances = OpenStreetMapAPI.GetMatrix(coordinates).Result.distances;
            int length = distances.Count;
            itinerary = SetItineraryLegs(distances, shipments, itinerary, length-1, length, 0);
            _unit.ItineraryRepository.Add(itinerary);
            _unit.Complete();
        }

        protected bool ShipmentExists(Guid id)
        {
            return _unit.ShipmentRepository.GetAll().Any(s => s.Id == id);
        }

        public Itinerary SetItineraryLegs(IList<List<double>> distances, IList<Shipment> shipments, Itinerary itinerary, int matrixLength, int realLength, int fromLocation)
        {
            if (realLength == 1)
            { return itinerary; }
            else
            {
                double min = 9999999;
                int toLocation = 0;
                for (int i = 0; i < matrixLength+1; i++)
                {
                    if (distances[fromLocation][i] != 0 && distances[fromLocation][i] < min)
                    {
                        min = distances[fromLocation][i];
                        toLocation = i;
                    }
                    distances[fromLocation][i] = 0;
                    distances[i][fromLocation] = 0;
                }
                Leg leg = new Leg();
                if (fromLocation == 0)
                {
                    leg.StartLocation = _unit.LocationRepository.Get(_baseLocationId);
                }
                else
                {
                    leg.StartLocation = shipments[fromLocation-1].DestinationAddress;
                }

                leg.EndLocation = shipments[toLocation-1].DestinationAddress;
                itinerary.Legs.Add(leg);

               return SetItineraryLegs(distances, shipments, itinerary, matrixLength, realLength - 1, toLocation);
            }
        }




    }
}
