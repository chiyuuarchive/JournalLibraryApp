using JLAuthenticationAPI;
using JLDatabase.Wrappers;
using JLDatabase.Managers;
using JLDatabase.Database.Models;

namespace JLDatabase
{
    internal class Program
    {
        User? activeUser;

        private static void Main(string[] args)
        {
            //TestUserRegistrationOperations();
            //TestArticleRegistrationOperations();
        }

        static void TestUserRegistrationOperations()
        {
            Console.WriteLine("Attempt registering user...");

            string[] mockUserData =
                [
                    "False",
                    "User",                     // Can be changed by user
                    "Doe",                      // Can be changed by user
                    "user@gmail.com",       // Can be changed by user
                    "Abc123",                   // Can be changed by user
                ];

            EntityFactory factory = new EntityFactory();
            IEntityManager userManager = new UserManager();
            UserWrapper userWrapper = new UserWrapper(factory, userManager);

            // Test registration
            userWrapper.RegisterUser(mockUserData);

            // Test deletion
            //userWrapper.UnregisterUser("john_doe@gmail.com");

            // Create a mock user object and test db change
            //mockUserData[2] = "Does";
            //userWrapper.ChangeUser(mockUserData, "john_doe@gmail.com");
        }

        static void TestArticleRegistrationOperations()
        {
            Console.WriteLine("Attempt registering article...");

            string[] mockArticleData =
                [
                    ((int)IEEECategory.Bioengineering).ToString(),
                    "John Doe, Tee Bee",      // Create a name formatter that validates both first and last name!
                    "Capture the Essence of AI tools",     
                    "Placeholder text for abstract",       
                    "Science",              
                    "www.example.com"       
                ];
            EntityFactory factory = new EntityFactory();
            IEntityManager articleManager = new ArticleManager();
            ArticleWrapper articleWrapper = new ArticleWrapper(factory, articleManager);

            // Test registration
            articleWrapper.RegisterArticle(mockArticleData);

            // Test deletion
            //articleWrapper.UnregisterArticle("www.example.com");

            // Change article information and test db change
            mockArticleData[1] = "John Han";
            articleWrapper.ChangeArticle(mockArticleData, "www.example.com");
        }
    }
}