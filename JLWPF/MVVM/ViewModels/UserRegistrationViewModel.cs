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

        public void TrySubmitRegistration(UserRegistrationView view, Window owner)
        {
            MainWindow mw = (MainWindow)owner;

            // Retrieve fieldds
            string[] fields = new string[Enum.GetValues(typeof(UserFieldTypes.Registration)).Length];
            fields[(int)UserFieldTypes.Registration.IsAdmin] = (view.chkIsAdmin.IsChecked == true).ToString();
            fields[(int)UserFieldTypes.Registration.FirstName] = view.txtFirstName.Text;
            fields[(int)UserFieldTypes.Registration.LastName] = view.txtLastName.Text;
            fields[(int)UserFieldTypes.Registration.Email] = view.txtEmail.Text;
            fields[(int)UserFieldTypes.Registration.Password] = view.txtPassword.Text;

            InvalidInputFieldStatus validateResult = InvalidInputFieldStatus.None;
            InvalidAuthenticationStatus authenticateResult = InvalidAuthenticationStatus.None;
            
            JLInterface.RegisterUser(fields, out validateResult, out authenticateResult);

            // Handle validation results
            switch (validateResult)
            {
                case InvalidInputFieldStatus.IsAdmin:
                    ShowMessage(mw.Owner, "Invalid admin settings");
                    return;
                case InvalidInputFieldStatus.FirstName:
                    ShowMessage(mw.Owner, "Invalid first name");
                    return;
                case InvalidInputFieldStatus.LastName:
                    ShowMessage(mw.Owner, "Invalid last name");
                    return;
                case InvalidInputFieldStatus.Email:
                    ShowMessage(mw.Owner, "Invalid email format");
                    return;
                case InvalidInputFieldStatus.Password:
                    ShowMessage(mw.Owner, "Invalid password format");
                    return;
                default: 
                    break;
            }

            // Handle authentication results
            switch (authenticateResult)
            {
                case InvalidAuthenticationStatus.None:
                    UpdateViewCommand?.Execute("LoginView");
                    break;
                case InvalidAuthenticationStatus.EmailAlreadyRegistered:
                    ShowMessage(mw.Owner, "Email is already registered");
                    return;
                default:
                    throw new Exception("Unexpected error from UserRegistrationViewModel.cs");

            }
        }

        private void ShowMessage(Window parent, string message)
        {
            MessageWindow mw = new MessageWindow(parent, message);
            mw.ShowDialog();
        }
    }
}
