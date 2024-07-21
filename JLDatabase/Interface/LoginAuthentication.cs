using JLAuthenticationAPI;
using JLDatabase.Database.Models;
using JLDatabase.Managers;
using JLDatabase.Validators;
namespace JLDatabase
{
    public class LoginAuthentication
    {
        IEntityManager _userManager;
        IValidator _validator;

        public LoginAuthentication()
        {
            _userManager = new UserManager();
            _validator = new LoginValidator();
        }

        public User? Authenticate(string[] fields, out InvalidInputField result)
        {
            User? user = null;
            string errorMessage = string.Empty;
            result = _validator.ValidateFields(fields);

            if (result == InvalidInputField.None)
            {
                string email = fields[(int)UserFieldTypes.Login.Email];
                string password = fields[(int)UserFieldTypes.Login.Password];

                // Try to find user 
                List<User> users =_userManager.Entities.Cast<User>().ToList(); // error
                user = users.SingleOrDefault(u => u.Email == email && u.Password == password);
            }

            return user;
        }
    }
}
