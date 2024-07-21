using JLDatabase.Database.Models;
namespace JLAuthenticationAPI
{

    public delegate bool FieldValidator(string[] fields, out string errorMessage);
    public interface IValidator
    {
        FieldValidator Validator { get; }
        bool ValidateFieldsExperimental(string[] fields, out string errorMessage);

        InvalidInputField ValidateFields(string[] fields);

    }
}
