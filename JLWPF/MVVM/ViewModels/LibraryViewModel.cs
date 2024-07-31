using JLDatabase;
using JLDatabase.Database.Models;
using JLWPF.Components;
using JLWPF.MVVM.Auxiliaries;
using JLWPF.MVVM.Core;
using JLWPF.MVVM.Views;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JLWPF.MVVM.ViewModels
{
    public class LibraryViewModel : ViewModelBase
    {
        UserLibraryPanel _userLibraryPanel;
        AdminLibraryPanel _adminLibraryPanel;
        List<DisplayArticleToLibrary> articles;

        LibraryView _libraryView;
        
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
            articleKey = string.Empty;

            if (mw.User == null)
                throw new Exception("User not defined");

            // Set members
            _libraryView = view;
            _userLibraryPanel = view.UserLibrary;
            _adminLibraryPanel = view.AdminLibrary;
            IsAdminLibraryPanelVisible = mw.User.IsAdmin;

            UpdateTable();
            DisablePanelButtons();
            
        }

        private void DisablePanelButtons()
        {
            if (IsAdminLibraryPanelVisible)
            {
                _adminLibraryPanel.EnableRemoveArticleButton(false);
                _adminLibraryPanel.EnableViewArticleButton(false);
            }
            else
                _userLibraryPanel.EnableViewArticleButton(false);


            _libraryView.ArticleDataGrid.SelectedIndex = -1;
        }
        private void EnablePanelButtons()
        {
            if (IsAdminLibraryPanelVisible)
            {
                _adminLibraryPanel.EnableViewArticleButton(true);
                _adminLibraryPanel.EnableRemoveArticleButton(true);
            }
            else
                _userLibraryPanel.EnableViewArticleButton(true);
        }

        public void NavigateToHome()
        {
            UpdateViewCommand?.Execute("HomeView");
        }

        private void UpdateTable()
        {
            // Update articles
            articles = JLDatabaseConnector.FetchArticles().
                Select(a =>
                {
                    DisplayArticleToLibrary da = new();
                    da.Copy(a);
                    return da;
                }).ToList();

            DataGrid dg = _libraryView.ArticleDataGrid;
            dg.Columns.Clear();
            dg.ItemsSource = articles;
        }

        public void UpdateSelectedArticle(LibraryView view)
        {
            if (view.ArticleDataGrid.SelectedIndex != -1)
            {
                articleKey = articles[view.ArticleDataGrid.SelectedIndex].Key();
                EnablePanelButtons();
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
            Article a = JLDatabaseConnector.GetArticleByKey(articleKey);

            // Send the article to the dialog
            ViewArticleWindow w = new ViewArticleWindow(a, mw.User);
            w.Owner = mw;
            w.ShowDialog();
        }

        #region AdminLibraryPanel
        public void RemoveSelectedArticle(Window window)
        {
            MainWindow mw = (MainWindow)window;
            if (mw.User == null)
                throw new Exception("User not defined");

            // Remove article by selection
            DisplayArticleToLibrary? articleToRemove = articles.FirstOrDefault(a => a.Key() == articleKey);
            if (articleToRemove == null)
                throw new Exception("Selected article does not exist");

            YesNoWindow dialog = new YesNoWindow(window, $"Confirm to delete article '{articleToRemove.Title}'");
            dialog.ShowDialog();
            if (dialog.Confirmed)
            {
                JLDatabaseConnector.RemoveArticleByKey(articleKey);
                UpdateTable();
            }
        }

        public void AddEditSelectedArticle(Window window)
        {
            Article? a = null;
            if (articleKey != string.Empty)
                a = JLDatabaseConnector.GetArticleByKey(articleKey);

            ArticleDetailsWindow editArticle = new ArticleDetailsWindow(window, this, a);
            editArticle.ShowDialog();

            if (editArticle.Confirmed)
                UpdateTable();
        }
        #endregion


        #region ArticleDetailsWindow
        public void CloseArticleDetailsWindow(ArticleDetailsWindow window)
        {
            articleKey = string.Empty;
            DisablePanelButtons();
            window.Close();
        }
        public void SubmitArticleDetails(ArticleDetailsWindow window)
        {
            string[] fields = new string[Enum.GetValues(typeof(ArticleFieldTypes.Registration)).Length];
            fields[(int)ArticleFieldTypes.Registration.ArticleTitle] = window.txtArticleTitle.Text;
            fields[(int)ArticleFieldTypes.Registration.Author] = window.txtAuthors.Text;
            fields[(int)ArticleFieldTypes.Registration.Abstract] = window.txtAbstract.Text;            
            fields[(int)ArticleFieldTypes.Registration.JournalTitle] = window.txtJournalTitle.Text;
            fields[(int)ArticleFieldTypes.Registration.Hyperlink] = window.txtHyperlink.Text;
            fields[(int)ArticleFieldTypes.Registration.IEEECategory] = window.cmbCategory.SelectedIndex.ToString();

            InvalidInputFieldStatus validateResult = InvalidInputFieldStatus.None;
            InvalidAuthenticationStatus authenticateResult = InvalidAuthenticationStatus.None;

            JLDatabaseConnector.UpdateArticleDetails(articleKey, fields, out validateResult, out authenticateResult);

            // Handle validation results
            switch (validateResult)
            {
                case InvalidInputFieldStatus.ArticleTitle:
                    ShowMessage(window.Owner, "Invalid article title");
                    return;
                case InvalidInputFieldStatus.Author:
                    ShowMessage(window.Owner, "Invalid author format");
                    return;
                case InvalidInputFieldStatus.Abstract:
                    throw new Exception("Invalid abstract");
                case InvalidInputFieldStatus.JournalTitle:
                    ShowMessage(window.Owner, "Invalid journal title");
                    return;
                case InvalidInputFieldStatus.Hyperlink:
                    ShowMessage(window.Owner, "Invalid hyperlink format");
                    return;
                case InvalidInputFieldStatus.IEEECategory:
                    throw new Exception("Invalid category");
                default:
                    break;
            }

            // handle authentication result
            switch(authenticateResult)
            {
                case InvalidAuthenticationStatus.None:
                    ShowMessage(window.Owner, "Article details successfully updated!");
                    window.Confirmed = true;
                    CloseArticleDetailsWindow(window);
                    break;
                case InvalidAuthenticationStatus.HyperlinkAlreadyRegistered:
                    ShowMessage(window.Owner, "Hyperlink already registered");
                    return;
                default:
                    throw new Exception("Unexpected authentication error from LibraryViewModel.cs");
            }
        }

        private void ShowMessage(Window parent, string message)
        {
            MessageWindow mw = new MessageWindow(parent, message);
            mw.ShowDialog();
        }
        #endregion
    }
}
