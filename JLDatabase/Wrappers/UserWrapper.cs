using JLAuthenticationAPI;
using JLDatabase.Managers;
using JLDatabase.Validators;
using JLDatabase.Database.Models;
using JLDatabase.Database.Data;
using System.Linq;

namespace JLDatabase.Wrappers
{
    internal class UserWrapper
    {        
        EntityFactory _factory;
        IValidator _validator;
        IEntityManager _userManager;

        public const string SuccessSetActiveUser = "Active user set";
        public const string FailSetActiveUser = "User not found";

        public string SetActiveUser(string email, out User? activeUser)
        {
            List<User> users = (List<User>)_userManager.Entities;
            activeUser = users.SingleOrDefault(u => u.Email == email);
            return activeUser != null ? SuccessSetActiveUser : FailSetActiveUser;
        }

        public UserWrapper(EntityFactory factory, IEntityManager userManager)
        {
            _factory = factory;
            _validator = new UserRegistrationValidator();
            _userManager = userManager;
        }
        public void ChangeUser(string[] fields, string userEmailID)
        {
            string errorMessage = string.Empty;

            // Check if input is valid for registration
            _validator.ValidateFields(fields, out errorMessage);

            if (errorMessage == string.Empty)
            {
                // Create user object and change user in database 
                User u = _factory.CreateUser(fields);
                errorMessage = _userManager.ChangeAt(u, userEmailID)? errorMessage = _userManager.SuccessChangeAtMessage(userEmailID) : _userManager.FailChangeAtMessage(userEmailID);
            }
            
            if (errorMessage != string.Empty)
                Console.WriteLine(errorMessage);
        }

        public void RegisterUser(string[] fields)
        {
            string errorMessage = string.Empty;

            // Check if input is valid for registration
            _validator.ValidateFields(fields, out errorMessage);

            if (errorMessage == string.Empty)
            {
                // Create and register user to database
                User u = _factory.CreateUser(fields);
                errorMessage = _userManager.Register(u)? _userManager.SuccessRegistrationMessage(u) : _userManager.FailRegistrationMessage(u);
            }

            if (errorMessage != string.Empty)
                Console.WriteLine(errorMessage);
        }

        public void UnregisterUser(string emailID) 
        {
            string errorMessage = _userManager.RemoveAt(emailID) ? _userManager.SuccessRemoveAtMessage(emailID) : _userManager.FailRemoveAtMessage(emailID);
            
            if (errorMessage != string.Empty)
                Console.WriteLine(errorMessage);
        }
    }
}
