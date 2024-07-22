using JLDatabase.Database.Models;
using JLDatabase.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDatabase.Authentication
{
    internal class LoginAuthentication : IAuthentication
    {
        public InvalidAuthenticationStatus Authenticate(string[] fields)
        {
            IEntityManager _userManager = new UserManager();

            string email = fields[(int)UserFieldTypes.Login.Email];
            string password = fields[(int)UserFieldTypes.Login.Password];

            // Try to find user 
            List<User> users = _userManager.Entities.Cast<User>().ToList(); // error
            User? user = users.SingleOrDefault(u => u.Email == email && u.Password == password);


            InvalidAuthenticationStatus result = InvalidAuthenticationStatus.None;
            result = user != null ? InvalidAuthenticationStatus.None : InvalidAuthenticationStatus.UserDoesntExist;

            if (user == null) return result;

            result = user.IsVerified ? InvalidAuthenticationStatus.None : InvalidAuthenticationStatus.UserNotVerified;

            return result;
        }
    }
}
