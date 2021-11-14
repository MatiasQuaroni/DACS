using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Domain;

namespace Server
{
    public class DataSeed
    {
        public Location baseLocation;
        public IList<Shipment> shipments = new List<Shipment>();
        public DataSeed()
        {
            baseLocation = new Location
            {
                Id = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"),
                Address = "676 Ingeniero Pereyra",
                PostalCode = 3260,
                Type = 0,
                Coordinates = new double[] { -58.2308008, -32.4962985 }
            };
            var shipment = new Shipment();
            shipment.EstimatedArrivalDate = DateTime.Parse("Jan 1, 2022");
            shipment.Weight = 300;
            shipment.Precautions = "";
            shipment.Customer.Dni = "41044681";
            shipment.Customer.Email = "santiago@roads.com";
            shipment.Customer.Name = "Florez Santiago";
            shipment.Customer.PhoneNumber = "3447 111222";
            shipment.DestinationAddress.Address = "229 Marino Lima";
            shipment.DestinationAddress.Coordinates = new double[] { -58.14496366666666, -32.21342573333333 };
            shipment.DestinationAddress.PostalCode = 3280;
            shipments.Add(shipment);

            var shipment2 = new Shipment();
            shipment2.EstimatedArrivalDate = DateTime.Parse("Jan 1, 2022");
            shipment2.Weight = 2200;
            shipment2.Precautions = "fragile";
            shipment2.Customer.Dni = "33332222";
            shipment2.Customer.Email = "juan@roads.com";
            shipment2.Customer.Name = "Sanchez Juan";
            shipment2.Customer.PhoneNumber = "3447 111888";
            shipment2.DestinationAddress.Address = "770 Rocamora";
            shipment2.DestinationAddress.Coordinates = new double[] { -58.152101762499996, -32.221328 };
            shipment2.DestinationAddress.PostalCode = 3280;
            shipments.Add(shipment2);

            var shipment3 = new Shipment();
            shipment3.EstimatedArrivalDate = DateTime.Parse("Jan 1, 2022");
            shipment3.Weight = 50000;
            shipment3.Precautions = "";
            shipment3.Customer.Dni = "99991111";
            shipment3.Customer.Email = "marcos@roads.com";
            shipment3.Customer.Name = "Rodriguez Marcos";
            shipment3.Customer.PhoneNumber = "3442 123456";
            shipment3.DestinationAddress.Address = "253 9 de Julio";
            shipment3.DestinationAddress.Coordinates = new double[] { -58.2247334, -32.48338546666666 };
            shipment3.DestinationAddress.PostalCode = 3260;
            shipments.Add(shipment3);

            var shipment4 = new Shipment();
            shipment4.EstimatedArrivalDate = DateTime.Parse("Jan 1, 2022");
            shipment4.Weight = 450;
            shipment4.Precautions = "";
            shipment4.Customer.Dni = "11114444";
            shipment4.Customer.Email = "pedro@roads.com";
            shipment4.Customer.Name = "Rodriguez Pedro";
            shipment4.Customer.PhoneNumber = "3442 111333";
            shipment4.DestinationAddress.Address = "629 3 de Febrero";
            shipment4.DestinationAddress.Coordinates = new double[] { -58.23139429166667, -32.493709816666666 };
            shipment4.DestinationAddress.PostalCode = 3260;
            shipments.Add(shipment4);

            var shipment5 = new Shipment();
            shipment5.EstimatedArrivalDate = DateTime.Parse("Jan 1, 2022");
            shipment5.Weight = 300;
            shipment5.Precautions = "";
            shipment5.Customer.Dni = "41045782";
            shipment5.Customer.Email = "julio@roads.com";
            shipment5.Customer.Name = "Marino Julio";
            shipment5.Customer.PhoneNumber = "3447 111767";
            shipment5.DestinationAddress.Address = "472 San Martin";
            shipment5.DestinationAddress.Coordinates = new double[] { -32.2221508, -58.1412408 };
            shipment5.DestinationAddress.PostalCode = 3280;
            shipments.Add(shipment5);
        }
    }
}

