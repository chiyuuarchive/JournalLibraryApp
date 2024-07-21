using JLDatabase;
using JLDatabase.Database.Models;
using JLWPF.Components;
using JLWPF.MVVM.Auxiliaries;
using JLWPF.MVVM.Core;
using JLWPF.MVVM.Views;
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

        public bool TryLogin(LoginView view)
        {
            string[] fields = new string[Enum.GetValues(typeof(UserFieldTypes.Login)).Length];
            fields[(int)UserFieldTypes.Login.Email] = view.txtEmail.Text;
            fields[(int)(UserFieldTypes.Login.Password)] = view.txtPassword.Text;
            InvalidInputField result = InvalidInputField.None;
            User? u = _authentication.Authenticate(fields, out result);

            // Handle visual cue of invalid fields + Login command
            MessageWindow mw;
            switch (result)
            {
                case InvalidInputField.Email:
                    ShowMessage("Invalid email!");
                    return false;
                case InvalidInputField.Password:
                    ShowMessage("Invalid password!");
                    return false;
            }

            if (result != InvalidInputField.None)
                return false;

            // If user is not found
            if (u == null)
            {
                ShowMessage("Invalid login information. User not found!");
                return false;
            }

            // Check if user is verified
            if (!u.IsVerified)
            {
                ShowMessage("User found but not verified. Contact adminstration!");
                return false;
            }

            // Perform login action
            if (u.IsAdmin)
                UpdateViewCommand!.Execute("AdminHomeView");
            else
                UpdateViewCommand!.Execute("UserHomeView");

            return true;
        }

        private void ShowMessage(string message)
        {
            MessageWindow mw = new MessageWindow(message);
            mw.ShowDialog();
        }
    } 
}
