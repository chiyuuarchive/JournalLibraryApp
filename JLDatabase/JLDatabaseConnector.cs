using JLValidatorAPI;
using JLDatabase.Authentication;
using JLDatabase.Database.Models;
using JLDatabase.Managers;
using JLDatabase.Validators;
using Microsoft.Extensions.Options;

namespace JLDatabase
{
    public static class JLDatabaseConnector
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

        public static void UpdateUserDetails(string emailID, string[] fields, bool isVerified, out InvalidInputFieldStatus validateResult, out InvalidAuthenticationStatus authenticateResult)
        {
            IAuthentication authentication = new UserRegistrationAuthentication();
            IValidator validator = new UserRegistrationValidator();
            UserManager userManager = new UserManager();
            EntityFactory factory = new EntityFactory();

            validateResult = validator.ValidateFields(fields);
            authenticateResult = authentication.Authenticate(fields);

            if (validateResult != InvalidInputFieldStatus.None)
                return;

            User u = isVerified? factory.CreateVerifiedUser(fields) : factory.CreateUser(fields);

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

        public static void UpdateVerifiedUser(string emailID, User user)
        {
            UserManager userManager = new UserManager();
            userManager.ChangeAt(user, emailID);
        }

        public static List<Article> FetchArticles()
        {
            ArticleManager manager = new ArticleManager();
            return manager.Entities.Cast<Article>().ToList();
        }

        public static List<User> FetchUsers()
        {
            UserManager manager = new UserManager();
            return manager.Entities.Cast<User>().ToList();
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

        public static Article GetArticleById(int id)
        {
            ArticleManager articleManager = new ArticleManager();
            List<Article> articles = articleManager.Entities.Cast<Article>().ToList();
            Article? a = articles.FirstOrDefault(a => a.Id == id);

            if (a == null)
                throw new Exception("Can't find article");

            return a;
        }

        public static User GetUserByKey(string emailKey)
        {
            UserManager userManager = new UserManager();
            List<User> users = userManager.Entities.Cast<User>().ToList();
            User? u = users.FirstOrDefault(u => u.Email == emailKey);
            if (u == null)
                throw new Exception("Can't find user");

            return u;
        }

        public static List<ArticleDownloadLog> GetLogByUserKey(string emailKey)
        {
            UserManager manager = new UserManager();
            User? user = manager.Entities.Cast<User>().ToList().FirstOrDefault(u => u.Email == emailKey);
            if (user == null)
                throw new Exception("User not found");

            return manager.Log.Where(l => l.UserId == user.Id).ToList();
        }

        public static void RemoveArticleByKey(string hyperlinkKey)
        {
            ArticleManager manager = new ArticleManager();
            manager.RemoveAt(hyperlinkKey);
        }

        public static void RemoveUserByKey(string emailKey)
        {
            UserManager manager = new UserManager();
            manager.RemoveAt(emailKey);
        }

        public static void UpdateArticleDetails(string hyperlinkID, string[]fields, out InvalidInputFieldStatus validateResult, out InvalidAuthenticationStatus authenticateResult)
        {
            IAuthentication authentication = new ArticleRegistrationAuthentication();
            IValidator validator = new ArticleRegistrationValidator();
            ArticleManager manager = new ArticleManager();
            EntityFactory entityFactory = new EntityFactory();

            validateResult = validator.ValidateFields(fields);
            authenticateResult = authentication.Authenticate(fields);
            
            if (validateResult != InvalidInputFieldStatus.None)
                return;

            Article article = entityFactory.CreateArticle(fields);

            // If hyperlink is different replace article details of the old hyperlink
            if (authenticateResult == InvalidAuthenticationStatus.None)
            {
                manager.Register(article);
                manager.RemoveAt(hyperlinkID);
            }

            // Handle case if same hyperlink is recognized
            if (authenticateResult == InvalidAuthenticationStatus.HyperlinkAlreadyRegistered)
            {
                if (fields[(int)ArticleFieldTypes.Registration.Hyperlink] == hyperlinkID) 
                {
                    manager.ChangeAt(article, hyperlinkID);
                    authenticateResult = InvalidAuthenticationStatus.None;
                }
            }
        }
    }
}
