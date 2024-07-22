using JLDatabase.Database.Models;
using JLDatabase.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDatabase.Authentication
{
    internal class UserRegistrationAuthentication : IAuthentication
    {
        public InvalidAuthenticationStatus Authenticate(string[] fields)
        {
            IEntityManager _userManager = new UserManager();

            string email = fields[(int)UserFieldTypes.Registration.Email];

            List<User> users = _userManager.Entities.Cast<User>().ToList();
            User? user = users.SingleOrDefault(u => u.Email == email);

            return user == null ? InvalidAuthenticationStatus.None : InvalidAuthenticationStatus.EmailAlreadyRegistered;
        }
    }
}
