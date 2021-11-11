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
        public Guid UserStateId { get; set; }
        public Guid ProfileInfoId { get; set; }
        public virtual UserState UserState { get; set; }
        public virtual ProfileInfo ProfileInfo { get; set; }

        public User()
        {
            this.Id = Guid.NewGuid();
            this.UserState = new UserState();
            this.ProfileInfo = new ProfileInfo();
        }
        public void addState(int newUserStatus)
        {
            this.UserState.Status = (UserStatus)newUserStatus;
            this.UserState.Date = DateTime.Now;
            this.UserState.UserId = this.Id;
        }

    }
}
