using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class CustomerInfo
    {
        public String dni { get; set; }
        public String name { get; set; }
        public String email { get; set; }
        public String phoneNumber { get; set; }
        private IEnumerable<Location> registeredAddresses { get; set; }

    }
}
