using System.Windows;

namespace JLWPF.Components
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow(Window owner, string message)
        {
            InitializeComponent();
            Owner = owner;
            txtMessage.Text = message;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
