using JLWPF.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace JLWPF.MVVM.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        SettingsViewModel _vm;

        public SettingsView()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.SubmitChanges(this, Window.GetWindow(this));
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.ClearFields(this);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _vm = (SettingsViewModel)DataContext;
            _vm.InitializeView(this, Window.GetWindow(this));
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.NavigateToHome();
        }
    }
}
