using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class CustomerInfo
    {
        public Guid Id { get; set; }
        public String Dni { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        private IEnumerable<Location> RegisteredAddresses { get; set; }

    }
}
