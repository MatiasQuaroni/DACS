using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class User
    {
        public String userName { get; set; }
        public String password { get; set; }
        public UserState userState { get; set; }
        public ProfileInfo profileInfo { get; set; }

    }
}
