using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class Leg
    {
        public Guid NumberId { get; set; }
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
    }
}
