using JLDatabase.Database.Models;
using JLWPF.MVVM.Core;
using JLWPF.MVVM.Views;
using System.Windows.Input;

namespace JLWPF.MVVM.ViewModels
{
    class UserHomeViewModel : ViewModelBase
    {
        UserHomeView _view;
        User? currentUser;

        public UserHomeViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;

        }
    }
}
