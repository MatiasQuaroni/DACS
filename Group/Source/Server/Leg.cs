using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class Leg
    {
        public int numberId { get; set; }
        public Location startLocation { get; set; }
        public Location endLocation { get; set; }
    }
}
