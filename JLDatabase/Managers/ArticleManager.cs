using JLDatabase.Database.Data;
using JLDatabase.Database.Models;

namespace JLDatabase.Managers
{
    internal class ArticleManager : IEntityManager
    {
        private readonly List<Article> _articles;
        public ICollection<object> Entities => new List<object>(_articles);

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
            using var dbContext = new JournalLibraryDbContext();
            dbContext.Database.EnsureCreated();
            foreach (var article in dbContext.Articles)
                _articles.Add(article);
        }

        public bool Register(object entity)
        {
            try
            {
                Article article = (Article)entity;
                // Verify unique source/hyperlink
                Article? sameArticle = _articles.SingleOrDefault(a => a.Hyperlink == article.Hyperlink);
                if (sameArticle != null) return false;

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

                    // Find logs related to the specific article and remove
                    var log = dbContext.ArticleDownloadLog.Where(l => l.ArticleId == articleToRemove.Id).ToList();
                    dbContext.ArticleDownloadLog.RemoveRange(log);

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