using JLDatabase;
using JLDatabase.Database.Models;
using JLWPF.MVVM.Core;
using JLWPF.MVVM.Views;
using System.Windows;
using System.Windows.Input;

namespace JLWPF.MVVM.ViewModels
{
    class UserSettingsViewModel : ViewModelBase
    {
        public UserSettingsViewModel(ICommand command)
        {
            UpdateViewCommand = command;
        }

        public void InitializeView(UserSettingsView view, Window owner)
        {
            MainWindow w = (MainWindow)owner;

            if (w.User == null)
                throw new Exception("Log in failed. User not defined");

            // Update text fields
        }

        public void SubmitChanges(UserSettingsView view)
        {
            // Retreive fields for user

            // JLInterface.SubmitUserChanges()
        }
    }
}
