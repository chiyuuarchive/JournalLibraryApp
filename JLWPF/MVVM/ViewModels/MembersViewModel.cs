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
    internal class MembersViewModel : ViewModelBase
    {
        private List<UIUser> _users;
        private MembersView _view;
        private string userKey;

        public MembersViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }

        public void InitializeView(MembersView view, Window window)
        {
            _view = view;

            userKey = string.Empty;
            UpdateTable();
            EnablePanelButtons(false);
        }

        private void UpdateTable()
        {
            _users = JLDatabaseInterface.FetchUsers().
                Select(u =>
            {
                UIUser uiUser = new();
                uiUser.Copy(u);
                return uiUser;
            }).ToList();

            DataGrid dg = _view.MembersDataGrid;
            dg.Columns.Clear();
            dg.ItemsSource = _users;
        }

        public void NavigateToHome()
        {
            UpdateViewCommand?.Execute("HomeView");
        }

        public void UpdateSelectedUser()
        {
            if (_view.MembersDataGrid.SelectedIndex != -1)
            {
                userKey = _users[_view.MembersDataGrid.SelectedIndex].Email;
                EnablePanelButtons(true);
            }
            else
            {
                userKey = string.Empty;
                EnablePanelButtons(false);
            }
        }

        public void ToggleVerifyStatus()
        {
            User u = JLDatabaseInterface.GetUserByKey(userKey);
            u.IsVerified = u.IsVerified ? false : true;
            JLDatabaseInterface.UpdateVerifiedUser(userKey, u);
            UpdateTable();
        }

        public void ToggleAdminStatus()
        {
            User u = JLDatabaseInterface.GetUserByKey(userKey);
            u.IsAdmin = u.IsAdmin ? false : true;
            JLDatabaseInterface.UpdateVerifiedUser(userKey, u);
            UpdateTable();
        }

        public void RemoveUser(Window window)
        {
            MainWindow mw = (MainWindow)window;
            if (mw.User == null)
                throw new Exception("Active user not defined!");

            UIUser? user = _users.FirstOrDefault(u => u.Email == userKey);
            if (user == null)
                throw new Exception("User not found");

            YesNoWindow dialog = new YesNoWindow(window, $"Confirm to delete user '{user.Name()}'");
            dialog.ShowDialog();
            if (dialog.Confirmed)
            {
                // Save key as it gets deleted when table is updated
                string tempKey = userKey;
                JLDatabaseInterface.RemoveUserByKey(userKey);
                UpdateTable();

                // If the logged in user is deleted log out immediatedly
                if (mw.User.Email == tempKey)
                    UpdateViewCommand?.Execute("LoginView");
            }
        }

        public void ViewDownloadLog(Window window)
        {
            // Get user to display
            UIUser? user = _users.FirstOrDefault(u => u.Email == userKey);
            if (user == null)
                throw new Exception("User in table not found");

            // Get log related to the user
            List<ArticleDownloadLog> log = JLDatabaseInterface.GetLogByUserKey(userKey);

            // Send the user to the dialog
            DownloadLogWindow dialog = new DownloadLogWindow(window, user, log);
            dialog.ShowDialog();
        }

        public void EnablePanelButtons(bool enabled)
        {
            _view.btnAdmin.IsEnabled = enabled;
            _view.btnVerify.IsEnabled = enabled;
            _view.btnRemoveMember.IsEnabled = enabled;
            _view.btnViewDownloadLog.IsEnabled = enabled;
        }

        private void ShowMessage(Window parent, string message)
        {
            MessageWindow mw = new MessageWindow(parent, message);
            mw.ShowDialog();
        }
    }
}