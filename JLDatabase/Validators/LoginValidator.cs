using JLDatabase.Database.Models;
using JLValidatorAPI;

namespace JLDatabase.Validators
{
    public class LoginValidator : IValidator
    {
        private const string invalidNoInputMsg = "Missing input field";
        private const string invalidEmailMsg = "Invalid email format (e.g. john_doe@gmail.com)";
        private const string invalidPasswordMsg = "Invalid password format (at least 6 letters + numbers)";

        private ValidateRequiredField _validateRequiredField;
        private ValidateMatchPattern _validateMatchPattern;

        private FieldValidator _fieldValidator;

        public LoginValidator()
        {
            _validateRequiredField = FieldValidators.ValidateRequiredField;
            _validateMatchPattern = FieldValidators.ValidateMatchPattern;

            _fieldValidator = new FieldValidator(ValidateFieldsExperimental);
        }

        public bool ValidateFieldsExperimental(string[] fields, out string errorMessage)
        {
            errorMessage = string.Empty;

            for (int i = 0; i < Enum.GetValues(typeof(UserFieldTypes.Login)).Length; i++)
            {
                UserFieldTypes.Login fieldType = (UserFieldTypes.Login)i;
                errorMessage = _validateRequiredField(fields[i]) ? errorMessage : invalidNoInputMsg;
                switch (fieldType)
                {
                    case UserFieldTypes.Login.Email:
                        errorMessage = _validateMatchPattern(fields[i], RegexValidatorPatterns.Email) ? errorMessage : invalidEmailMsg;
                        break;

                    case UserFieldTypes.Login.Password:
                        errorMessage = _validateMatchPattern(fields[i], RegexValidatorPatterns.Password) ? errorMessage : invalidPasswordMsg;
                        break;
                }
            }

            return string.IsNullOrEmpty(errorMessage);
        }

        public InvalidInputFieldStatus ValidateFields(string[] fields)
        {
            InvalidInputFieldStatus fieldStatus = InvalidInputFieldStatus.None;

            for (int i = 0; i < Enum.GetValues(typeof(UserFieldTypes.Login)).Length; i++)
            {
                UserFieldTypes.Login fieldType = (UserFieldTypes.Login)i;
                switch (fieldType)
                {
                    case UserFieldTypes.Login.Email:
                        fieldStatus = _validateRequiredField(fields[i]) && _validateMatchPattern(fields[i], RegexValidatorPatterns.Email) ? fieldStatus : InvalidInputFieldStatus.Email;
                        break;

                    case UserFieldTypes.Login.Password:
                        fieldStatus = _validateRequiredField(fields[i]) && _validateMatchPattern(fields[i], RegexValidatorPatterns.Password) ? fieldStatus : InvalidInputFieldStatus.Password;
                        break;
                }
            }
            return fieldStatus;
        }
    }
}