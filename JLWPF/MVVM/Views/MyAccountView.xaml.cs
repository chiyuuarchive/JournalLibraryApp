using JLWPF.MVVM.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace JLWPF.MVVM.Views
{
    public partial class MyAccountView : UserControl
    {
        private MyAccountViewModel _vm;

        public MyAccountView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _vm = (MyAccountViewModel)DataContext;
            _vm.InitializeView(this, Window.GetWindow(this));
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.NavigateToHome();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.ClearFields();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.SubmitUserDetails(Window.GetWindow(this));
        }
    }
}