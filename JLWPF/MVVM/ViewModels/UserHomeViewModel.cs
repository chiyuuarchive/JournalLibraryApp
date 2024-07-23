using JLDatabase;
using JLDatabase.Database.Models;
using JLWPF.Components;
using JLWPF.MVVM.Core;
using JLWPF.MVVM.Views;
using System.Windows;
using System.Windows.Input;

namespace JLWPF.MVVM.ViewModels
{
    class UserHomeViewModel : ViewModelBase
    {
        MainWindow _owner;

        public UserHomeViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }

        public void InitializeView(UserHomeView view, Window owner)
        {
            _owner = (MainWindow)owner;

            if (_owner.User == null)
                throw new Exception("Log in failed. User not defined");

            string _lastLogin = _owner.User.LastTimeLoggedIn.ToString("dd/MM/yyyy, HH:mm:ss");

            // Initialize text
            view.txtWelcome.Text = $"Welcome, {_owner.User.Name}";
            view.txtLstTimeLogged.Text = $"Last time logged in: {_lastLogin}";

            _owner.User.LastTimeLoggedIn = DateTime.Now;
            JLInterface.UpdateUserLoginTime(_owner.User);
        }


        public void NavigateToLoginView()
        {
            // Prompt a confirm window
            YesNoWindow w = new YesNoWindow("Do you want to log out?");
            w.ShowDialog();

            if (w.Confirmed)
            {
                _owner.User = null;
                UpdateViewCommand?.Execute("LoginView");
            }
        }

        public void NavigateToUserSettingsView()
        {
            UpdateViewCommand?.Execute("UserSettingsView");
        }

        public void NavigateToLibraryView()
        {
            UpdateViewCommand?.Execute("LibraryView");
        }
    }
}
