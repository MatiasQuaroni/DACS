
using Microsoft.EntityFrameworkCore;
using Server.Application.Services.DataTransfer;
using Server.Domain;
using Server.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;

namespace Server.Application.Services
{
    public interface IUsersServices
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUser(Guid id);
        public IEnumerable<User> GetUsersByStatus(int status);
        public void CreateUser(UserData userDTO);
        public void UpdateUser(Guid id, UserData userDTO);
        public void DeleteUser(Guid id);
    }
}