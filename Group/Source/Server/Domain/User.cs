using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserState UserState { get; set; }
        public ProfileInfo ProfileInfo { get; set; }

        public User()
        {

        }
        public void addState(int newUserStatus)
        {
            UserState newState = new UserState
            {
                Status = (UserStatus)newUserStatus,
                Date = DateTime.Now,
                UserId = this.Id
            };
        }

    }
}
