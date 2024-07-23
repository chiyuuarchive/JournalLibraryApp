using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JLWPF.Components
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        Window _owner;
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
            YesNoWindow w = new YesNoWindow("Are you sure you want to exit?");

            // Set owner to the main window
            w.Owner = Owner;
            w.ShowDialog();

            if (w.Confirmed)
            {
                Owner.Close();
            }
        }
    }
}
