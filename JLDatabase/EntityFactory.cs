using JLAuthenticationAPI;
using JLDatabase.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLDatabase
{
    public class EntityFactory
    {
        public User CreateUser(string[] fields)
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
            return user;
        }

        //Article CreateArticle(string[] fields)
        //{
        //    Article article = new Article
        //    {

        //    }
        //}
    }
}
