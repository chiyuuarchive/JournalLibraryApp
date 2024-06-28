using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLDatabase.Database.Data;
using JLDatabase.Database.Models;

namespace JLDatabase.Experimental
{
    internal class UserRegistration : IRegister
    {
        public bool Register(string[] fields, out string errorMessage)
        {
            errorMessage = string.Empty;

            using (var dbContext = new JournalLibraryDbContext())
            {
                User user = new User
                {
                    //IsAdmin = bool.TryParse(fields[(int)])
                };
            }

            return true;
        }
    }
}
