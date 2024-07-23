using JLDatabase.Database.Models;
using JLWPF.MVVM.Core;
using System.Windows.Input;

namespace JLWPF.MVVM.ViewModels
{
    class LibraryViewModel : ViewModelBase
    {
        User _currentUser;

        public LibraryViewModel(ICommand command)
        {
            UpdateViewCommand = command;
        }
    }
}
