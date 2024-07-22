using JLDatabase.Database.Models;
using JLDatabase.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDatabase.Authentication
{
    internal interface IAuthentication
    {
        InvalidAuthenticationStatus Authenticate(string[] fields);
    }
}
