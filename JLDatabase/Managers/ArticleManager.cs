using JLDatabase.Database.Data;
using JLDatabase.Database.Models;

namespace JLDatabase.Managers
{
    internal class ArticleManager : IEntityManager
    {
        ICollection<Article> _articles;
        public ICollection<object> Entities => new List<object>(_articles);

        public string FailRegistrationMessage(object entity) => $"Unable to register {((Article)entity).ArticleTitle}";
        public string SuccessRegistrationMessage(object entity) => $"{((Article)entity).ArticleTitle} registered to database";
        public string FailRemoveAtMessage(object entity) => $"Article with source link: {(string)entity} doesn't exist";
        public string SuccessRemoveAtMessage(object entity)
        {
            Article? a = _articles.SingleOrDefault(a => a.Hyperlink == (string)entity);
            return a == null ? $"Unknown article removed from database" : $"'{a.ArticleTitle}' removed from database";
        }
        public string FailChangeAtMessage(object entity) => $"Unable to update article information of {(string)entity}";
        public string SuccessChangeAtMessage(object entity) => $"{(string)entity} has been updated";

        public ArticleManager()
        {
            _articles = new List<Article>();
            InitializeManager();
        }

        public bool ChangeAt(object newArticle, string hyperlinkID)
        {

            try
            {
                // Find article to change
                Article article = (Article)newArticle;
                Article? articleToChange = _articles.SingleOrDefault(a => a.Hyperlink == hyperlinkID);
                if (articleToChange == null) return false;

                // Update database
                using (var dbContext = new JournalLibraryDbContext())
                {
                    Article a = dbContext.Articles.First(a => a == articleToChange);
                    a.Copy(article);
                    dbContext.SaveChanges();
                }

                // Update manager
                articleToChange.Copy(article);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return true;
        }


        public void InitializeManager()
        {
            using (var dbContext = new JournalLibraryDbContext())
            {
                dbContext.Database.EnsureCreated();
                foreach (var article in _articles)
                    _articles.Add(article);
            }
        }

        public bool Register(object entity)
        {
            try
            {
                Article article = (Article)entity;

                // Update database
                using (var dbContext = new JournalLibraryDbContext())
                {
                    dbContext.Articles.Add(article);
                    dbContext.SaveChanges();
                }

                // Update manager
                _articles.Add(article);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public bool RemoveAt(string hyperlinkID)
        {
            try
            {
                // Find article to remove
                Article? articleToRemove = _articles.SingleOrDefault(a => a.Hyperlink == hyperlinkID);
                if (articleToRemove == null) return false;

                // Update database
                using (var dbContext = new JournalLibraryDbContext())
                {
                    dbContext.Articles.Remove(articleToRemove);
                    dbContext.SaveChanges();
                }

                // Update manager
                _articles.Remove(articleToRemove);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
            return true;
        }
    }
}
