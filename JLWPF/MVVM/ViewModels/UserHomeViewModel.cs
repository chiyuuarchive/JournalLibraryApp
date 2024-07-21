using JLWPF.MVVM.Core;
using JLWPF.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JLWPF.MVVM.ViewModels
{
    class UserHomeViewModel : ViewModelBase
    {
        UserHomeView _view;

        public UserHomeViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
    }
}
