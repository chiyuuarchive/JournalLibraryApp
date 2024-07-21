using JLWPF.Commands;
using JLWPF.MVVM.Core;
using System.Windows.Input;

namespace JLWPF.MVVM.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);

            // Set default view to Login View
            if (UpdateViewCommand.CanExecute("LoginView"))
                UpdateViewCommand.Execute("LoginView");
        }
    }
}
