using JLDatabase.Database.Models;
using JLDatabase.Managers;

namespace JLDatabase.Authentication
{
    internal class ArticleRegistrationAuthentication : IAuthentication
    {
        public InvalidAuthenticationStatus Authenticate(string[] fields)
        {
            IEntityManager manager = new ArticleManager();
            string hyperlink = fields[(int)ArticleFieldTypes.Registration.Hyperlink];

            List<Article> articles = manager.Entities.Cast<Article>().ToList();
            Article? article = articles.SingleOrDefault(a => a.Hyperlink == hyperlink);
            return article == null ? InvalidAuthenticationStatus.None : InvalidAuthenticationStatus.HyperlinkAlreadyRegistered;
        }
    }
}