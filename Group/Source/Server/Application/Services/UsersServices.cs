
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
        public IEnumerable<Domain.User> GetAllUsers();
        public Domain.User GetUser(Guid id);
        public IEnumerable<Domain.User> GetUsersByStatus(int status);
        public void CreateUser(UserData userDTO);
        public void UpdateUser(Guid id, UserData userDTO);
        public void DeleteUser(Guid id);
    }
    public class UsersServices: IUsersServices
    {
        private readonly IUnitOfWork _unit;

        public UsersServices(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }
        public IEnumerable<Domain.User> GetAllUsers()
        {
            var users = this._unit.UserRepository.GetAll();
            return users;
        }
        public Domain.User GetUser(Guid id)
        {
            var u = this._unit.UserRepository.Get(id);
            return u;
        }

        public IEnumerable<Domain.User> GetUsersByStatus(int status)
        {
            var users = this._unit.UserRepository.GetByStatus(status);
            return users;
        }
        public void CreateUser(UserData userDTO)
        {
            Domain.User u = new Domain.User();
            u.Id = Guid.NewGuid();
            u.UserName = userDTO.Username;
            u.Password = userDTO.Password;
            u.ProfileInfo.DisplayName = userDTO.DisplayName;
            u.ProfileInfo.EmailAddress = userDTO.Email;
            u.ProfileInfo.PhoneNumber = userDTO.PhoneNumber;
            u.addState(userDTO.Status);
            _unit.UserRepository.Add(u);
            _unit.Complete();
        }

        public void UpdateUser(Guid id, UserData userDTO)
        {
            try
            {
                Domain.User u = this._unit.UserRepository.Get(id);
                u.UserName = userDTO.Username;
                u.Password = userDTO.Password;
                u.ProfileInfo.DisplayName = userDTO.DisplayName;
                u.ProfileInfo.EmailAddress = userDTO.Email;
                u.ProfileInfo.PhoneNumber = userDTO.PhoneNumber;
                if (u.UserState.Status != (UserStatus)userDTO.Status)
                {
                    u.addState(userDTO.Status);
                }
                _unit.UserRepository.Update(u);
                _unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        public void DeleteUser(Guid id)
        {
            var user = _unit.UserRepository.Get(id);
            _unit.UserRepository.Remove(user);
            _unit.Complete();
        }
    }
}
