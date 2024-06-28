// See https://aka.ms/new-console-template for more information

using JLAuthenticationAPI.Validation;
using JLDatabase.Experimental;

TestUserRegistration();

static void TestUserRegistration()
{
    Console.WriteLine("Attempt registering user...");

    // Implement registration
    UserRegistration registration = new UserRegistration();

    string[] mockUserData = new string[Enum.GetValues(typeof(UserFieldTypes.Registration)).Length];
    mockUserData =
        [
            "True",
            "John",
            "Doe",
            "johndoe@gmail.com",
            "abc123",
        ];

    // Validate fields
    


    // Register user to database
    registration.Register(mockUserData);
}