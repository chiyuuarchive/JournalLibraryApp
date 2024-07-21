using JLWPF.MVVM.Auxiliaries;
using JLWPF.MVVM.Core;
using JLWPF.MVVM.Views;
using System.Windows.Controls;
using System.Windows.Input;

namespace JLWPF.MVVM.ViewModels
{
    class UserRegistrationViewModel : ViewModelBase
    {
        public UserRegistrationViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }

        public void ResetInputFields(UserRegistrationView view)
        {
            // Set default textbox styles
            view.txtFirstName.Text = InputFieldHandler.firstNamePlaceholderMsg;
            view.txtLastName.Text = InputFieldHandler.lastNamePlaceholderMsg;
            view.txtEmail.Text = InputFieldHandler.EmailPlaceholderMsg;
            view.txtPassword.Text = InputFieldHandler.PasswordPlaceholderMsg;
            InputFieldHandler.SetPlaceholderFontstyle(view.txtFirstName);
            InputFieldHandler.SetPlaceholderFontstyle(view.txtLastName);
            InputFieldHandler.SetPlaceholderFontstyle(view.txtEmail);
            InputFieldHandler.SetPlaceholderFontstyle(view.txtPassword);
        }

        public void UpdateInputField(TextBox input, InputFieldHandler.PlaceholderMsgType placeholderMsgType, bool isFocused)
        {
            string placeholderText = placeholderMsgType switch
            {
                InputFieldHandler.PlaceholderMsgType.FirstName => InputFieldHandler.firstNamePlaceholderMsg,
                InputFieldHandler.PlaceholderMsgType.LastName => InputFieldHandler.lastNamePlaceholderMsg,
                InputFieldHandler.PlaceholderMsgType.Email => InputFieldHandler.EmailPlaceholderMsg,
                InputFieldHandler.PlaceholderMsgType.Password => InputFieldHandler.PasswordPlaceholderMsg,
                _ => string.Empty
            };

            bool isPlaceholder = input.Text == placeholderText;

            if (isFocused && isPlaceholder)
            {
                input.Text = string.Empty;
            }
            else if (!isFocused && string.IsNullOrEmpty(input.Text))
            {
                input.Text = placeholderText;
                InputFieldHandler.SetPlaceholderFontstyle(input);
            }
            else if (!isPlaceholder)
            {
                InputFieldHandler.SetDefaultFontstyle(input);
            }
        }

        public void TrySubmitRegistration(UserRegistrationView view)
        {
            string[] userData = [
                (view.chkIsAdmin.IsChecked == true).ToString(),
                view.txtFirstName.Text,
                view.txtLastName.Text,
                view.txtEmail.Text,
                view.txtPassword.Text,
                ];



        }
    }
}
