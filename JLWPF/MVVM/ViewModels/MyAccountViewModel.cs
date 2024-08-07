﻿using JLDatabase;
using JLDatabase.Database.Models;
using JLWPF.Components;
using JLWPF.MVVM.Core;
using JLWPF.MVVM.Views;
using System.Windows;
using System.Windows.Input;

namespace JLWPF.MVVM.ViewModels
{
    internal class MyAccountViewModel : ViewModelBase
    {
        private User _user;
        private MyAccountView _view;

        public MyAccountViewModel(ICommand command)
        {
            UpdateViewCommand = command;
        }

        public void InitializeView(MyAccountView view, Window owner)
        {
            MainWindow w = (MainWindow)owner;

            if (w.User == null)
                throw new Exception("Log in failed. User not defined");

            // Update text fields
            _user = w.User;
            _view = view;
            _view.txtFirstName.Text = _user.FirstName;
            _view.txtLastName.Text = _user.LastName;
            _view.txtEmail.Text = _user.Email;
            _view.txtPassword.Text = _user.Password;
        }

        public void SubmitUserDetails(Window owner)
        {
            MainWindow mw = (MainWindow)owner;

            // Retreive fields for user
            string[] fields = new string[Enum.GetValues(typeof(UserFieldTypes.Registration)).Length];
            fields[(int)UserFieldTypes.Registration.IsAdmin] = _user.IsAdmin.ToString();
            fields[(int)UserFieldTypes.Registration.FirstName] = _view.txtFirstName.Text;
            fields[(int)UserFieldTypes.Registration.LastName] = _view.txtLastName.Text;
            fields[(int)UserFieldTypes.Registration.Email] = _view.txtEmail.Text;
            fields[(int)UserFieldTypes.Registration.Password] = _view.txtPassword.Text;

            InvalidInputFieldStatus validateResult = InvalidInputFieldStatus.None;
            InvalidAuthenticationStatus authenticateResult = InvalidAuthenticationStatus.None;

            JLDatabaseInterface.UpdateUserDetails(_user.Email, fields, false, out validateResult, out authenticateResult);

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
                    ShowMessage(mw.Owner, "User details successfully updated!");
                    UpdateViewCommand?.Execute("HomeView");
                    break;

                case InvalidAuthenticationStatus.EmailAlreadyRegistered:
                    ShowMessage(mw.Owner, "Email is already registered");
                    return;

                default:
                    throw new Exception("Unexpected authentication error from SettingsViewModel.cs");
            }

            // Update active user details
            EntityFactory factory = new EntityFactory();
            mw.User = factory.CreateUser(fields);
        }

        public void NavigateToHome()
        {
            UpdateViewCommand?.Execute("HomeView");
        }

        public void ClearFields()
        {
            _view.txtFirstName.Clear();
            _view.txtLastName.Clear();
            _view.txtEmail.Clear();
            _view.txtPassword.Clear();
        }

        private void ShowMessage(Window parent, string message)
        {
            MessageWindow mw = new MessageWindow(parent, message);
            mw.ShowDialog();
        }
    }
}