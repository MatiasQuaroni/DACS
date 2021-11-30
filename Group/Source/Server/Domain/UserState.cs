using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domain
{
    public class UserState
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public UserStatus Status { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }

        public UserState()
        {
                
        }
        public UserState(int newUserStatus)
        {
            this.Id = Guid.NewGuid();
            this.Status = (UserStatus)newUserStatus;
            this.Date = DateTime.Now; 
        }
    }
}
