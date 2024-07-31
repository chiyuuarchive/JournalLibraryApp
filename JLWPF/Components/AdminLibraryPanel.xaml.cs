using JLWPF.MVVM.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace JLWPF.Components
{
    /// <summary>
    /// Interaction logic for AdminLibraryPanel.xaml
    /// </summary>
    public partial class AdminLibraryPanel : UserControl
    {
        LibraryViewModel _vm;

        public AdminLibraryPanel()
        {
            InitializeComponent();
        }

        private void btnRemoveArticle_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.RemoveSelectedArticle(Window.GetWindow(this));
        }

        private void btnEditArticle_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.AddEditSelectedArticle(Window.GetWindow(this));
        }

        private void btnViewArticle_Click(object sender, RoutedEventArgs e)
        {
            if (_vm != null)
                _vm.ViewSelectedArticle(Window.GetWindow(this));
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

        public void EnableViewArticleButton(bool enable)
        {
            btnViewArticle.IsEnabled = enable;
        }

        public void EnableRemoveArticleButton(bool enable)
        {
            btnRemoveArticle.IsEnabled = enable;
        }

    }
}
