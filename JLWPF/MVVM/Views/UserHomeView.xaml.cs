using JLWPF.MVVM.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace JLWPF.MVVM.Views
{
    /// <summary>
    /// Interaction logic for UserHomeView.xaml
    /// </summary>
    public partial class UserHomeView : UserControl
    {
        private UserHomeViewModel _vm;

        public UserHomeView()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.NavigateToLoginView();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _vm = (UserHomeViewModel)DataContext;
            _vm.InitializeView(this, Window.GetWindow(this));
        }

        private void btnUserSettings_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.NavigateToUserSettingsView();
        }

        private void btnLibrary_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.NavigateToLibraryView();
        }
    }
}
