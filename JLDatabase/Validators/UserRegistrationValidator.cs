using JLAuthenticationAPI;
using JLDatabase.Database.Data;
using JLDatabase.Database.Models;

namespace JLDatabase.Validators
{
    internal class UserRegistrationValidator : IValidator
    {
        private const string invalidNoInputMsg = "Invalid registration form (field input missing)";
        private const string invalidIsAdminMsg = "Invalid admin settings (true/false)";
        private const string invalidFirstNameMsg = "Invalid name (e.g. John)";
        private const string invalidLastNameMsg = "Invalid last name (e.g. Doe)";
        private const string invalidEmailMsg = "Invalid email format (e.g. john_doe@gmail.com)";
        private const string emailAlreadyRegisteredMsg = "Email is already registered!";
        private const string invalidPasswordMsg = "Invalid password format (at least 6 letters + numbers)";

        // Field validator delegates 
        ValidateRequiredField _validateRequiredField;
        ValidateMatchingFields _validateMatchingField;
        ValidateMatchPattern _validateMatchPattern;

        FieldValidator _fieldValidator;
        public FieldValidator Validator => _fieldValidator;

        public UserRegistrationValidator()
        {
            _validateRequiredField = FieldValidators.ValidateRequiredField;
            _validateMatchingField = FieldValidators.ValidateMatchingFields;
            _validateMatchPattern = FieldValidators.ValidateMatchPattern;

            _fieldValidator = new FieldValidator(ValidateFields);  
        }

        public bool ValidateFields(string[] fields, out string errorMessage)
        {
            errorMessage = string.Empty;

            for (int i = 0; i < Enum.GetValues(typeof(UserFieldTypes.Registration)).Length; i++)
            {
                UserFieldTypes.Registration fieldType = (UserFieldTypes.Registration)i;
                // Every field is required
                errorMessage = _validateRequiredField(fields[i]) ? errorMessage : invalidNoInputMsg;
                switch (fieldType)
                {
                    case UserFieldTypes.Registration.IsAdmin:
                        // Check if boolean string
                        errorMessage = _validateMatchPattern(fields[i], RegexValidatorPatterns.BooleanString) ? errorMessage : invalidIsAdminMsg;
                        break; 
                    case UserFieldTypes.Registration.FirstName:
                        // Check if name only has letters
                        errorMessage = _validateMatchPattern(fields[i], RegexValidatorPatterns.LettersOnly) ? errorMessage : invalidFirstNameMsg;
                        break;
                    case UserFieldTypes.Registration.LastName:
                        // Check if name only has letters
                        errorMessage = _validateMatchPattern(fields[i], RegexValidatorPatterns.LettersOnly) ? errorMessage : invalidLastNameMsg;
                        break;
                    case UserFieldTypes.Registration.Email:
                        // Check if email has a valid format (example_user@domain.com)
                        errorMessage = _validateMatchPattern(fields[i], RegexValidatorPatterns.Email) ? errorMessage : invalidEmailMsg;
                        // Check if email is already registered in database!
                        errorMessage = ValidateUniqueEmailWithDatabase(fields[i], errorMessage);
                        break;
                    case UserFieldTypes.Registration.Password:
                        // Check if password fits the criteria (alphabet + number)
                        errorMessage = _validateMatchPattern(fields[i], RegexValidatorPatterns.Password) ? errorMessage : invalidPasswordMsg;
                        break;
                    default:
                        throw new Exception("This field doesn't exist");
                }
            }

            return string.IsNullOrEmpty(errorMessage);
        }

        private string ValidateUniqueEmailWithDatabase(string email, string errorMessage)
        {
            // Check if email is already registered in database!
            using (var dbContext = new JournalLibraryDbContext())
            {
                ICollection<User> users = new List<User>(dbContext.Users);
                User? userWithSameEmail = users.SingleOrDefault(u => u.Email == email);
                errorMessage = userWithSameEmail == null ? errorMessage : emailAlreadyRegisteredMsg;
            }

            return errorMessage;
        }

    }
}
