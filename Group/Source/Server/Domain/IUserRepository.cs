using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domain
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetByFilter();
    }
}
