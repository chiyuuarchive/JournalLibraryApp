using JLDatabase.Database.Models;
using JLDatabase.Managers;
using JLDatabase.Validators;

namespace JLDatabase.Wrappers
{
    internal class UserWrapper(EntityFactory factory, IEntityManager userManager)
    {
        private readonly UserRegistrationValidator _validator = new();

        public const string SuccessFindUser = "User found";
        public const string FailFindUser = "User not found";
        public string FailRegistrationMessage => $"Email is already registered";

        public string SuccessRegistrationMessage(User u) => $"{u.Name} registered to database";

        public string FailRemoveAtMessage(string s) => $"{s} doesn't exist";

        public string SuccessRemoveAtMessage(string s) => $"{s} removed from database";

        public string FailChangeAtMessage(string s) => $"Unable to update user information of {s}";

        public string SuccessChangeAtMessage(string s) => $"{s} has been updated";

        #region Experimental

        public void ChangeUser(string[] fields, string userEmailID)
        {
            // Check if input is valid for registration
            _validator.ValidateFieldsExperimental(fields, out string errorMessage);

            if (errorMessage == string.Empty)
            {
                // Create user object and change user in database
                User u = factory.CreateUser(fields);
                errorMessage = userManager.ChangeAt(u, userEmailID) ? SuccessChangeAtMessage(userEmailID) : FailChangeAtMessage(userEmailID);
            }

            if (errorMessage != string.Empty)
                Console.WriteLine(errorMessage);
        }

        public void RegisterUser(string[] fields)
        {
            // Check if input is valid for registration
            _validator.ValidateFieldsExperimental(fields, out string errorMessage);

            if (errorMessage == string.Empty)
            {
                // Create and register user to database
                User u = factory.CreateVerifiedUser(fields);
                errorMessage = userManager.Register(u) ? SuccessRegistrationMessage(u) : FailRegistrationMessage;
            }

            if (errorMessage != string.Empty)
                Console.WriteLine(errorMessage);
        }

        public void UnregisterUser(string emailID)
        {
            string errorMessage = userManager.RemoveAt(emailID) ? SuccessRemoveAtMessage(emailID) : FailRemoveAtMessage(emailID);

            if (errorMessage != string.Empty)
                Console.WriteLine(errorMessage);
        }

        #endregion Experimental
    }
}