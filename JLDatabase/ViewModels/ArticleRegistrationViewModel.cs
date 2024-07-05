using JLDatabase.Validation;

namespace JLDatabase.ViewModels
{
    internal class ArticleRegistrationViewModel
    {
        ArticleRegistrationValidation _validation;

        public ArticleRegistrationViewModel(ArticleRegistrationValidation validation)
        {
            _validation = validation;
        }
    }
}
