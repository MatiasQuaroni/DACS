using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DAL
{
    interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetByFilter(string pUsername, string pEmail, int pStatus);
    }
}
