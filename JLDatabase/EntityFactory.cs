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

        public string[] CreateUserStringArray(User user)
        {
            string[] fields = new string[Enum.GetValues(typeof(UserFieldTypes.Registration)).Length];

            fields[(int)UserFieldTypes.Registration.IsAdmin] = user.IsAdmin.ToString();
            fields[(int)UserFieldTypes.Registration.FirstName] = user.FirstName;
            fields[(int)UserFieldTypes.Registration.LastName] = user.LastName;
            fields[(int)UserFieldTypes.Registration.Password] = user.Password;
            fields[(int)UserFieldTypes.Registration.Email] = user.Email;
            return fields;
        }

        public User CreateVerifiedUser(string[] fields)
        {
            User user = new User
            {
                RegisteredAt = DateTime.Now,
                IsAdmin = bool.Parse(fields[(int)UserFieldTypes.Registration.IsAdmin]),
                IsVerified = true,
                FirstName = fields[(int)UserFieldTypes.Registration.FirstName],
                LastName = fields[(int)UserFieldTypes.Registration.LastName],
                Password = fields[(int)UserFieldTypes.Registration.Password],
                Email = fields[(int)UserFieldTypes.Registration.Email],
                LastTimeLoggedIn = DateTime.Now,
                Log = new List<ArticleDownloadLog>()
            };
            return user;
        }

        public Article CreateArticle(string[] fields)
        {
            Article article = new Article
            {
                RegisteredAt = DateTime.Now,
                Category = (IEEECategory)int.Parse(fields[(int)ArticleFieldTypes.Registration.IEEECategory]),
                Author = fields[(int)ArticleFieldTypes.Registration.Author],
                ArticleTitle = fields[(int)ArticleFieldTypes.Registration.ArticleTitle],
                Abstract = fields[(int)ArticleFieldTypes.Registration.Abstract],
                JournalTitle = fields[(int)ArticleFieldTypes.Registration.JournalTitle],
                Hyperlink = fields[(int)ArticleFieldTypes.Registration.Hyperlink]
            };
            return article;
        }
    }
}
