using System;
using System.Collections.Generic;
using Server.Domain;
using Server.Application.Services.DataTransfer;

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

        public Itinerary CreateItinerary(IList<Guid> shipmentsIDs);
        public void DeleteItinerary(Guid id);
        public Itinerary GetItinerary(Guid id);
        public IEnumerable<Itinerary> GetAllItineraries();

        public Location GetLocation(Guid id);
        public IEnumerable<Location> GetAllLocations();

        public CustomerInfo GetCustomer(Guid id);
        public IEnumerable<CustomerInfo> GetAllCustomers();

    }
}
