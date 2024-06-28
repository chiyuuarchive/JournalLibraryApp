using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLAuthenticationAPI.Validation.CustomValidators
{
    internal class UserRegistrationValidation : IValidator
    {

        // Field validator delegates 
        ValidateRequiredField _validateRequiredField = null!;
        ValidateMatchingFields _validateMatchingField = null!;
        ValidateMatchPattern _validateMatchPattern = null!;

        FieldValidator _fieldValidator;

        public FieldValidator Validator => _fieldValidator;

        public UserRegistrationValidation()
        {
            _validateRequiredField = FieldValidators.ValidateRequiredField;
            _validateMatchingField = FieldValidators.ValidateMatchingFields;
            _validateMatchPattern = FieldValidators.ValidateMatchPattern;

            _fieldValidator = new FieldValidator(ValidateField);  
        }

        public bool ValidateField(int fieldTypeIndex, string fieldValue, string[] fields, out string errorMessage)
        {
            UserFieldTypes.Registration type = (UserFieldTypes.Registration)fieldTypeIndex;
            errorMessage = string.Empty;

            switch(type)
            {
                case UserFieldTypes.Registration.FirstName:
                    // Check if name only has letters
                    errorMessage = _validateMatchPattern(fieldValue, RegexValidatorPatterns.LettersOnly) ? errorMessage : "Invalid name (e.g. John)";
                    break;
                case UserFieldTypes.Registration.LastName:
                    // Check if name only has letters
                    errorMessage = _validateMatchPattern(fieldValue, RegexValidatorPatterns.LettersOnly) ? errorMessage : "Invalid name (e.g. Doe)";
                    break;
                case UserFieldTypes.Registration.Email:
                    // Check if email has a valid format (example_user@domain.com)
                    errorMessage = _validateMatchPattern(fieldValue, RegexValidatorPatterns.Email) ? errorMessage : "Invalid email format (e.g. JohnDoe@gmail.com";
                    break;
                case UserFieldTypes.Registration.Password:
                    // Check if password fits the criteria (alphabet + number)
                    errorMessage = _validateMatchPattern(fieldValue, RegexValidatorPatterns.Password)? errorMessage : "Input a passowrd with 6 letters + numbers";
                    // Check if the password matches
                    errorMessage = _validateMatchingField(fieldValue, fields[(int)UserFieldTypes.Registration.Password]) ? errorMessage : "Password doesn't match";
                    break;
                default:
                    throw new Exception("This field doesn't exist");

            }

            return string.IsNullOrEmpty(errorMessage);
        }

    }
}
