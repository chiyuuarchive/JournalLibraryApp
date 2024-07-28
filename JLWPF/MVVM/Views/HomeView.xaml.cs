using JLWPF.MVVM.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace JLWPF.MVVM.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        HomeViewModel _vm;

        public HomeView()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.NavigateToLoginView(Window.GetWindow(this));
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _vm = (HomeViewModel)DataContext;
            _vm.InitializeView(this, Window.GetWindow(this));
        }
    }
}
