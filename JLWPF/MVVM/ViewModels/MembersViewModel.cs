using JLWPF.MVVM.Core;
using JLWPF.MVVM.Views;
using System.Windows;
using System.Windows.Input;

namespace JLWPF.MVVM.ViewModels
{
    class MembersViewModel : ViewModelBase
    {
        public MembersViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand; 
        }

        public void InitializeView(MembersView view, Window window)
        {

        }

        public void NavigateToHome()
        {
            UpdateViewCommand?.Execute("HomeView");
        }
    }
}
