using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Authenticator
{
    public delegate bool ValidateRequiredField(string value);
    public delegate bool ValidateStringLength(string value, int min, int max);
    public delegate bool ValidateDate(string val, out DateTime date);
    public delegate bool ValidateMatchPattern(string value, string pattern);
    public delegate bool ValidateMatchingFields(string value, string valueToCompare);

    public class FieldValidators
    {
        private static ValidateRequiredField? validateRequiredField = null;
        private static ValidateStringLength? validateStringLength = null;
        private static ValidateDate? validateDate = null;
        private static ValidateMatchPattern? validateMatchPattern = null;
        private static ValidateMatchingFields? validateMatchingFields = null;

        // Singleton instances of each validators
        public static ValidateRequiredField ValidateRequiredField => validateRequiredField ??= new (RequiredField);
        public static ValidateStringLength ValidateStringLength => validateStringLength ??= new (StringLength);
        public static ValidateDate ValidateDate => validateDate ??= new (Date);
        public static ValidateMatchPattern ValidateMatchPattern => validateMatchPattern ??= new (MatchPattern);
        public static ValidateMatchingFields ValidateMatchingFields => validateMatchingFields ??= new (MatchingFields);

        private static bool RequiredField(string value) => !string.IsNullOrEmpty(value);
        private static bool StringLength(string value, int min, int max) => value.Length >= min && value.Length <= max;
        private static bool Date(string value, out DateTime date) => DateTime.TryParse(value, out date);
        private static bool MatchPattern(string value, string regexPattern) => Regex.IsMatch(value, regexPattern);
        private static bool MatchingFields(string value, string valueToCompare) => value.Equals(valueToCompare);
    }
}
