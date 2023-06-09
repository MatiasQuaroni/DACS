﻿
using Microsoft.EntityFrameworkCore;
using Server.Application.Services.DataTransfer;
using Server.Domain;
using Server.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Application.Services
{
    public class UsersServices: IUsersServices
    {
        private readonly IUnitOfWork _unit;

        public UsersServices(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }
        public IEnumerable<User> GetAllUsers()
        {
            var users = this._unit.UserRepository.GetAllUsers();
            return users;
        }
        public User GetUser(Guid id)
        {
            var u = this._unit.UserRepository.Get(id);
            return u;
        }

        public IEnumerable<User> GetUsersByStatus(int status)
        {
            var users = this._unit.UserRepository.GetByStatus(status);
            return users;
        }
        public void CreateUser(UserData userDTO)
        {
            User u = new User();
            u.Id = Guid.NewGuid();
            u.UserName = userDTO.Username;
            u.Password = userDTO.Password;
            u.ProfileInfo.DisplayName = userDTO.ProfileInfo.DisplayName;
            u.ProfileInfo.EmailAddress = userDTO.ProfileInfo.Email;
            u.ProfileInfo.PhoneNumber = userDTO.ProfileInfo.PhoneNumber;
            u.addState(userDTO.UserState);
            _unit.UserRepository.Add(u);
            _unit.Complete();
        }

        public void UpdateUser(Guid id, UserData userDTO)
        {
                User u = this._unit.UserRepository.Get(id);
                u.UserName = userDTO.Username;
                u.Password = userDTO.Password;
                u.ProfileInfo.DisplayName = userDTO.ProfileInfo.DisplayName;
                u.ProfileInfo.EmailAddress = userDTO.ProfileInfo.Email;
                u.ProfileInfo.PhoneNumber = userDTO.ProfileInfo.PhoneNumber;
                if (u.UserStates.Last<UserState>().Status != (UserStatus)userDTO.UserState)
                {
                    u.addState(userDTO.UserState);
                }
                _unit.UserRepository.Update(u);
                _unit.Complete();
        }
        public void DeleteUser(Guid id)
        {
            var user = _unit.UserRepository.Get(id);
            _unit.UserRepository.Remove(user);
            _unit.Complete();
        }
    }
}
