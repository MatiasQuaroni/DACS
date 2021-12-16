using System;
using System.Collections.Generic;

namespace Server.Domain
{
    public class CustomerInfo
    {
        public Guid Id { get; set; }
        public string Dni { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Shipment Shipment { get; set; }
        private IEnumerable<Location> RegisteredAddresses { get; set; }

        public CustomerInfo()
        {
            this.Id = Guid.NewGuid();
            this.RegisteredAddresses = new List<Location>();
        }

    }
}
