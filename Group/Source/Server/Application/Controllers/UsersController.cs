using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Domain;
using Server.Application.Services.DataTransfer;
using Server.Application.Services;
using AutoMapper;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;

namespace Server.Application.Controllers
{
    [Route("Users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices _userServices;
        private readonly IMapper _mapper;

        public UsersController(IUsersServices usersServices, IMapper mapper)
        {
            _userServices = usersServices;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task Register(UserData userDTO)
        {
            UserRecordArgs args = new UserRecordArgs()
            {
                Uid = userDTO.Id.ToString(),
                Email = userDTO.ProfileInfo.Email,
                EmailVerified = false,
                PhoneNumber = "+"+userDTO.ProfileInfo.PhoneNumber,
                Password = userDTO.Password,
                DisplayName = userDTO.ProfileInfo.DisplayName,
                PhotoUrl = "http://www.example.com/12345678/photo.png",
                Disabled = false,
            };
            await FirebaseAuth.DefaultInstance.CreateUserAsync(args);
            _userServices.CreateUser(userDTO);
        }

        [HttpPut("update/{id}")]
        public async Task PutUser(Guid id, UserData userDTO)
        {
                UserRecordArgs args = new UserRecordArgs()
                {
                    Uid = id.ToString(),
                    Email = userDTO.ProfileInfo.Email,
                    EmailVerified = false,
                    PhoneNumber = userDTO.ProfileInfo.PhoneNumber,
                    Password = userDTO.Password,
                    DisplayName = userDTO.ProfileInfo.DisplayName,
                    PhotoUrl = "http://www.example.com/12345678/photo.png",
                    Disabled = false,
                };
                UserRecord userRecord = await FirebaseAuth.DefaultInstance.UpdateUserAsync(args);
                _userServices.UpdateUser(id, userDTO);
        }

        [HttpDelete("delete/{id}")]
        public async Task DeleteUser(Guid id)
        {
            
                await FirebaseAuth.DefaultInstance.DeleteUserAsync(id.ToString());
                _userServices.DeleteUser(id);
        }

        [HttpGet("byId")]
        public async Task<UserData> GetUser(Guid id)
        { 
                UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(id.ToString());
                return _mapper.Map<UserData>(_userServices.GetUser(id));     
        }

        [HttpGet("all")]
        public IEnumerable<UserData> GetAllUsers()
        {
            IList<UserData> userDTOs = new List<UserData>();
            var users = _userServices.GetAllUsers();
            foreach (User u in users)
            {
                userDTOs.Add(_mapper.Map<UserData>(u));
            }
            return userDTOs;
        }

        [HttpGet("byStatus")]
        public IEnumerable<UserData> GetUsersByStatus(int status)
        {
            IEnumerable<UserData> userDTOs = new List<UserData>();
            var users = _userServices.GetUsersByStatus(status);
            foreach (User u in users)
            {
                userDTOs.Append(_mapper.Map<UserData>(u));
            }
            return userDTOs;
        }
    }
}
