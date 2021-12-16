using System.Collections.Generic;

namespace Server.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public IEnumerable<User> GetAllUsers();
        public IEnumerable<User> GetByStatus(int status);
    }
}
