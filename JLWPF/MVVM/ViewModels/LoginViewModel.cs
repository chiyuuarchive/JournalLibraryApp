using JLDatabase;
using JLDatabase.Database.Models;
using JLWPF.Components;
using JLWPF.MVVM.Auxiliaries;
using JLWPF.MVVM.Core;
using JLWPF.MVVM.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JLWPF.MVVM.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        LoginAuthentication _authentication;
        public LoginViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            _authentication = new LoginAuthentication();
        }

        public void ResetInputFields(LoginView view)
        {
            // Set default textbox styles
            view.txtEmail.Text = InputFieldHandler.EmailPlaceholderMsg;
            InputFieldHandler.SetPlaceholderFontstyle(view.txtEmail);
            view.txtPassword.Text = InputFieldHandler.PasswordPlaceholderMsg;
            InputFieldHandler.SetPlaceholderFontstyle(view.txtPassword);
        }

        public void UpdateInputField(TextBox input, InputFieldHandler.PlaceholderMsgType placeholderMsgType, bool isFocused)
        {
            string placeholderText = placeholderMsgType switch
            {
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

        public void TryLogin(LoginView view)
        {
            string[] fields = new string[Enum.GetValues(typeof(UserFieldTypes.Login)).Length];
            fields[(int)UserFieldTypes.Login.Email] = view.txtEmail.Text;
            fields[(int)(UserFieldTypes.Login.Password)] = view.txtPassword.Text;
            InvalidInputField result = InvalidInputField.None;
            User? u = _authentication.Authenticate(fields, out result);

            // Validate user input fields
            switch (result)
            {
                case InvalidInputField.Email:
                    ShowMessage(view.Owner, "Invalid email format");
                    return;
                case InvalidInputField.Password:
                    ShowMessage(view.Owner, "Invalid password format");
                    return;
                default:
                    break;
            }

            // If user is not found
            if (u == null)
            {
                ShowMessage(view.Owner, "Invalid login information. User not found!");
                return;
            }

            // If user is not verified
            if (!u.IsVerified)
            {
                ShowMessage(view.Owner, "User found but not verified. Contact adminstration!");
                return;
            } 
            
            // Perform login action
            if (u.IsAdmin)
                UpdateViewCommand?.Execute("AdminHomeView");
            else
                UpdateViewCommand?.Execute("UserHomeView");
            
        }

        private void ShowMessage(Window parent, string message)
        {
            MessageWindow mw = new MessageWindow(parent, message);
            mw.ShowDialog();
        }
    } 
}
