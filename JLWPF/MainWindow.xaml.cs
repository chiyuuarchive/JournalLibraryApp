using JLDatabase.Database.Models;
using JLWPF.MVVM.ViewModels;
using System.Windows;

namespace JLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User? _user;

        public User? User
        {
            get => _user;
            set => _user = value;
        }

        public MainWindow()
        {
            InitializeComponent();
            MainViewModel vm = new MainViewModel();
            DataContext = vm;
            UIHeader.Owner = this;
            MouseDown += UIHeader_MouseDown;
        }

        private void UIHeader_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}