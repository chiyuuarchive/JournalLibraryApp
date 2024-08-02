using JLDatabase;
using JLDatabase.Database.Models;
using JLWPF.MVVM.Auxiliaries;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace JLWPF.Components
{
    /// <summary>
    /// Interaction logic for DownloadLogWindow.xaml
    /// </summary>
    public partial class DownloadLogWindow : Window
    {
        public DownloadLogWindow(Window window, UIUser user, List<ArticleDownloadLog> log)
        {
            InitializeComponent();
            Owner = window;
            ClearFields();
            SetText(txtName, "Name: ", user.Name());
            SetText(txtEmail, "Email: ", user.Email);
            SetText(txtLastTimeLoggedIn, "Last time logged in: ", user.LastTimeLoggedIn);

            // Print 6 latest log
            int counter = 6;
            for (int i = log.Count - 1; i >= 0; i--)
            {
                if (counter == 0) break;
                Article a = JLDatabaseConnector.GetArticleById(log[i].ArticleId);

                string msg = $"Article: {a.ArticleTitle}\nDownloaded at {log[i].DownloadDateTime.ToString("dd/MM/yyyy, HH:mm:ss")}";
                txtLog.Inlines.Add(msg);
                txtLog.Inlines.Add(new LineBreak());
                txtLog.Inlines.Add("=====");
                txtLog.Inlines.Add(new LineBreak());
                counter--;
            }
        }

        void ClearFields()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtLastTimeLoggedIn.Text = string.Empty;
            txtLog.Text = string.Empty;
        }

        void SetText(TextBlock txt, string title, string content)
        {
            Bold boldText = new Bold(new Run(title));
            Run normalText = new Run(content);
            txt.Text = string.Empty;
            txt.Inlines.Add(boldText);
            txt.Inlines.Add(normalText);
        }
    }
}
