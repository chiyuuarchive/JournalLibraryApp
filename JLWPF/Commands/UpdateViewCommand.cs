using JLWPF.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JLWPF.Commands
{
    class UpdateViewCommand : ICommand
    {
        private MainViewModel _parentViewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            _parentViewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is not string)
                return;

            if (_parentViewModel.UpdateViewCommand == null) 
                return;

            switch (parameter.ToString())
            {
                case "LoginView":
                    _parentViewModel.CurrentViewModel = new LoginViewModel(_parentViewModel.UpdateViewCommand);
                    break;
                case "UserRegistrationView":
                    _parentViewModel.CurrentViewModel = new UserRegistrationViewModel(_parentViewModel.UpdateViewCommand);
                    break;
                case "HomeView":
                    _parentViewModel.CurrentViewModel = new HomeViewModel(_parentViewModel.UpdateViewCommand);
                    break;
                case "SettingsView":
                    _parentViewModel.CurrentViewModel = new SettingsViewModel(_parentViewModel.UpdateViewCommand);
                    break;
                case "LibraryView":
                    _parentViewModel.CurrentViewModel = new LibraryViewModel(_parentViewModel.UpdateViewCommand);
                    break;
                case "MembersView":
                    _parentViewModel.CurrentViewModel = new MembersViewModel(_parentViewModel.UpdateViewCommand);
                    break;
                default:
                    throw new Exception("Invalid navigation string");
            }
        }
    }
}
