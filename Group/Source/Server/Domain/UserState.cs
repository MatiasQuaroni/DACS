using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domain
{
    public class UserState
    {
        public DateTime Date { get; set; }
        public UserStatus Status { get; set; }
    }
}
