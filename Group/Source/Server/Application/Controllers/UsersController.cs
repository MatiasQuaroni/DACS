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
using Firebase.Auth;

namespace Server.Application.Controllers
{
    [Route("Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices _userServices;
        private readonly IFirebaseAuthProvider _auth;
        private readonly IMapper _mapper;

        public UsersController(IUsersServices usersServices, IMapper mapper)
        {
            _userServices = usersServices;
            _mapper = mapper;
            _auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCsWPAOSd9rTeTS9lq-qLN_jLG88x17SzY"));
        }

        [HttpPost("create")]
        public async void Register(UserData userDTO)
        {
            _userServices.CreateUser(userDTO);
            await _auth.CreateUserWithEmailAndPasswordAsync(userDTO.Email, userDTO.Password);
            var fbAuthLink = await _auth.SignInWithEmailAndPasswordAsync(userDTO.Email, userDTO.Password);
            string token = fbAuthLink.FirebaseToken;
            if (token != null)
            {
                HttpContext.Session.SetString("_UserToken", token);
            }
        }

        [HttpPut("update/{id}")]
        public void PutUser(Guid id, UserData userDTO)
        {
            _userServices.UpdateUser(id, userDTO);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteUser(Guid id)
        {
            _userServices.DeleteUser(id);
        }

        [HttpPost("logIn")]
        public async void LogIn(string email, string password)
        {
            var fbAuthLink = await _auth.SignInWithEmailAndPasswordAsync(email, password);
            string token = fbAuthLink.FirebaseToken;
            if (token != null)
            {
                HttpContext.Session.SetString("_UserToken", token);
            }
        }

        [HttpGet("logOut")]
        public void LogOut()
        {
            HttpContext.Session.Remove("_UserToken");
            RedirectToAction("LogIn");
        }

        [HttpGet("byId")]
        public UserData GetUser(Guid id)
        {
            return _mapper.Map<UserData>(_userServices.GetUser(id));
        }

        [HttpGet("all")]
        public IEnumerable<UserData> GetAllUsers()
        {
            IEnumerable<UserData> userDTOs = new List<UserData>();
            var users = _userServices.GetAllUsers();
            foreach (Domain.User u in users)
            {
                userDTOs.Append(_mapper.Map<UserData>(u));
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
