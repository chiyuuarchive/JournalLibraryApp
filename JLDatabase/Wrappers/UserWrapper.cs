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
        IEntityManager _userManager;
        IValidator _validator;

        public const string SuccessFindUser = "User found";
        public const string FailFindUser = "User not found";
        public string FailRegistrationMessage => $"Email is already registered";
        public string SuccessRegistrationMessage(User u) => $"{u.Name} registered to database";
        public string FailRemoveAtMessage(string s) => $"{s} doesn't exist";
        public string SuccessRemoveAtMessage(string s) => $"{s} removed from database";
        public string FailChangeAtMessage(string s) => $"Unable to update user information of {s}";
        public string SuccessChangeAtMessage(string s) => $"{s} has been updated";

        public UserWrapper(EntityFactory factory, IEntityManager userManager)
        {
            _factory = factory;
            _userManager = userManager;
            _validator = new UserRegistrationValidator();
        }

        #region Experimental
        public void ChangeUser(string[] fields, string userEmailID)
        {
            string errorMessage = string.Empty;

            // Check if input is valid for registration
            _validator.ValidateFieldsExperimental(fields, out errorMessage);

            if (errorMessage == string.Empty)
            {
                // Create user object and change user in database 
                User u = _factory.CreateUser(fields);
                errorMessage = _userManager.ChangeAt(u, userEmailID)? errorMessage = SuccessChangeAtMessage(userEmailID) : FailChangeAtMessage(userEmailID);
            }
            
            if (errorMessage != string.Empty)
                Console.WriteLine(errorMessage);
        }

        public void RegisterUser(string[] fields)
        {
            string errorMessage = string.Empty;

            // Check if input is valid for registration
            _validator.ValidateFieldsExperimental(fields, out errorMessage);

            if (errorMessage == string.Empty)
            {
                // Create and register user to database
                User u = _factory.CreateVerifiedUser(fields);
                errorMessage = _userManager.Register(u)? SuccessRegistrationMessage(u) : FailRegistrationMessage;
            }

            if (errorMessage != string.Empty)
                Console.WriteLine(errorMessage);
        }

        public void UnregisterUser(string emailID) 
        {
            string errorMessage = _userManager.RemoveAt(emailID) ? SuccessRemoveAtMessage(emailID) : FailRemoveAtMessage(emailID);
            
            if (errorMessage != string.Empty)
                Console.WriteLine(errorMessage);
        }
        #endregion
    }
}
