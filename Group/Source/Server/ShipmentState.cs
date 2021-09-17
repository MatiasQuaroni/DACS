using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    internal class ShipmentState
    {
        public State CurrentState { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

       public enum State 
        {inPreparation = 0,
        delivered = 1,
        ongoing = 2}
    }
}