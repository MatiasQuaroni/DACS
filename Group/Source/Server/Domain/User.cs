using System;
using System.Collections.Generic;

namespace Server.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid UserStateId { get; set; }
        public Guid ProfileInfoId { get; set; }
        public IList<UserState> UserStates { get; set; }
        public virtual ProfileInfo ProfileInfo { get; set; }

        public User()
        {
            this.Id = Guid.NewGuid();
            this.UserStates = new List<UserState>();
            this.ProfileInfo = new ProfileInfo();
        }
        public void addState(int newUserStatus)
        {
            var newState = new UserState(newUserStatus);
            this.UserStates.Add(newState);
        }

    }
}
