using JLDatabase;
using JLWPF.Components;
using JLWPF.MVVM.Core;
using JLWPF.MVVM.Views;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace JLWPF.MVVM.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        private bool _isAdminPanelVisible;
        public bool IsUserPanelVisible => !_isAdminPanelVisible;
        public bool IsAdminPanelVisible
        {
            get => _isAdminPanelVisible;
            set
            {
                _isAdminPanelVisible = value;
                OnPropertyChanged(nameof(IsAdminPanelVisible));
                OnPropertyChanged(nameof(IsUserPanelVisible));
            }
        }

        public HomeViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }

        public void InitializeView(HomeView view, Window window)
        {
            MainWindow mw = (MainWindow)window;

            if (mw.User == null)
                throw new Exception("Log in failed. User not defined");

            string _lastLogin = mw.User.LastTimeLoggedIn.ToString("dd/MM/yyyy, HH:mm:ss");

            // Initialize text
            view.txtWelcome.Text = $"Welcome, {mw.User.Name}";
            view.txtLastTimeLoggedIn.Text = $"Last time logged in: {_lastLogin}";
            view.txtInstructions.Text = string.Empty;

            // Update navigation panel
            IsAdminPanelVisible = mw.User.IsAdmin;


            if (mw.User.IsAdmin)
            {
                view.txtInstructions.Inlines.Add("To change user settings press the 'Settings' button ");
                view.txtInstructions.Inlines.Add(new LineBreak());
                view.txtInstructions.Inlines.Add("To edit articles press the 'Library' button");
                view.txtInstructions.Inlines.Add(new LineBreak());
                view.txtInstructions.Inlines.Add("To edit registered members press the 'Members' button");
            }
            else
            {
                view.txtInstructions.Inlines.Add("To change user settings press the 'Settings' button ");
                view.txtInstructions.Inlines.Add(new LineBreak());
                view.txtInstructions.Inlines.Add("To view articles press the 'Library' button");
            }

            mw.User.LastTimeLoggedIn = DateTime.Now;
            JLInterface.UpdateUserLoginTime(mw.User);
        }

        public void NavigateToLoginView(Window window)
        {
            MainWindow mw = (MainWindow)window;
            if (mw == null)
                throw new Exception("Window is not of type MainWindow");

            // Prompt a confirm window
            YesNoWindow w = new YesNoWindow("Do you want to log out?");
            w.Owner = mw;
            w.ShowDialog();

            if (w.Confirmed)
            {
                mw.User = null;
                UpdateViewCommand?.Execute("LoginView");
            }
        }
    }
}
