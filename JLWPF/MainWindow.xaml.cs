using JLWPF.Components;
using JLWPF.MVVM.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace JLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel vm = new MainViewModel();
            DataContext = vm;
            UIHeader.Owner = this;
            MouseDown += UIHeader_MouseDown;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ExitAppWindow w = new ExitAppWindow();

            // Set owner to the main window
            w.Owner = this;
            w.ShowDialog();

            if (w.Confirmed)
            {
                Close();
            }
        }

        private void UIHeader_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
