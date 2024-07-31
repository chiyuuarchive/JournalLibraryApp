using System.Windows;

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

        public YesNoWindow(Window parent, string message)
        {
            InitializeComponent();
            Owner = parent;
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
            Close();
        }
    }
}
