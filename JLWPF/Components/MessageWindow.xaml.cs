using System.Windows;
using System.Windows.Input;

namespace JLWPF.Components
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow(Window mainWindow, string message)
        {
            InitializeComponent();
            UIHeader.Owner = this;

            Owner = mainWindow;
            txtMessage.Text = message;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
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