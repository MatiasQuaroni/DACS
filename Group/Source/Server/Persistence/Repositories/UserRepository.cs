using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Domain;
using Server.Domain.Repositories;

namespace Server.Persistence.Repositories

{
    public class UserRepository : Repository<User, RoadsDbContext> , IUserRepository
    {
        public UserRepository(RoadsDbContext pDbContext) : base(pDbContext)
        {

        }
        public IEnumerable<User> GetAllUsers()
        {
            List<User> users;
            users = this.iDbContext.Set<User>().Include(u => u.ProfileInfo).Include(u => u.UserState).ToList();
            return users;
        }
        public override User Get(Guid pId)
        {
            var user = iDbContext.Set<User>().Where
                (u => u.Id == pId).Include(u => u.ProfileInfo).Include(u => u.UserState).FirstOrDefault();
            return user;
        }
        public IEnumerable<User> GetByStatus(int status)
        {
            var users = new List<User>();
            foreach (var item in this.iDbContext.Set<User>())
            {
                if (item.UserState.Status == (UserStatus)status)
                {
                    users.Add(item);
                }
            }
            return users;
        }

    }
}
