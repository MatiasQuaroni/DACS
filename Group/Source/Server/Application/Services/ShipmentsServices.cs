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
        public void UpdateShipment(Guid id, ShipmentUpdateData shipmentDTO);
        public void CreateShipment(ShipmentData shipmentDTO);
        public void DeleteShipment(Guid id);

        public void CreateItinerary(IList<Guid> shipmentsIDs);
        public void DeleteItinerary(Guid id);
        public Itinerary GetItinerary(Guid id);
        public IEnumerable<Itinerary> GetAllItineraries();

    }

    public class ShipmentsServices : IShipmentsServices
    {
        private readonly IUnitOfWork _unit;
        public ShipmentsServices(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
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
        public void UpdateShipment(Guid id, ShipmentUpdateData shipmentDTO)
        {
            Shipment s = this._unit.ShipmentRepository.Get(id);
            s.EstimatedArrivalDate = shipmentDTO.EstimatedArrivalDate;
            s.Weight = shipmentDTO.Weight;
            s.Precautions = shipmentDTO.Precautions;
            ShipmentStateData shipmentStateDTO = new ShipmentStateData
            {
                CurrentState = shipmentDTO.Status,
                ToDate = DateTime.Now
            };
            s.addNewState(shipmentDTO.Status);
            _unit.ShipmentRepository.Update(s);
            _unit.Complete();
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
            Guid baseLocation = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");
            Itinerary itinerary = new Itinerary();
            List<double[]> coordinates = new List<double[]>();

            coordinates.Add(_unit.LocationRepository.Get(baseLocation).Coordinates);
            foreach (Guid id in shipmentsIDs)
            {
                var shipment = GetShipment(id);
                itinerary.Shipments.Add(shipment);
                coordinates.Add(_unit.LocationRepository.Get(shipment.DestinationAddress.Id).Coordinates);
            }

            var distances = OpenStreetMapAPI.GetMatrix(coordinates).Result.distances;
            int length = distances.Count;
            itinerary = SetItineraryLegs(distances, itinerary.Shipments, itinerary, length - 1, length, 0, baseLocation);
            _unit.ItineraryRepository.Add(itinerary);
            _unit.Complete();
        }

        public void DeleteItinerary(Guid itineraryId)
        {
            var itinerary = _unit.ItineraryRepository.Get(itineraryId);
            _unit.ItineraryRepository.Remove(itinerary);
            _unit.Complete();
        }

        public Itinerary GetItinerary(Guid id)
        {
            var i = this._unit.ItineraryRepository.Get(id);
            return i;
        }

        public IEnumerable<Itinerary> GetAllItineraries()
        {
            var itineraries = this._unit.ItineraryRepository.GetAll();
            return itineraries;
        }
        protected bool ShipmentExists(Guid id)
        {
            return _unit.ShipmentRepository.GetAll().Any(s => s.Id == id);
        }

        public Itinerary SetItineraryLegs(IList<List<double>> distances, IList<Shipment> shipments, Itinerary itinerary, int matrixLength, int realLength, int fromLocation, Guid baseLocation)
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
                    leg.StartLocation = _unit.LocationRepository.Get(baseLocation);
                }
                else
                {
                    leg.StartLocation = shipments[fromLocation-1].DestinationAddress;
                }

                leg.EndLocation = shipments[toLocation-1].DestinationAddress;
                itinerary.Legs.Add(leg);

               return SetItineraryLegs(distances, shipments, itinerary, matrixLength, realLength - 1, toLocation, baseLocation);
            }
        }
    }
}
