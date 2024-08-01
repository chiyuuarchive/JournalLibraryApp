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
    class MembersViewModel : ViewModelBase
    {
        List<UIUser> _users;
        MembersView _view;
        string userKey;

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
            _users = JLDatabaseConnector.FetchUsers().
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
            User u = JLDatabaseConnector.GetUserByKey(userKey);
            u.IsVerified = u.IsVerified? false : true;
            JLDatabaseConnector.UpdateVerifiedUser(userKey, u);
            UpdateTable();
        }

        public void ToggleAdminStatus()
        {
            User u = JLDatabaseConnector.GetUserByKey(userKey);
            u.IsAdmin = u.IsAdmin ? false : true;
            JLDatabaseConnector.UpdateVerifiedUser(userKey, u);
            UpdateTable();
        }

        public void RemoveUser()
        {
            JLDatabaseConnector.RemoveUserByKey(userKey);
        }

        public void ViewDownloadLog(Window window)
        {
            // Get user to display
            UIUser user = _users.FirstOrDefault(u => u.Email == userKey);
            if (user == null)
                throw new Exception("User in table not found");

            // Send the user to the dialog
            DownloadLogWindow dialog = new DownloadLogWindow(window, user);
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
