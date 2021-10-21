﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Domain
{
    public class ShipmentState
    {
        public ShipmentStateEnum CurrentState { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

    }
}