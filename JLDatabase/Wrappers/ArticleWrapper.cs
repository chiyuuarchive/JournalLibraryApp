using JLAuthenticationAPI;
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
            _validator.ValidateFields(fields, out errorMessage);

            if (errorMessage == string.Empty)
            {
                // Create article object and change article in database
                Article a = _factory.CreateArticle(fields);
                errorMessage = _articleManager.ChangeAt(a, hyperlinkID) ? _articleManager.SuccessChangeAtMessage(a.ArticleTitle) :_articleManager.FailChangeAtMessage(a.ArticleTitle);
            }

            if (errorMessage != string.Empty)
                Console.WriteLine(errorMessage);
        }

        public void RegisterArticle(string[] fields)
        {
            string errorMessage = string.Empty;
            // Check if input is valid for registration
            _validator.ValidateFields(fields, out errorMessage);

            if (errorMessage == string.Empty)
            {
                Article a = _factory.CreateArticle(fields);
                errorMessage = _articleManager.Register(a) ? _articleManager.SuccessRegistrationMessage(a) : _articleManager.FailRegistrationMessage(a);
            }

            if (errorMessage != string.Empty)
                Console.WriteLine(errorMessage);
        }

        public void UnregisterArticle(string hyperlinkID)
        {
            string errorMessage = _articleManager.RemoveAt(hyperlinkID) ? _articleManager.SuccessRemoveAtMessage(hyperlinkID) : _articleManager.FailRemoveAtMessage(hyperlinkID);

            if (errorMessage != string.Empty)
                Console.WriteLine(errorMessage);
        }
    }
}
