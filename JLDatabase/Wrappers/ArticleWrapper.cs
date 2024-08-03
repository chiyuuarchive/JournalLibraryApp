using JLDatabase.Database.Models;
using JLDatabase.Managers;
using JLDatabase.Validators;

namespace JLDatabase.Wrappers
{
    internal class ArticleWrapper(EntityFactory factory, IEntityManager articleManager)
    {
        private readonly EntityFactory _factory = factory;
        private readonly ArticleRegistrationValidator _validator = new();
        private readonly IEntityManager _articleManager = articleManager;

        public string FailRegistrationMessage(object entity) => $"Article with same source ({((Article)entity).Hyperlink}) is already registered";

        public string SuccessRegistrationMessage(object entity) => $"'{((Article)entity).ArticleTitle}' registered to database";

        public string FailRemoveAtMessage(object entity) => $"Article with source link: ({(string)entity}) doesn't exist";

        public string SuccessRemoveAtMessage(object entity) => $"Article with source link ({(string)entity}) removed from database";

        public string FailChangeAtMessage(object entity) => $"Unable to update article information in '{(string)entity}'";

        public string SuccessChangeAtMessage(object entity) => $"'{(string)entity}' has been updated";

        public void ChangeArticle(string[] fields, string hyperlinkID)
        {
            // Check if input is valid for registration
            _validator.ValidateFieldsExperimental(fields, out string errorMessage);

            if (errorMessage == string.Empty)
            {
                // Create article object and change article in database
                Article a = _factory.CreateArticle(fields);
                errorMessage = _articleManager.ChangeAt(a, hyperlinkID) ? SuccessChangeAtMessage(a.ArticleTitle) : FailChangeAtMessage(a.ArticleTitle);
            }

            if (errorMessage != string.Empty)
                Console.WriteLine(errorMessage);
        }

        public void RegisterArticle(string[] fields)
        {
            // Check if input is valid for registration
            _validator.ValidateFieldsExperimental(fields, out string errorMessage);

            if (errorMessage == string.Empty)
            {
                Article a = _factory.CreateArticle(fields);
                errorMessage = _articleManager.Register(a) ? SuccessRegistrationMessage(a) : FailRegistrationMessage(a);
            }

            if (errorMessage != string.Empty)
                Console.WriteLine(errorMessage);
        }

        public void UnregisterArticle(string hyperlinkID)
        {
            string errorMessage = _articleManager.RemoveAt(hyperlinkID) ? SuccessRemoveAtMessage(hyperlinkID) : FailRemoveAtMessage(hyperlinkID);

            if (errorMessage != string.Empty)
                Console.WriteLine(errorMessage);
        }
    }
}