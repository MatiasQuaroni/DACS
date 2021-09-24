using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DAL.EF

{
    public class UserRepository : Repository<User, UserDbContext> , IUserRepository
    {
        public UserRepository(UserDbContext pDbContext) : base(pDbContext)
        {

        }
        public IEnumerable<User> GetByFilter(string pUsername, string pEmail, int pStatus)
        {
            throw new NotImplementedException();
        }
    }
}
