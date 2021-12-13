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
using Microsoft.AspNetCore.Authorization;
using FirebaseAdmin;

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

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyToken(string token)
        {
            var auth = FirebaseAuth.DefaultInstance;

            try
            {
                var response = await auth.VerifyIdTokenAsync(token);
                if (response != null)
                    return Accepted();
            }
            catch (FirebaseException ex)
            {
                return BadRequest();
            }

            return BadRequest();
        }

        [HttpPost("create")]
        public async Task Register(UserData userDTO, string idToken)
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
            var additionalClaims = new Dictionary<string, object>();
            if (userDTO.UserState == 0)
            {
                additionalClaims.Add("admin",true);
                additionalClaims.Add("transportist", true);
                additionalClaims.Add("baseUser", true);
            }
            else if(userDTO.UserState == 1)
            {
                additionalClaims.Add("admin", false);
                additionalClaims.Add("transportist", true);
                additionalClaims.Add("baseUser", true);
            }
            else
            {
                additionalClaims.Add("admin", false);
                additionalClaims.Add("transportist", false);
                additionalClaims.Add("baseUser", true);
            }      
            await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(userDTO.Id.ToString(), additionalClaims);
            _userServices.CreateUser(userDTO);
        }

        [HttpPut("update/{id}")]
        public async Task PutUser(Guid id, UserData userDTO, string idToken)
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
        public async Task DeleteUser(Guid id, [FromHeader]string idToken)
        {
            
                await FirebaseAuth.DefaultInstance.DeleteUserAsync(id.ToString());
                _userServices.DeleteUser(id);
        }

        [HttpGet("byId")]
        public async Task<UserData> GetUser(Guid id, [FromHeader] string idToken)
        { 
                UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(id.ToString());
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
