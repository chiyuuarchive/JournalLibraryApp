using JLDatabase;
using JLDatabase.Database.Models;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace JLWPF.Components
{
    /// <summary>
    /// Interaction logic for ViewArticleWindow.xaml
    /// </summary>
    public partial class ViewArticleWindow : Window
    {
        private User _activeUser;
        private Article _article;

        public ViewArticleWindow(Article article, User activeUser)
        {
            InitializeComponent();
            UIHeader.Owner = this;

            _article = article;
            _activeUser = activeUser;

            // Set article fields
            SetText(txtArticleTitle, "Article Title", article.ArticleTitle);
            string? abs = article.Abstract;
            if (abs != null)
                txtAbstract.Text = TruncateStringToWords(abs, 250);

            SetText(txtAuthors, "Author(s):", article.Author);
            SetText(txtPublishedAt, "Published at:", article.JournalTitle != string.Empty ? article.JournalTitle : "Unspecified");
            SetText(txtYearOfPublication, "Year of Publication:", article.YearOfPublication);
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
                    ArticleId = _article.Id,
                    UserId = _activeUser.Id,
                    DownloadDateTime = DateTime.Now,
                };

                if (_activeUser.Log == null)
                    _activeUser.Log = new List<ArticleDownloadLog>();

                _activeUser.Log.Add(log);
                JLDatabaseInterface.UpdateVerifiedUser(_activeUser.Email, _activeUser);
            }
        }

        private void linkSource_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }

        private void SetText(TextBlock txt, string title, string content)
        {
            Bold boldText = new Bold(new Run(title));
            Run normalText = new Run(content);
            txt.Text = string.Empty;
            txt.Inlines.Add(boldText);
            txt.Inlines.Add(new LineBreak());
            txt.Inlines.Add(normalText);
        }

        private string TruncateStringToWords(string input, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            var words = input.Split(" ").ToList();

            if (words.Count <= maxLength)
                return input;

            return $"{string.Join(" ", words.Take(maxLength))}...";
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}