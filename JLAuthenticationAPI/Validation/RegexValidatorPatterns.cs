using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLAuthenticationAPI.Validation
{
    public class RegexValidatorPatterns
    {
        public const string LettersOnly = "^[a-zA-Z]+$";


        public const string Email = @"^[\w]+@[A-Za-z0-9]+\.[A-Za-z]{2,3}$";

        // Password must have 1 uppercase, 1 lowercase letter and 1 digit. Minimum length at 6
        public const string Password = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{6,}$";
    }
}
