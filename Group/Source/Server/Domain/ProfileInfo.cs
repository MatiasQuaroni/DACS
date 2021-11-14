using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domain
{
    public class ProfileInfo
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public User User { get; set; }

        public ProfileInfo()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
