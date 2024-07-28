using JLValidatorAPI;
using JLDatabase.Authentication;
using JLDatabase.Database.Models;
using JLDatabase.Managers;
using JLDatabase.Validators;
using Microsoft.Extensions.Options;

namespace JLDatabase
{
    public static class JLInterface
    {
        public static void RegisterUser(string[] fields, out InvalidInputFieldStatus validateResult, out InvalidAuthenticationStatus authenticateResult)
        {
            IAuthentication authentication = new UserRegistrationAuthentication();
            IValidator validator = new UserRegistrationValidator();
            UserManager userManager = new UserManager();

            validateResult = new UserRegistrationValidator().ValidateFields(fields);
            authenticateResult = new UserRegistrationAuthentication().Authenticate(fields);

            if (validateResult == InvalidInputFieldStatus.None &&
                authenticateResult == InvalidAuthenticationStatus.None)
            {
                EntityFactory factory = new EntityFactory();
                userManager.Register(factory.CreateUser(fields));
            }
        }

        public static User? Login(string[] fields, out InvalidInputFieldStatus validateResult, out InvalidAuthenticationStatus authenticateResult)
        {
            IAuthentication authentication = new LoginAuthentication();
            IValidator validator = new LoginValidator();
            UserManager userManager = new UserManager();

            User? user = null;
            validateResult = validator.ValidateFields(fields);
            authenticateResult = authentication.Authenticate(fields);

            if (validateResult == InvalidInputFieldStatus.None &&
                authenticateResult == InvalidAuthenticationStatus.None)
            {
                string email = fields[(int)UserFieldTypes.Login.Email];
                string password = fields[(int)UserFieldTypes.Login.Password];

                // Try to find user 
                List<User> users = userManager.Entities.Cast<User>().ToList();
                user = users.SingleOrDefault(u => u.Email == email && u.Password == password);
            }

            return user;
        }

        public static void UpdateUserLoginTime(User u)
        {
            EntityFactory factory = new EntityFactory();
            IValidator validator = new UserRegistrationValidator();
            UserManager userManager = new UserManager();

            InvalidInputFieldStatus validateResult = validator.ValidateFields(factory.CreateUserStringArray(u));

            if (validateResult == InvalidInputFieldStatus.None)
                userManager.ChangeAt(u, u.Email);
            else
                throw new Exception("Active user has invalid details!");
        }

        public static void UpdateUserDetails(string emailID, string[] fields, out InvalidInputFieldStatus validateResult, out InvalidAuthenticationStatus authenticateResult)
        {
            IAuthentication authentication = new UserRegistrationAuthentication();
            IValidator validator = new UserRegistrationValidator();
            UserManager userManager = new UserManager();
            EntityFactory factory = new EntityFactory();

            validateResult = validator.ValidateFields(fields);
            authenticateResult = authentication.Authenticate(fields);

            if (validateResult != InvalidInputFieldStatus.None)
                return;

            User u = factory.CreateUser(fields);

            // If email is different replace the user details of the old email
            if (authenticateResult == InvalidAuthenticationStatus.None)
            {
                userManager.Register(u);
                userManager.RemoveAt(emailID);
            }

            // Handle case if same email is recognized
            if (authenticateResult == InvalidAuthenticationStatus.EmailAlreadyRegistered)
            {
                if (fields[(int)UserFieldTypes.Registration.Email] == emailID)
                {
                    // Change user details and reset authentication result
                    userManager.ChangeAt(u, emailID);
                    authenticateResult = InvalidAuthenticationStatus.None;
                }
            }
        }

        public static List<Article> FetchArticles()
        {
            ArticleManager articleManager = new ArticleManager();
            List<Article> articles = articleManager.Entities.Cast<Article>().ToList();
            return articles;
        }

        public static Article GetArticleByKey(string hyperlinkKey)
        {
            ArticleManager articleManager = new ArticleManager();
            List<Article> articles = articleManager.Entities.Cast<Article>().ToList();
            Article? a = articles.FirstOrDefault(a => a.Hyperlink == hyperlinkKey);
            
            if (a == null)
                throw new Exception("Can't find article");
            
            return a;
        }
    }
}
