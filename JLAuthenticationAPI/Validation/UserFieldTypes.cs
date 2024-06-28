using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLAuthenticationAPI.Validation
{
    public class UserFieldTypes
    {
        public enum Registration
        {
            IsAdmin,
            FirstName,
            LastName, 
            Email, 
            Password 
        }

        public enum Login
        {
            Email,
            Password
        }
    }

    public class ArticleFieldTypes
    {
        public enum RegistrationFields
        {

        }
    }
}
