using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.Services.DataTransfer
{
    public class UserData
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ProfileInfoData ProfileInfo { get; set; }
        public int UserState { get; set; }
    }
}
