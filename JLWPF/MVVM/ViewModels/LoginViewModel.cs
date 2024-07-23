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
        private MainWindow _owner;
        public void SetParentWindow(Window owner) => _owner = (MainWindow)owner;
        public LoginViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
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
            InvalidInputFieldStatus validateResult = InvalidInputFieldStatus.None;
            InvalidAuthenticationStatus authenticateResult = InvalidAuthenticationStatus.None;

            User? u = JLInterface.Login(fields, out validateResult, out authenticateResult);

            // Handle validation results
            switch (validateResult)
            {
                case InvalidInputFieldStatus.Email:
                    ShowMessage(_owner, "Invalid email format");
                    return;
                case InvalidInputFieldStatus.Password:
                    ShowMessage(_owner, "Invalid password format");
                    return;
                default:
                    break;
            }

            // Handle authentication results
            switch (authenticateResult)
            {
                case InvalidAuthenticationStatus.None:
                    if (u == null) return;
                    if (u.IsAdmin) UpdateViewCommand?.Execute("AdminHomeView");
                    else UpdateViewCommand?.Execute("UserHomeView");
                    break;
                case InvalidAuthenticationStatus.UserDoesntExist:
                    ShowMessage(_owner, "Invalid login information. User not found!");
                    return;
                case InvalidAuthenticationStatus.UserNotVerified:
                    ShowMessage(_owner, "User found but not verified. Contact adminstration!");
                    return;
                default:
                    throw new Exception("Unexpected error from LoginViewModel.cs");
            }

            // Set active user
            if (_owner != null) _owner.User = u;
        }

        private void ShowMessage(MainWindow parent, string message)
        {
            MessageWindow mw = new MessageWindow(parent, message);
            mw.ShowDialog();
        }
    } 
}
