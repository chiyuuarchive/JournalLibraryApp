﻿using JLDatabase.Database.Models;
using JLDatabase.Interface;
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
        UserRegistration _registration;

        public UserRegistrationViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            _registration = new UserRegistration();
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
            string[] fields = new string[Enum.GetValues(typeof(UserFieldTypes.Registration)).Length];
            fields[(int)UserFieldTypes.Registration.IsAdmin] = (view.chkIsAdmin.IsChecked == true).ToString();
            fields[(int)UserFieldTypes.Registration.FirstName] = view.txtFirstName.Text;
            fields[(int)UserFieldTypes.Registration.LastName] = view.txtLastName.Text;
            fields[(int)UserFieldTypes.Registration.Email] = view.txtEmail.Text;
            fields[(int)UserFieldTypes.Registration.Password] = view.txtPassword.Text;

            InvalidInputField result = InvalidInputField.None;
            string registrationMsg = _registration.Register(fields, out result);

            // Validate user input fields
            switch(result)
            {
                case InvalidInputField.IsAdmin:
                    ShowMessage(view.Owner, "Invalid admin settings");
                    return;
                case InvalidInputField.FirstName:
                    ShowMessage(view.Owner, "Invalid name format");
                    return;
                case InvalidInputField.LastName:
                    ShowMessage(view.Owner, "Invalid name format");
                    return;
                case InvalidInputField.Email:
                    ShowMessage(view.Owner, "Invalid email format");
                    return;
                case InvalidInputField.Password:
                    ShowMessage(view.Owner, "Invalid password format");
                    return;
                default: 
                    break;
            }
            
            // Display registration message
            if (registrationMsg != string.Empty)
                ShowMessage(view.Owner, registrationMsg);

            UpdateViewCommand?.Execute("LoginView");
        }

        private void ShowMessage(Window parent, string message)
        {
            MessageWindow mw = new MessageWindow(parent, message);
            mw.ShowDialog();
        }
    }
}