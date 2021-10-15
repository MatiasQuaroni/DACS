using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.Services.DataTransfer
{
    public class LocationData
    {
        public int PostalCode { get; set; }
        public string Address { get; set; }
        public string Floor { get; set; }
        public string Number { get; set; }
    }
}
