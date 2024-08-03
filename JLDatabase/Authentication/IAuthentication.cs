using JLDatabase.Database.Models;

namespace JLDatabase.Authentication
{
    internal interface IAuthentication
    {
        InvalidAuthenticationStatus Authenticate(string[] fields);
    }
}