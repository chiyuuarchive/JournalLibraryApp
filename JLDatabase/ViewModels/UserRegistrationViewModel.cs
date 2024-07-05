using JLDatabase.Managers;
using JLDatabase.Validation;
using JLDatabase.Database.Models;
using JLAuthenticationAPI;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace JLDatabase.ViewModels
{
    internal class UserRegistrationViewModel
    {
        IEntityManager _userManager;
        IValidator _validator;

        public UserRegistrationViewModel(IEntityManager userManager, IValidator validation)
        {
            _validator = validation;
            _userManager = userManager;
        }


        public void RunView()
        {

        }

        // Placeholder methods for UI event handlers
        public void AddUserToDb()
        {
            // Replace input fields with actual txtFields.Text
            string[] fields =
            [
                "True",
                "John",
                "Doe",
                "johndoe@gmail.com",
                "abc123",

            ];

            string errorMessage = string.Empty;

            // Validate
            _validator.Validator?.Invoke(fields, out errorMessage);

        }
    }
}
