using JLDatabase;
using JLDatabase.Database.Models;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
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
            SetText(txtArticleTitle, "Article Title", article.ArticleTitle);
            txtAbstract.Text = article.Abstract;

            SetText(txtAuthors, "Author(s):", article.Author);
            SetText(txtPublishedAt, "Published at:", article.JournalTitle != string.Empty? article.JournalTitle : "Unspecified");
            SetText(txtCategory, "Category:", article.Category.ToString());

            // Set hyperlink
            txtSource.Visibility = Visibility.Hidden;
            string url = $"{article.Hyperlink}";
            url = url.StartsWith("www.") ? $"https://{url}" : url;
            linkSource.NavigateUri = new Uri(url);
            linkSource.Inlines.Add(article.Hyperlink);
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
                JLDatabaseConnector.UpdateVerifiedUser(_activeUser.Email, _activeUser);
            }
        }

        private void linkSource_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }

        void SetText(TextBlock txt, string title, string content)
        {
            Bold boldText = new Bold(new Run(title));
            Run normalText = new Run(content);
            txt.Text = string.Empty;
            txt.Inlines.Add(boldText);
            txt.Inlines.Add(new LineBreak());
            txt.Inlines.Add(normalText);
        }
    }
}
