using System.Text.RegularExpressions;

namespace JLValidatorAPI
{
    public delegate bool ValidateRequiredField(string value);

    public delegate bool ValidateStringLength(string value, int min, int max);

    public delegate bool ValidateDate(string val, out DateTime date);

    public delegate bool ValidateMatchPattern(string value, string pattern);

    public delegate bool ValidateMatchingFields(string value, string valueToCompare);

    public class FieldValidators
    {
        private static ValidateRequiredField? _validateRequiredField = null;
        private static ValidateStringLength? _validateStringLength = null;
        private static ValidateDate? _validateDate = null;
        private static ValidateMatchPattern? _validateMatchPattern = null;
        private static ValidateMatchingFields? _validateMatchingFields = null;

        // Singleton instances of each validators
        public static ValidateRequiredField ValidateRequiredField => _validateRequiredField ??= new(RequiredField);

        public static ValidateStringLength ValidateStringLength => _validateStringLength ??= new(StringLength);
        public static ValidateDate ValidateDate => _validateDate ??= new(Date);
        public static ValidateMatchPattern ValidateMatchPattern => _validateMatchPattern ??= new(MatchPattern);
        public static ValidateMatchingFields ValidateMatchingFields => _validateMatchingFields ??= new(MatchingFields);

        private static bool RequiredField(string value) => !string.IsNullOrEmpty(value);

        private static bool StringLength(string value, int min, int max) => value.Length >= min && value.Length <= max;

        private static bool Date(string value, out DateTime date) => DateTime.TryParse(value, out date);

        private static bool MatchPattern(string value, string regexPattern) => Regex.IsMatch(value, regexPattern);

        private static bool MatchingFields(string value, string valueToCompare) => value.Equals(valueToCompare);
    }
}