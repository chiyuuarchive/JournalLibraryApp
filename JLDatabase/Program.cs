using JLAuthenticationAPI;
using JLDatabase.Database.Models;
using JLDatabase.Managers;
using JLDatabase.Validation;

namespace JLDatabase
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TestUserRegistration();
        }

        static void TestUserRegistration()
        {
            Console.WriteLine("Attempt registering user...");

            #region Completed tests
            // Implement registration
            EntityFactory factory = new EntityFactory();
            IValidator userRegistrationValidation = new UserRegistrationValidation();
            IEntityManager userManager = new UserManager(factory);

            string[] mockUserData =
                [
                    "True",
                    "John",
                    "Doe",
                    "john_doe@gmail.com",
                    "Abc123",
                ];

            // Validate fields
            string errorMessage = string.Empty;
            userRegistrationValidation.Validate(mockUserData, out errorMessage);

            if (errorMessage == string.Empty)
            {
                Console.WriteLine("Validation completed!");

                // Register user to database
                userManager.Register(mockUserData);

            }
            else
                Console.WriteLine(errorMessage);


            // Test deletion
            //Console.WriteLine(userManager.RemoveAt("john_doe@gmail.com") ? "Deletion completed" : "Deletion failed");


            // Create a mock user object and test db change
            mockUserData[3] = "john.doe@hotmail.com";
            User u = factory.CreateUser(mockUserData);
            if (!userManager.ChangeAt(u, "john_doe@gmail.com")) Console.WriteLine("Failed changing user");
            Console.WriteLine("User changed!");

            #endregion
        }
    }
}