using System.Windows;

namespace JLWPF.Components
{
    /// <summary>
    /// Interaction logic for ExitAppWindow.xaml
    /// </summary>
    public partial class ExitAppWindow : Window
    {
        private bool _confirmed;

        public bool Confirmed
        {
            get { return _confirmed; }
            set { _confirmed = value; }
        }

        public ExitAppWindow()
        {
            InitializeComponent();
            Confirmed = false;
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
