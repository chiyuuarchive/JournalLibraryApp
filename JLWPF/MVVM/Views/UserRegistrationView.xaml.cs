using JLWPF.MVVM.Auxiliaries;
using JLWPF.MVVM.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace JLWPF.MVVM.Views
{
    /// <summary>
    /// Interaction logic for UserRegistrationView.xaml
    /// </summary>
    public partial class UserRegistrationView : UserControl
    {
        private Window _owner;
        UserRegistrationViewModel? _viewModel;

        public Window Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public UserRegistrationView()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
                _viewModel.ResetInputFields(this);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
                _viewModel.TrySubmitRegistration(this);
        }

        private void txtFirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
                _viewModel.UpdateInputField(txtFirstName, InputFieldHandler.PlaceholderMsgType.FirstName, true);
        }

        private void txtFirstName_LostFocus(object sender, RoutedEventArgs e)
        {

            if (_viewModel != null)
                _viewModel.UpdateInputField(txtFirstName, InputFieldHandler.PlaceholderMsgType.FirstName, false);
        }

        private void txtLastName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
                _viewModel.UpdateInputField(txtLastName, InputFieldHandler.PlaceholderMsgType.LastName, true);
        }

        private void txtLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
                _viewModel.UpdateInputField(txtLastName, InputFieldHandler.PlaceholderMsgType.LastName, false);
        }

        private void txtEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
                _viewModel.UpdateInputField(txtEmail, InputFieldHandler.PlaceholderMsgType.Email, true);
        }

        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
                _viewModel.UpdateInputField(txtEmail, InputFieldHandler.PlaceholderMsgType.Email, false);
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
                _viewModel.UpdateInputField(txtPassword, InputFieldHandler.PlaceholderMsgType.Password, true);
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
                _viewModel.UpdateInputField(txtPassword, InputFieldHandler.PlaceholderMsgType.Password, false);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel = (UserRegistrationViewModel)DataContext;
            _owner = Window.GetWindow(this);
            _viewModel.ResetInputFields(this);
        }
    }
}
