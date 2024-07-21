using JLWPF.MVVM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JLWPF.MVVM.ViewModels
{
    class AdminHomeViewModel : ViewModelBase
    {
        public AdminHomeViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
    }
}
