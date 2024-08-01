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

namespace JLWPF.MVVM.Views
{
    /// <summary>
    /// Interaction logic for MembersView.xaml
    /// </summary>
    public partial class MembersView : UserControl
    {
        MembersViewModel _vm;

        public MembersView()
        {
            InitializeComponent();
        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is  MembersViewModel vm)
            {
                _vm = vm;
                _vm.InitializeView(this, Window.GetWindow(this));
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.NavigateToHome();
        }

        private void btnViewDownloadLog_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.ViewDownloadLog(Window.GetWindow(this));
        }

        private void btnRemoveMember_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.RemoveUser();
        }


        private void btnVerify_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.ToggleVerifyStatus();
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.ToggleAdminStatus();
        }

        private void MembersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_vm != null)
                _vm.UpdateSelectedUser();
        }
    }
}
