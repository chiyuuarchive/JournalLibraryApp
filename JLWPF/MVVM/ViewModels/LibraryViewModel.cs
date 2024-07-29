using JLDatabase;
using JLDatabase.Database.Models;
using JLWPF.Components;
using JLWPF.MVVM.Auxiliaries;
using JLWPF.MVVM.Core;
using JLWPF.MVVM.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JLWPF.MVVM.ViewModels
{
    class LibraryViewModel : ViewModelBase
    {
        UserLibraryPanel _userLibraryPanel;
        AdminLibraryPanel _adminLibraryPanel;
        List<DisplayArticleToLibrary> articles;
        string articleKey;

        private bool _isAdminLibraryPanelVisible;
        public bool IsUserLibraryPanelVisible => !_isAdminLibraryPanelVisible;
        public bool IsAdminLibraryPanelVisible
        {
            get => _isAdminLibraryPanelVisible;
            set
            {
                _isAdminLibraryPanelVisible = value;
                OnPropertyChanged(nameof(IsAdminLibraryPanelVisible));
                OnPropertyChanged(nameof(IsUserLibraryPanelVisible));
            }
        }

        public LibraryViewModel(ICommand command)
        {
            UpdateViewCommand = command;
        }

        public void InitializeView(LibraryView view, Window window)
        {
            MainWindow mw = (MainWindow)window;

            if (mw.User == null)
                throw new Exception("User not defined");

            // Get articles to display
            articles = JLInterface.FetchArticles().
                Select(a =>
                {
                    DisplayArticleToLibrary da = new();
                    da.Copy(a);
                    return da;
                }).ToList();


            // Set data grid
            DataGrid dg = view.ArticleDataGrid;
            dg.Columns.Clear();
            dg.Items.Clear();
            dg.ItemsSource = articles;

            // Update panels
            _userLibraryPanel = view.UserLibrary;
            _adminLibraryPanel = view.AdminLibrary;
            IsAdminLibraryPanelVisible = mw.User.IsAdmin;

            if (IsUserLibraryPanelVisible)
                _userLibraryPanel.EnableViewArticleButton(false);

        }

        public void NavigateToHome()
        {
            UpdateViewCommand?.Execute("HomeView");
        }

        public void UpdateSelectedArticle(LibraryView view)
        {
            if (view.ArticleDataGrid.SelectedIndex != -1)
            {
                articleKey = articles[view.ArticleDataGrid.SelectedIndex].Key();
                if (IsUserLibraryPanelVisible)
                    _userLibraryPanel.EnableViewArticleButton(true);
            }
            else
                articleKey = string.Empty;
        }

        public void ViewSelectedArticle(Window window)
        {
            MainWindow mw = (MainWindow)window;
            if (mw.User == null)
                throw new Exception("User not defined");

            // Get Article to display
            Article a = JLInterface.GetArticleByKey(articleKey);

            // Send the article to the dialog
            ViewArticleWindow w = new ViewArticleWindow(a, mw.User);
            w.Owner = mw;
            w.ShowDialog();
        }
    }
}
