using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class UserState
    {
        public DateTime date { get; set; }
        public UserStatus status { get; set; }

        public enum UserStatus
        {
            administrator = 0,
            transportist = 1,
            baseUser = 2
        }
    }
}
