using JLDatabase.Database.Models;
namespace JLAuthenticationAPI
{

    internal delegate bool FieldValidator(string[] fields, out string errorMessage);
    internal interface IValidator
    {
        bool ValidateFieldsExperimental(string[] fields, out string errorMessage);

        InvalidInputFieldStatus ValidateFields(string[] fields);

    }
}
