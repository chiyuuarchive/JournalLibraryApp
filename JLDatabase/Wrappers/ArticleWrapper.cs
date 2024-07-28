using JLValidatorAPI;
using JLDatabase.Managers;
using JLDatabase.Validators;
using JLDatabase.Database.Models;

namespace JLDatabase.Wrappers
{
    internal class ArticleWrapper
    {
        EntityFactory _factory;
        IValidator _validator;
        IEntityManager _articleManager;
        public string FailRegistrationMessage(object entity) => $"Article with same source ({((Article)entity).Hyperlink}) is already registered";
        public string SuccessRegistrationMessage(object entity) => $"'{((Article)entity).ArticleTitle}' registered to database";
        public string FailRemoveAtMessage(object entity) => $"Article with source link: ({(string)entity}) doesn't exist";
        public string SuccessRemoveAtMessage(object entity) => $"Article with source link ({(string)entity}) removed from database";
        public string FailChangeAtMessage(object entity) => $"Unable to update article information in '{(string)entity}'";
        public string SuccessChangeAtMessage(object entity) => $"'{(string)entity}' has been updated";
        public ArticleWrapper(EntityFactory factory, IEntityManager articleManager)
        {
            _factory = factory;
            _validator = new ArticleRegistrationValidator();
            _articleManager = articleManager;
        }

        public void ChangeArticle(string[] fields, string hyperlinkID)
        {
            string errorMessage = string.Empty;
            // Check if input is valid for registration
            _validator.ValidateFieldsExperimental(fields, out errorMessage);

            if (errorMessage == string.Empty)
            {
                // Create article object and change article in database
                Article a = _factory.CreateArticle(fields);
                errorMessage = _articleManager.ChangeAt(a, hyperlinkID) ? SuccessChangeAtMessage(a.ArticleTitle) :FailChangeAtMessage(a.ArticleTitle);
            }

            if (errorMessage != string.Empty)
                Console.WriteLine(errorMessage);
        }

        public void RegisterArticle(string[] fields)
        {
            string errorMessage = string.Empty;
            // Check if input is valid for registration
            _validator.ValidateFieldsExperimental(fields, out errorMessage);

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
