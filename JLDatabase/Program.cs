﻿using JLValidatorAPI;
using JLDatabase.Wrappers;
using JLDatabase.Managers;
using JLDatabase.Database.Models;

namespace JLDatabase
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //TestUserRegistrationOperations();
            TestArticleRegistrationOperations();
        }

        static void TestUserRegistrationOperations()
        {
            Console.WriteLine("Attempt registering user...");

            string[] mockUserData = new string[Enum.GetValues(typeof(UserFieldTypes.Registration)).Length];
            mockUserData[(int)UserFieldTypes.Registration.IsAdmin] = "True";
            mockUserData[(int)UserFieldTypes.Registration.FirstName] = "Admin";
            mockUserData[(int)UserFieldTypes.Registration.LastName] = "Doe";
            mockUserData[(int)UserFieldTypes.Registration.Email] = "admin@gmail.com";
            mockUserData[(int)UserFieldTypes.Registration.Password] = "Abc123";

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

            string[] mockArticleData = new string[Enum.GetValues(typeof(ArticleFieldTypes.Registration)).Length];
            mockArticleData[(int)ArticleFieldTypes.Registration.IEEECategory] = ((int)IEEECategory.Robotics_ControlSystems).ToString();
            mockArticleData[(int)ArticleFieldTypes.Registration.Author] = "Jane Doe";
            mockArticleData[(int)ArticleFieldTypes.Registration.ArticleTitle] = "Simulation of a four-legged landing rover";
            mockArticleData[(int)ArticleFieldTypes.Registration.Abstract] = "Placeholder text for abstract";
            mockArticleData[(int)ArticleFieldTypes.Registration.JournalTitle] = "Nature";
            mockArticleData[(int)ArticleFieldTypes.Registration.Hyperlink] = "www.nature.com/simcategory";

            EntityFactory factory = new EntityFactory();
            IEntityManager articleManager = new ArticleManager();
            ArticleWrapper articleWrapper = new ArticleWrapper(factory, articleManager);

            // Test registration
            articleWrapper.RegisterArticle(mockArticleData);

            // Test deletion
            //articleWrapper.UnregisterArticle("www.example.com");

            // Change article information and test db change
            //mockArticleData[1] = "John Han";
            //articleWrapper.ChangeArticle(mockArticleData, "www.example.com");
        }
    }
}