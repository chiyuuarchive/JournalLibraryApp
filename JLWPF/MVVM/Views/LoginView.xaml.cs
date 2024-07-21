using System.Windows;
using System.Windows.Controls;
using JLWPF.MVVM.ViewModels;

namespace JLWPF.MVVM.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        private Window _owner;
        LoginViewModel? _vm;

        public Window Owner
        {
            get => _owner;
            set => _owner = value;
        }

        public LoginView()
        {
            InitializeComponent();
            Loaded += UserControl_Loaded;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.TryLogin(this);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.ResetInputFields(this);
        }


        private void txtEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.UpdateInputField(txtEmail, Auxiliaries.InputFieldHandler.PlaceholderMsgType.Email, true);
        }

        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.UpdateInputField(txtEmail, Auxiliaries.InputFieldHandler.PlaceholderMsgType.Email, false);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _vm = (LoginViewModel)DataContext;
            _owner = Window.GetWindow(this);
            _vm.ResetInputFields(this);
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.UpdateInputField(txtPassword, Auxiliaries.InputFieldHandler.PlaceholderMsgType.Password, true);
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {

            if (_vm != null)
                _vm.UpdateInputField(txtPassword, Auxiliaries.InputFieldHandler.PlaceholderMsgType.Password, false);
        }
    }
}
