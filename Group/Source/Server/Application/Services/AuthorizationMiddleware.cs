using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirebaseAdmin.Auth;

namespace Server.Application.Services
{
    public class AuthorizationMiddleware
    {
        public async Task<bool> IsAdmin(string idToken)
        {
            FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
            object isAdmin;
            decodedToken.Claims.TryGetValue("admin", out isAdmin);
            return (bool)isAdmin;
        }

        public async Task<bool> IsTransportist(string idToken)
        {
            FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
            object isTransportist;
            decodedToken.Claims.TryGetValue("transportist", out isTransportist);
            return (bool)isTransportist;
        }
        public async Task<bool> IsBaseUser(string idToken)
        {
            FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
            object isBaseUser;
            decodedToken.Claims.TryGetValue("baseUser", out isBaseUser);
            return (bool)isBaseUser;
        }
    }
}
