using JLAuthenticationAPI;
using JLDatabase.Database.Models;
using JLDatabase.Managers;
using JLDatabase.Validators;

namespace JLDatabase.Interface
{
    public class UserRegistration
    {
        EntityFactory _factory;
        IEntityManager _userManager;
        IValidator _validator;

        public UserRegistration()
        {
            _factory = new EntityFactory();
            _userManager = new UserManager();
            _validator = new UserRegistrationValidator();
        }


        public string Register(string[] fields, out InvalidInputField result)
        {
            result = InvalidInputField.None;
            result = _validator.ValidateFields(fields);

            if (result == InvalidInputField.None)
            {
                User u = _factory.CreateUser(fields);
                
                if (_userManager.Register(u))
                    return "User registered!";
                else
                    return "Email already registered!";
            }

            return string.Empty;
        }
    }
}
