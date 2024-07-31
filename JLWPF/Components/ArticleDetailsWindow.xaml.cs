using JLDatabase.Database.Models;
using JLWPF.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JLWPF.Components
{
    public partial class ArticleDetailsWindow : Window
    {
        Article _article;
        string articleKey;
        LibraryViewModel _vm;
        private bool _confirmed;

        public bool Confirmed
        {
            get { return _confirmed; }
            set { _confirmed = value; }
        }

        public ArticleDetailsWindow(Window window, LibraryViewModel vm, Article? article)
        {
            InitializeComponent();
            Owner = window;
            _vm = vm;
            Confirmed = false;

            foreach (IEEECategory category in Enum.GetValues(typeof(IEEECategory)))
                cmbCategory.Items.Add(category);

            if (article != null)
            {
                _article = article;
                articleKey = article.Hyperlink;
                txtArticleTitle.Text = article.ArticleTitle;
                txtAuthors.Text = article.Author;
                txtAbstract.Text = article.Abstract;
                txtJournalTitle.Text = article.JournalTitle;
                txtHyperlink.Text = article.Hyperlink;

                int index = 0;
                foreach (IEEECategory category in Enum.GetValues(typeof(IEEECategory)))
                {
                    if (article.Category.ToString() == category.ToString())
                        cmbCategory.SelectedIndex = index;

                    index++;
                }
            }
            else
                cmbCategory.SelectedIndex = 0;
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            _vm.CloseArticleDetailsWindow(this);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtArticleTitle.Text = string.Empty;
            txtAuthors.Text = string.Empty;
            txtAbstract.Text = string.Empty;
            txtJournalTitle.Text = string.Empty;
            txtHyperlink.Text = string.Empty;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            _vm.SubmitArticleDetails(this);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _vm.CloseArticleDetailsWindow(this);
        }
    }
}
