using JLWPF.MVVM.ViewModels;
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
    /// Interaction logic for UserLibraryPanel.xaml
    /// </summary>
    public partial class UserLibraryPanel : UserControl
    {
        LibraryViewModel _vm;

        public UserLibraryPanel()
        {
            InitializeComponent();
        }

        private void btnViewArticle_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.ViewSelectedArticle(Window.GetWindow(this));
        }

        public void EnableViewArticleButton(bool isTrue)
        {
            btnViewArticle.IsEnabled = isTrue;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is LibraryViewModel)
            {
                _vm = (LibraryViewModel)DataContext;
                if (_vm == null)
                    throw new Exception("DataContext not type of LibraryViewModel");
            }
        }
    }
}
