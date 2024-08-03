namespace JLValidatorAPI
{
    public class RegexValidatorPatterns
    {
        /// <summary>
        /// Generic regex patterns
        /// </summary>
        public const string BooleanString = "^(True|False)$";

        public const string LettersOnly = "^[a-zA-Z]+$";

        // Example: username@domain.com
        public const string Email = @"^[a-zA-Z0-9._]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        // Password must have 1 uppercase, 1 lowercase letter and 1 digit. Minimum length at 6
        public const string Password = @"^(?!.*\s)(?=.*\d)(?=.*[a-z]).{6,}$";

        /// <summary>
        /// Regex patterns for article
        /// </summary>
        // Follows the bibliographic format of author names (e.g. "John Doe, Tee Bee")
        public const string AuthorNameFormat = @"^([A-Za-z]+(?:-[A-Za-z]+)?(?:\s[A-Za-z]\.)?(?:\s[A-Za-z]+)?\s[A-Za-z]+(?:-[A-Za-z]+)?)(?:,\s[A-Za-z]+(?:-[A-Za-z]+)?(?:\s[A-Za-z]\.)?(?:\s[A-Za-z]+)?\s[A-Za-z]+(?:-[A-Za-z]+)?)*$";

        //public const string AuthorNameFormat = @"^([A-Z][a-z]+( [A-Z][a-z]+)*(, )?)+$";
        public const string YearOfPublication = @"\b\d{4}\b";

        public const string ArticleTitle = @"^[A-Za-z0-9.,:;!?'()\[\]{}&\- ]+$";
        public const string JournalTitle = @"^[A-Za-z0-9.,:;!?'""()&\- ]+$";

        // Hyperlink
        public const string Hyperlink = @"\b((https?:\/\/)?(www\.)?[a-zA-Z0-9-]+(\.[a-zA-Z]{2,})+(/[a-zA-Z0-9-._~:/?#@!$&'()*+,;=%]*)?)\b";

        //public const string Hyperlink = @"^(https?:\/\/)?(www\.)[a-zA-Z0-9\-]+\.[a-zA-Z]{2,}(\/[^\s]*)?$";
    }
}