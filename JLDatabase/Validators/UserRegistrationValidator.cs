using JLDatabase.Database.Models;
using JLValidatorAPI;

namespace JLDatabase.Validators
{
    internal class UserRegistrationValidator : IValidator
    {
        private const string invalidNoInputMsg = "Invalid registration form (field input missing)";
        private const string invalidIsAdminMsg = "Invalid admin settings (true/false)";
        private const string invalidFirstNameMsg = "Invalid name (e.g. John)";
        private const string invalidLastNameMsg = "Invalid last name (e.g. Doe)";
        private const string invalidEmailMsg = "Invalid email format (e.g. john_doe@gmail.com)";
        private const string invalidPasswordMsg = "Invalid password format (at least 6 letters + numbers)";

        // Field validator delegates
        private readonly ValidateRequiredField _validateRequiredField;

        private readonly ValidateMatchPattern _validateMatchPattern;

        public UserRegistrationValidator()
        {
            _validateRequiredField = FieldValidators.ValidateRequiredField;
            _validateMatchPattern = FieldValidators.ValidateMatchPattern;
        }

        public bool ValidateFieldsExperimental(string[] fields, out string errorMessage)
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
                        break;

                    case UserFieldTypes.Registration.Password:
                        // Check if password fits the criteria (alphabet + number)
                        errorMessage = _validateMatchPattern(fields[i], RegexValidatorPatterns.Password) ? errorMessage : invalidPasswordMsg;
                        break;
                }
            }

            return string.IsNullOrEmpty(errorMessage);
        }

        public InvalidInputFieldStatus ValidateFields(string[] fields)
        {
            InvalidInputFieldStatus fieldStatus = InvalidInputFieldStatus.None;
            for (int i = 0; i < Enum.GetValues(typeof(UserFieldTypes.Registration)).Length; i++)
            {
                UserFieldTypes.Registration fieldType = (UserFieldTypes.Registration)i;
                switch (fieldType)
                {
                    case UserFieldTypes.Registration.IsAdmin:
                        // Check if boolean string
                        fieldStatus = _validateRequiredField(fields[i]) && _validateMatchPattern(fields[i], RegexValidatorPatterns.BooleanString) ? fieldStatus : InvalidInputFieldStatus.IsAdmin;
                        break;

                    case UserFieldTypes.Registration.FirstName:
                        // Check if name only has letters
                        fieldStatus = _validateRequiredField(fields[i]) && _validateMatchPattern(fields[i], RegexValidatorPatterns.LettersOnly) ? fieldStatus : InvalidInputFieldStatus.FirstName;
                        break;

                    case UserFieldTypes.Registration.LastName:
                        // Check if name only has letters
                        fieldStatus = _validateRequiredField(fields[i]) && _validateMatchPattern(fields[i], RegexValidatorPatterns.LettersOnly) ? fieldStatus : InvalidInputFieldStatus.LastName;
                        break;

                    case UserFieldTypes.Registration.Email:
                        // Check if email has a valid format (example_user@domain.com)
                        fieldStatus = _validateRequiredField(fields[i]) && _validateMatchPattern(fields[i], RegexValidatorPatterns.Email) ? fieldStatus : InvalidInputFieldStatus.Email;
                        break;

                    case UserFieldTypes.Registration.Password:
                        // Check if password fits the criteria (alphabet + number)
                        fieldStatus = _validateRequiredField(fields[i]) && _validateMatchPattern(fields[i], RegexValidatorPatterns.Password) ? fieldStatus : InvalidInputFieldStatus.Password;
                        break;
                }
            }

            return fieldStatus;
        }
    }
}