using JLDatabase.Database.Models;
using JLWPF.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JLWPF.Components
{
    /// <summary>
    /// Interaction logic for AdminNavigationPanel.xaml
    /// </summary>
    public partial class AdminNavigationPanel : UserControl
    {
        public AdminNavigationPanel()
        {
            InitializeComponent();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);
            User? u = mw.User;
            MainViewModel vm = (MainViewModel)mw.DataContext;
            if (vm != null)
                vm.UpdateViewCommand?.Execute("SettingsView");
        }

        private void btnLibrary_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);
            User? u = mw.User;
            MainViewModel vm = (MainViewModel)mw.DataContext;
            if (vm != null)
                vm.UpdateViewCommand?.Execute("LibraryView");
        }

        private void btnMembers_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = (MainWindow)Window.GetWindow(this);
            User? u = mw.User;
            MainViewModel vm =(MainViewModel)mw.DataContext;
            if (vm != null)
                vm.UpdateViewCommand?.Execute("MembersView");
        }
    }
}
