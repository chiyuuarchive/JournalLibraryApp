using JLWPF.MVVM.ViewModels;
using System.Windows.Input;

namespace JLWPF.Commands
{
    internal class UpdateViewCommand(MainViewModel viewModel) : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is not string)
                return;

            if (viewModel.UpdateViewCommand == null)
                return;

            viewModel.CurrentViewModel = parameter.ToString() switch
            {
                "LoginView" => new LoginViewModel(viewModel.UpdateViewCommand),
                "UserRegistrationView" => new UserRegistrationViewModel(viewModel.UpdateViewCommand),
                "HomeView" => new HomeViewModel(viewModel.UpdateViewCommand),
                "MyAccountView" => new MyAccountViewModel(viewModel.UpdateViewCommand),
                "LibraryView" => new LibraryViewModel(viewModel.UpdateViewCommand),
                "MembersView" => new MembersViewModel(viewModel.UpdateViewCommand),
                _ => throw new Exception("Invalid navigation string"),
            };
        }
    }
}