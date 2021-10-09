﻿using System;
using System.Collections.Generic;
using System.Linq;
using Server.Domain;

namespace Server
{
    public class ShipmentState
    {
        public ShipmentStateEnum CurrentState { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

    }
}