using JLDatabase;
using JLDatabase.Database.Models;
using System.Windows;
using System.Windows.Media.TextFormatting;

namespace JLWPF.Components
{
    /// <summary>
    /// Interaction logic for ViewArticleWindow.xaml
    /// </summary>
    public partial class ViewArticleWindow : Window
    {
        User _activeUser;
        Article _article;

        public ViewArticleWindow(Article article, User activeUser)
        {
            InitializeComponent();
            _article = article;
            _activeUser = activeUser;

            // Set article fields
            txtArticleTitle.Text = $"Article Title: {article.ArticleTitle}";
            txtAbstract.Text = article.Abstract;
            txtAuthors.Text = $"Author(s): {article.Author}";

            txtPublishedAt.Text = article.JournalTitle != string.Empty ? $"Published at: {article.JournalTitle}" : "Published at: Unspecified";
            txtCategory.Text = article.Category.ToString();

            // Set hyperlink
            txtSource.Visibility = Visibility.Hidden;
            txtSource.Text = article.Hyperlink;
        }

        private void btnSource_Click(object sender, RoutedEventArgs e)
        {
            if (_activeUser == null) return;

            if (txtSource.Visibility == Visibility.Hidden)
            {
                txtSource.Visibility = Visibility.Visible;
                ArticleDownloadLog log = new ArticleDownloadLog()
                {
                    Article = _article,
                    DownloadDateTime = DateTime.Now,
                };

                if (_activeUser.Log == null)
                    _activeUser.Log = new List<ArticleDownloadLog>();

                _activeUser.Log.Add(log);
                JLInterface.UpdateVerifiedUser(_activeUser.Email, _activeUser);
            }
        }
    }
}
