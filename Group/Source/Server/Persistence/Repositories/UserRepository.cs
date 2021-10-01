using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Domain;

namespace Server.Persistence.Repositories

{
    public class UserRepository : Repository<User, RoadsDbContext> , IUserRepository
    {
        public UserRepository(RoadsDbContext pDbContext) : base(pDbContext)
        {

        }
        public IEnumerable<User> GetByFilter()
        {
            throw new NotImplementedException();
        }
    }
}
