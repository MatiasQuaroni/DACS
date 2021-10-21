using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Domain;

namespace Server.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetByFilter();
    }
}
