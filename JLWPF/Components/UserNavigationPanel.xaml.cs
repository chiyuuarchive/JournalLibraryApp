using JLDatabase.Database.Models;
using JLWPF.MVVM.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace JLWPF.Components
{
    /// <summary>
    /// Interaction logic for UserNavigationPanel.xaml
    /// </summary>
    public partial class UserNavigationPanel : UserControl
    {
        public UserNavigationPanel()
        {
            InitializeComponent();
        }

        private void btnMyAccount_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);
            User? u = mw.User;
            MainViewModel vm = (MainViewModel)mw.DataContext;
            if (vm != null)
                vm.UpdateViewCommand?.Execute("MyAccountView");
        }

        private void btnLibrary_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);
            User? u = mw.User;
            MainViewModel vm = (MainViewModel)mw.DataContext;
            if (vm != null)
                vm.UpdateViewCommand?.Execute("LibraryView");
        }
    }
}