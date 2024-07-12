using JLAuthenticationAPI;
using JLDatabase.Wrappers;
using JLDatabase.Managers;

namespace JLDatabase
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //TestUserRegistrationOperations();
        }

        static void TestUserRegistrationOperations()
        {
            Console.WriteLine("Attempt registering user...");

            string[] mockUserData =
                [
                    "True",
                    "John",
                    "Doe",
                    "john_doe@gmail.com",
                    "Abc123",
                ];

            EntityFactory factory = new EntityFactory();
            IEntityManager userManager = new UserManager();
            UserWrapper userWrapper = new UserWrapper(factory, userManager);

            // Test registration
            userWrapper.RegisterUser(mockUserData);

            // Test deletion
            userWrapper.UnregisterUser("john_doe@gmail.com");

            // Create a mock user object and test db change
            mockUserData[3] = "john.doe@hotmail.com";
            userWrapper.ChangeUser(mockUserData, "john_doe@gmail.com");
        }
    }
}