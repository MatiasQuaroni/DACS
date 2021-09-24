﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class User
    {
        public Guid Id { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public UserState UserState { get; set; }
        public ProfileInfo ProfileInfo { get; set; }

    }
}
