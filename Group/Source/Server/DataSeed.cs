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
            var location = new Location();
            location.Address = "229 Marino Lima";
            location.Coordinates = new double[] { -58.14496366666666, -32.21342573333333 };
            location.PostalCode = 3280;
            var customer = new CustomerInfo();
            customer.Dni = "41044681";
            customer.Email = "santiago@roads.com";
            customer.Name = "Florez Santiago";
            customer.PhoneNumber = "3447 111222";
            var shipment = new Shipment(customer, location);
            shipment.EstimatedArrivalDate = DateTime.Parse("Jan 1, 2022");
            shipment.Weight = 300;
            shipment.Precautions = "";         
            shipments.Add(shipment);

            var location2 = new Location();
            location2.Address = "770 Rocamora";
            location2.Coordinates = new double[] { -58.152101762499996, -32.221328 };
            location2.PostalCode = 3280;
            var customer2 = new CustomerInfo();
            customer2.Dni = "33332222";
            customer2.Email = "juan@roads.com";
            customer2.Name = "Sanchez Juan";
            customer2.PhoneNumber = "3447 111888";
            var shipment2 = new Shipment(customer2, location2);
            shipment2.EstimatedArrivalDate = DateTime.Parse("Jan 1, 2022");
            shipment2.Weight = 2200;
            shipment2.Precautions = "fragile";
            shipments.Add(shipment2);

            var location3 = new Location();
            location3.Address = "253 9 de Julio";
            location3.Coordinates = new double[] { -58.2247334, -32.48338546666666 };
            location3.PostalCode = 3260;
            var customer3 = new CustomerInfo();
            customer3.Dni = "99991111";
            customer3.Email = "marcos@roads.com";
            customer3.Name = "Rodriguez Marcos";
            customer3.PhoneNumber = "3442 123456";
            var shipment3 = new Shipment(customer3, location3);
            shipment3.EstimatedArrivalDate = DateTime.Parse("Jan 1, 2022");
            shipment3.Weight = 50000;
            shipment3.Precautions = "";
            shipments.Add(shipment3);

            var location4 = new Location();
            location4.Address = "629 3 de Febrero";
            location4.Coordinates = new double[] { -58.23139429166667, -32.493709816666666 };
            location4.PostalCode = 3260;
            var customer4 = new CustomerInfo();
            customer4.Dni = "11114444";
            customer4.Email = "pedro@roads.com";
            customer4.Name = "Rodriguez Pedro";
            customer4.PhoneNumber = "3442 111333";
            var shipment4 = new Shipment(customer4, location4);
            shipment4.EstimatedArrivalDate = DateTime.Parse("Jan 1, 2022");
            shipment4.Weight = 450;
            shipment4.Precautions = "";
            shipments.Add(shipment4);

            var location5 = new Location();
            location5.Address = "472 San Martin";
            location5.Coordinates = new double[] { -32.2221508, -58.1412408 };
            location5.PostalCode = 3280;
            var customer5 = new CustomerInfo();
            customer5.Dni = "41045782";
            customer5.Email = "julio@roads.com";
            customer5.Name = "Marino Julio";
            var shipment5 = new Shipment(customer5, location5);
            shipment5.EstimatedArrivalDate = DateTime.Parse("Jan 1, 2022");
            shipment5.Weight = 300;
            shipment5.Precautions = "";
            shipment5.Customer.PhoneNumber = "3447 111767";
            shipments.Add(shipment5);
        }
    }
}

