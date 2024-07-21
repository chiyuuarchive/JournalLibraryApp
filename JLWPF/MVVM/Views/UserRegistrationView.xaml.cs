using JLWPF.MVVM.Auxiliaries;
using JLWPF.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            Loaded += UserControl_Loaded;
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
