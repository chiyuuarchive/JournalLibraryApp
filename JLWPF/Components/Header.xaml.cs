using System.Windows;
using System.Windows.Controls;

namespace JLWPF.Components
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        private Window _owner;

        public Window Owner
        {
            get => _owner;
            set => _owner = value;
        }

        public Header()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            _owner.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (_owner is MainWindow)
            {
                YesNoWindow w = new YesNoWindow(Window.GetWindow(this), "Are you sure you want to close?");
                // Set owner to the main window
                w.Owner = Owner;
                w.ShowDialog();

                if (w.Confirmed)
                {
                    Owner.Close();
                }

                return;
            }
            Owner.Close();
        }
    }
}