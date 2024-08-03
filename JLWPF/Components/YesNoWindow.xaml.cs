using System.Windows;
using System.Windows.Input;

namespace JLWPF.Components
{
    /// <summary>
    /// Interaction logic for YesNoWindow.xaml
    /// </summary>
    public partial class YesNoWindow : Window
    {
        private bool _confirmed;

        public bool Confirmed
        {
            get { return _confirmed; }
            set { _confirmed = value; }
        }

        public YesNoWindow(Window mainWindow, string message)
        {
            InitializeComponent();
            UIHeader.Owner = this;

            Owner = mainWindow;
            Confirmed = false;
            txtMessage.Text = message;
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            Confirmed = true;
            Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            Confirmed = false;
            Close();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}