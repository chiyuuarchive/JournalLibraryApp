using JLAuthenticationAPI;
using JLDatabase.Database.Data;
using JLDatabase.Database.Models;

namespace JLDatabase.Validators
{
    internal class ArticleRegistrationValidator : IValidator
    {
        private const string invalidIEEECategoryMsg = "Category is unspecified/ incorrect";
        private const string invalidAuthorMsg = "Invalid name format (rf. to bibliographic format, e.g. 'John Doe, Tee Bee')";
        private const string invalidArticleTitleMsg = "Invalid article title (e.g. The Future of AI: Trends & Predictions)";
        private const string invalidJournalTitleMsg = "Invalid journal title (e.g. Journal of Machine Learning Research)";
        private const string invalidHyperlinkMsg = "Invalid link address to source (e.g. www.example.com)";
        private const string hyperlinkAlreadyRegistered = "Same source link has already been registered";

        // Field validator delegates
        ValidateRequiredField _validateRequiredField;
        ValidateFieldWithinIntBounds _validateFieldWithinIntBounds;
        ValidateMatchPattern _validateMatchPattern;

        FieldValidator _fieldValidator;
        public FieldValidator Validator => _fieldValidator;

        public ArticleRegistrationValidator()
        {
            _validateRequiredField = FieldValidators.ValidateRequiredField;
            _validateFieldWithinIntBounds = FieldValidators.ValidateFieldBelowIntValue;
            _validateMatchPattern = FieldValidators.ValidateMatchPattern;

            _fieldValidator = new FieldValidator(ValidateFields);
        }

        public bool ValidateFields(string[] fields, out string errorMessage)
        {
            errorMessage = string.Empty;
            int enumLength = Enum.GetValues(typeof(ArticleFieldTypes.Registration)).Length;

            bool isPublishedInJournal = _validateRequiredField(fields[(int)ArticleFieldTypes.Registration.JournalTitle]);

            for (int i = 0; i < enumLength; i++)
            {
                ArticleFieldTypes.Registration fieldType = (ArticleFieldTypes.Registration)i;
                switch (fieldType)
                {
                    case ArticleFieldTypes.Registration.IEEECategory:
                        // Check if field is specified
                        errorMessage = _validateRequiredField(fields[i]) ? errorMessage : "Choose a category";
                        // Verify category number is within bounds
                        int val = int.Parse(fields[i]);
                        errorMessage = _validateFieldWithinIntBounds(val, 0, enumLength - 1)? errorMessage : invalidIEEECategoryMsg;
                        break;
                    case ArticleFieldTypes.Registration.Author:
                        // Check if author is defined
                        errorMessage = _validateRequiredField(fields[i]) ? errorMessage : "Author not defined";
                        // Validate correct name format
                        errorMessage = _validateMatchPattern(fields[i], RegexValidatorPatterns.AuthorNameFormat) ? errorMessage : invalidAuthorMsg;
                        break;
                    case ArticleFieldTypes.Registration.ArticleTitle:
                        // Check if title is defined
                        errorMessage = _validateRequiredField(fields[i]) ? errorMessage : "Article title not defined";
                        // Validate article title format
                        errorMessage = _validateMatchPattern(fields[i], RegexValidatorPatterns.ArticleTitle) ? errorMessage : invalidArticleTitleMsg;
                        break;
                    case ArticleFieldTypes.Registration.JournalTitle:
                        if (isPublishedInJournal)
                            errorMessage = _validateMatchPattern(fields[i], RegexValidatorPatterns.JournalTitle) ? errorMessage : invalidJournalTitleMsg;
                        break;
                    case ArticleFieldTypes.Registration.Hyperlink:
                        // Check if a source link was provided
                        errorMessage = _validateRequiredField(fields[i]) ? errorMessage : "Provide a source link";
                        // Validate link address format
                        errorMessage = _validateMatchPattern(fields[i], RegexValidatorPatterns.Hyperlink) ? errorMessage : invalidHyperlinkMsg;
                        break;
                    default:
                        break;
                }
            }
            return string.IsNullOrEmpty(errorMessage);
        }
    }
}
