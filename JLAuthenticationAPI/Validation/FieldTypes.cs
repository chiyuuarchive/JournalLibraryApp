using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLAuthenticationAPI.Validation
{
    public class FieldTypes
    {
        public enum RegistrationFieldTypes
        {
            IsAdmin,
            FirstName,
            LastName, 
            Email, 
            Password,
            ConfirmedPassword     
        }

        public enum LoginFieldTypes
        {
            Email,
            Password
        }
    }
}
