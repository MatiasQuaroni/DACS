using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Domain;
using Server.Application.Services.DataTransfer;
using Server.Application.Services;
using Server.Persistence.UnitOfWork;
using AutoMapper;
using FirebaseAdmin.Auth;

namespace Server.Application.Controllers
{
    [Route("Users")]
    [ApiController]
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
        public void Register(UserData userDTO)
        {
            /*UserRecordArgs args = new UserRecordArgs()
            {
                Uid = userDTO.Id.ToString(),
                Email = userDTO.Email,
                EmailVerified = false,
                PhoneNumber = "+"+userDTO.PhoneNumber,
                Password = userDTO.Password,
                DisplayName = userDTO.DisplayName,
                PhotoUrl = "http://www.example.com/12345678/photo.png",
                Disabled = false,
            };
            UserRecord userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(args);*/
            _userServices.CreateUser(userDTO);
        }

        [HttpPut("update/{id}")]
        public void PutUser(Guid id, UserData userDTO)
        {
            /*UserRecordArgs args = new UserRecordArgs()
            {
                Uid = id.ToString(),
                Email = userDTO.Email,
                EmailVerified = false,
                PhoneNumber = userDTO.PhoneNumber,
                Password = userDTO.Password,
                DisplayName = userDTO.DisplayName,
                PhotoUrl = "http://www.example.com/12345678/photo.png",
                Disabled = false,
            };
            UserRecord userRecord = await FirebaseAuth.DefaultInstance.UpdateUserAsync(args);*/
            _userServices.UpdateUser(id, userDTO);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteUser(Guid id)
        {
            //await FirebaseAuth.DefaultInstance.DeleteUserAsync(id.ToString());
            _userServices.DeleteUser(id);
        }
        /*
        [HttpPost("logIn")]
        public async void LogIn(string email, string password)
        {

        }

        [HttpGet("logOut")]
        public void LogOut()
        {
            HttpContext.Session.Remove("_UserToken");
            RedirectToAction("LogIn");
        }*/

        [HttpGet("byId")]
        public UserData GetUser(Guid id)
        {
            //UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(id.ToString());
            return _mapper.Map<UserData>(_userServices.GetUser(id));
        }

        [HttpGet("all")]
        public IEnumerable<UserData> GetAllUsers()
        {
            /*
            GetUsersResult result = await FirebaseAuth.DefaultInstance.GetUsersAsync(
                new List<UserIdentifier> {
                    new UidIdentifier("uid1"),
                    new EmailIdentifier("user2@example.com"),
                    new PhoneIdentifier("+15555550003"),
                    new ProviderIdentifier("google.com", "google_uid4"),
                });
            */
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
            foreach (Domain.User u in users)
            {
                userDTOs.Append(_mapper.Map<UserData>(u));
            }
            return userDTOs;
        }
    }
}
