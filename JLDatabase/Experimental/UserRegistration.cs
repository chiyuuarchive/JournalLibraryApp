using JLAuthenticationAPI.Validation;
using JLDatabase.Database.Data;
using JLDatabase.Database.Models;

namespace JLDatabase.Experimental
{
    internal class UserRegistration : IRegister
    {
        public void Register(string[] fields)
        {
            try
            {
                User user = new User
                {
                    RegisteredAt = DateTime.Now,
                    IsAdmin = bool.Parse(fields[(int)UserFieldTypes.Registration.IsAdmin]),
                    IsVerified = false,
                    FirstName = fields[(int)UserFieldTypes.Registration.FirstName],
                    LastName = fields[(int)UserFieldTypes.Registration.LastName],
                    Password = fields[(int)UserFieldTypes.Registration.Password],
                    Email = fields[(int)UserFieldTypes.Registration.Email],
                    LastTimeLoggedIn = DateTime.Now,
                    Log = new List<ArticleDownloadLog>()
                };

                using (var dbContext = new JournalLibraryDbContext())
                {
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                }
            } 
            catch (Exception e) 
            {
                Console.Error.WriteLine(e.Message.ToString());
            }
        }
    }
}
