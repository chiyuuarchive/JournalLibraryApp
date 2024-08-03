using JLWPF.Commands;
using JLWPF.MVVM.Core;

namespace JLWPF.MVVM.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel = null!;

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