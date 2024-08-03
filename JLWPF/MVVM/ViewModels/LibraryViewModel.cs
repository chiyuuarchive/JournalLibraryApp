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
    public class LibraryViewModel : ViewModelBase
    {
        private UserLibraryPanel _userLibraryPanel = null!;
        private AdminLibraryPanel _adminLibraryPanel = null!;
        private List<UIArticle> _articles = null!;

        private LibraryView _libraryView = null!;

        private string articleKey = null!;

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
            EnablePanelButtons(false);
        }

        private void EnablePanelButtons(bool enabled)
        {
            if (IsAdminLibraryPanelVisible)
            {
                _adminLibraryPanel.btnViewArticle.IsEnabled = enabled;
                _adminLibraryPanel.btnRemoveArticle.IsEnabled = enabled;
            }
            else
                _userLibraryPanel.btnViewArticle.IsEnabled = enabled;
        }

        public void NavigateToHome()
        {
            UpdateViewCommand?.Execute("HomeView");
        }

        private void UpdateTable()
        {
            _articles = JLDatabaseConnector.FetchArticles().
                Select(a =>
                {
                    UIArticle uiArticle = new();
                    uiArticle.Copy(a);
                    return uiArticle;
                }).ToList();

            DataGrid dg = _libraryView.ArticleDataGrid;
            dg.Columns.Clear();
            dg.ItemsSource = _articles;
        }

        public void UpdateSelectedArticle()
        {
            if (_libraryView.ArticleDataGrid.SelectedIndex != -1)
            {
                articleKey = _articles[_libraryView.ArticleDataGrid.SelectedIndex].Key();
                EnablePanelButtons(true);
            }
            else
            {
                articleKey = string.Empty;
                EnablePanelButtons(false);
            }
        }

        public void ViewSelectedArticle(Window window)
        {
            MainWindow mw = (MainWindow)window;
            if (mw.User == null)
                throw new Exception("User not defined");

            // Get Article to display
            Article a = JLDatabaseConnector.GetArticleByKey(articleKey);

            // Send the article to the dialog
            ViewArticleWindow w = new(a, mw.User);
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
            UIArticle? articleToRemove = _articles.FirstOrDefault(a => a.Key() == articleKey);
            if (articleToRemove == null)
                throw new Exception("Selected article does not exist");

            YesNoWindow dialog = new(window, $"Confirm to delete article '{articleToRemove.Title}'");
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

            ArticleDetailsWindow editArticle = new(window, this, a);
            editArticle.ShowDialog();

            if (editArticle.Confirmed)
                UpdateTable();
        }

        #endregion AdminLibraryPanel

        #region ArticleDetailsWindow

        public void CloseArticleDetailsWindow(ArticleDetailsWindow window)
        {
            articleKey = string.Empty;
            EnablePanelButtons(false);
            window.Close();
        }

        public void SubmitArticleDetails(ArticleDetailsWindow window)
        {
            string[] fields = new string[Enum.GetValues(typeof(ArticleFieldTypes.Registration)).Length];
            fields[(int)ArticleFieldTypes.Registration.ArticleTitle] = window.txtArticleTitle.Text;
            fields[(int)ArticleFieldTypes.Registration.Author] = window.txtAuthors.Text;
            fields[(int)ArticleFieldTypes.Registration.Abstract] = window.txtAbstract.Text;
            fields[(int)ArticleFieldTypes.Registration.JournalTitle] = window.txtJournalTitle.Text;
            fields[(int)ArticleFieldTypes.Registration.YearOfPublication] = window.txtYearOfPublication.Text;
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

                case InvalidInputFieldStatus.YearOfPublication:
                    ShowMessage(window.Owner, "Invalid year format");
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
            switch (authenticateResult)
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
            MessageWindow mw = new(parent, message);
            mw.ShowDialog();
        }

        #endregion ArticleDetailsWindow
    }
}