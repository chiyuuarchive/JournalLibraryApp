using JLDatabase.Database.Models;
using JLWPF.MVVM.Auxiliaries;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace JLWPF.Components
{
    /// <summary>
    /// Interaction logic for DownloadLogWindow.xaml
    /// </summary>
    public partial class DownloadLogWindow : Window
    {
        public DownloadLogWindow(Window window, UIUser user)
        {
            InitializeComponent();
            Owner = window;
            SetText(txtName, "Name: ", user.Name());
            SetText(txtEmail, "Email: ", user.Email);
            SetText(txtLastTimeLoggedIn, "Last time logged in: ", user.LastTimeLoggedIn);

            ICollection<ArticleDownloadLog>? logs = user.Log();
            if (logs != null)
            {
                foreach (ArticleDownloadLog log in logs)
                {
                    string msg = $"Article: {log.Article}, Downloaded at {log.DownloadDateTime.ToString("dd/MM/yyyy, HH:mm:ss")}";
                    txtLog.Inlines.Add(msg);
                }
            }
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
