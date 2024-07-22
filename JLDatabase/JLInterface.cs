using JLAuthenticationAPI;
using JLDatabase.Authentication;
using JLDatabase.Database.Models;
using JLDatabase.Managers;
using JLDatabase.Validators;

namespace JLDatabase
{
    public static class JLInterface
    {
        public static void RegisterUser(string[] fields, out InvalidInputFieldStatus validateResult, out InvalidAuthenticationStatus authenticateResult)
        {
            IAuthentication authentication = new UserRegistrationAuthentication();
            IValidator validator = new UserRegistrationValidator();
            UserManager userManager = new UserManager();

            validateResult = new UserRegistrationValidator().ValidateFields(fields);
            authenticateResult = new UserRegistrationAuthentication().Authenticate(fields);

            if (validateResult == InvalidInputFieldStatus.None &&
                authenticateResult == InvalidAuthenticationStatus.None)
            {
                EntityFactory factory = new EntityFactory();
                userManager.Register(factory.CreateUser(fields));
            }
        }

        public static User? Login(string[] fields, out InvalidInputFieldStatus validateResult, out InvalidAuthenticationStatus authenticateResult)
        {
            IAuthentication authentication = new LoginAuthentication();
            IValidator validator = new LoginValidator();
            UserManager userManager = new UserManager();

            User? user = null;
            validateResult = validator.ValidateFields(fields);
            authenticateResult = authentication.Authenticate(fields);

            if (validateResult == InvalidInputFieldStatus.None &&
                authenticateResult == InvalidAuthenticationStatus.None)
            {
                string email = fields[(int)UserFieldTypes.Login.Email];
                string password = fields[(int)UserFieldTypes.Login.Password];

                // Try to find user 
                List<User> users = userManager.Entities.Cast<User>().ToList();
                user = users.SingleOrDefault(u => u.Email == email && u.Password == password);
            }

            return user;
        }
    }
}
